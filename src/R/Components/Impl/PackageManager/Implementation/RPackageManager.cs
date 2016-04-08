﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.R.Components.InteractiveWorkflow;
using Microsoft.R.Components.PackageManager.Model;
using Microsoft.R.Components.PackageManager.ViewModel;
using Microsoft.R.Components.Settings;
using Microsoft.R.Host.Client;
using Microsoft.R.Host.Client.Session;
using Newtonsoft.Json.Linq;

namespace Microsoft.R.Components.PackageManager.Implementation {
    internal class RPackageManager : IRPackageManager {
        private readonly IRInteractiveWorkflow _interactiveWorkflow;
        private readonly Action _dispose;
        private readonly SessionPool _sessionPool;

        public IRPackageManagerVisualComponent VisualComponent { get; private set; }
        public IRPackageManagerViewModel _viewModel;

        public RPackageManager(IRSessionProvider sessionProvider, IRSettings settings, IRInteractiveWorkflow interactiveWorkflow, Action dispose) {
            _interactiveWorkflow = interactiveWorkflow;
            _dispose = dispose;
            _sessionPool = new SessionPool(sessionProvider, settings);
        }

        public IRPackageManagerVisualComponent GetOrCreateVisualComponent(IRPackageManagerVisualComponentContainerFactory visualComponentContainerFactory, int instanceId = 0) {
            if (VisualComponent != null) {
                return VisualComponent;
            }

            VisualComponent = visualComponentContainerFactory.GetOrCreate(this, _interactiveWorkflow.RSession, instanceId).Component;
            return VisualComponent;
        }

        public async Task<IReadOnlyList<RPackage>> GetInstalledPackagesAsync() {
            return await GetPackagesAsync(async (eval) => await eval.InstalledPackages());
        }

        public async Task<IReadOnlyList<RPackage>> GetAvailablePackagesAsync() {
            return await GetPackagesAsync(async (eval) => await eval.AvailablePackages());
        }

        public async Task InstallPackageAsync(string name, string libraryPath) {
            if (!_interactiveWorkflow.RSession.IsHostRunning) {
                throw new RPackageManagerException(Resources.PackageManager_EvalSessionNotAvailable);
            }

            try {
                using (var request = await _interactiveWorkflow.RSession.BeginInteractionAsync()) {
                    if (string.IsNullOrEmpty(libraryPath)) {
                        await request.InstallPackage(name);
                    } else {
                        await request.InstallPackage(name, libraryPath);
                    }
                }
            } catch (MessageTransportException ex) {
                throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
            }
        }

        public async Task UninstallPackageAsync(string name, string libraryPath) {
            if (!_interactiveWorkflow.RSession.IsHostRunning) {
                throw new RPackageManagerException(Resources.PackageManager_EvalSessionNotAvailable);
            }

            try {
                using (var request = await _interactiveWorkflow.RSession.BeginInteractionAsync()) {
                    if (string.IsNullOrEmpty(libraryPath)) {
                        await request.UninstallPackage(name);
                    } else {
                        await request.UninstallPackage(name, libraryPath);
                    }
                }
            } catch (MessageTransportException ex) {
                throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
            }
        }

        public async Task LoadPackageAsync(string name, string libraryPath) {
            if (!_interactiveWorkflow.RSession.IsHostRunning) {
                throw new RPackageManagerException(Resources.PackageManager_EvalSessionNotAvailable);
            }

            try {
                using (var request = await _interactiveWorkflow.RSession.BeginInteractionAsync()) {
                    if (string.IsNullOrEmpty(libraryPath)) {
                        await request.LoadPackage(name);
                    } else {
                        await request.LoadPackage(name, libraryPath);
                    }
                }
            } catch (MessageTransportException ex) {
                throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
            }
        }

        public async Task UnloadPackageAsync(string name) {
            if (!_interactiveWorkflow.RSession.IsHostRunning) {
                throw new RPackageManagerException(Resources.PackageManager_EvalSessionNotAvailable);
            }

            try {
                using (var request = await _interactiveWorkflow.RSession.BeginInteractionAsync()) {
                    await request.UnloadPackage(name);
                }
            } catch (MessageTransportException ex) {
                throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
            }
        }

        public async Task<string[]> GetLoadedPackagesAsync() {
            if (!_interactiveWorkflow.RSession.IsHostRunning) {
                throw new RPackageManagerException(Resources.PackageManager_EvalSessionNotAvailable);
            }

            try {
                var result = await _interactiveWorkflow.RSession.LoadedPackages();
                CheckEvaluationResult(result);

                return ((JArray)result.JsonResult)
                    .Select(p => (string)((JValue)p).Value)
                    .ToArray();
            } catch (MessageTransportException ex) {
                throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
            }
        }

        public async Task<string[]> GetLibraryPathsAsync() {
            if (!_interactiveWorkflow.RSession.IsHostRunning) {
                throw new RPackageManagerException(Resources.PackageManager_EvalSessionNotAvailable);
            }

            try {
                var result = await _interactiveWorkflow.RSession.LibraryPaths();
                CheckEvaluationResult(result);

                return ((JArray)result.JsonResult)
                    .Select(p => (string)((JValue)p).Value)
                    .ToArray();
            } catch (MessageTransportException ex) {
                throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
            }
        }

        private async Task<IReadOnlyList<RPackage>> GetPackagesAsync(Func<IRExpressionEvaluator, Task<REvaluationResult>> queryFunc) {
            // Fetching of installed and available packages is done in a
            // separate package query session to avoid freezing the REPL.
            using (var session = await _sessionPool.GetSession()) {
                try {
                    // Get the repos and libpaths from the REPL session and set them
                    // in the package query session
                    await EvalRepositoriesAsync(session, await DeparseRepositoriesAsync());
                    await EvalLibrariesAsync(session, await DeparseLibrariesAsync());

                    var result = await queryFunc(session);
                    CheckEvaluationResult(result);

                    // An empty list is serialized as json array because it does not have names
                    // This happens when there are no results
                    if (result.JsonResult is JArray) {
                        return new List<RPackage>().AsReadOnly();
                    }

                    return ((JObject)result.JsonResult).Properties()
                        .Select(p => p.Value.ToObject<RPackage>())
                        .ToList().AsReadOnly();
                } catch (MessageTransportException ex) {
                    throw new RPackageManagerException(Resources.PackageManager_TransportError, ex);
                }
            }
        }

        private async Task EvalRepositoriesAsync(IRSession session, string deparsedRepositories) {
            var code = string.Format("options(repos=eval(parse(text={0})))", deparsedRepositories.ToRStringLiteral());
            using (var eval = await session.BeginEvaluationAsync()) {
                var result = await eval.EvaluateAsync(code, REvaluationKind.Normal);
                CheckEvaluationResult(result);
            }
        }

        private async Task EvalLibrariesAsync(IRSession session, string deparsedLibraries) {
            var code = string.Format(".libPaths(eval(parse(text={0})))", deparsedLibraries.ToRStringLiteral());
            using (var eval = await session.BeginEvaluationAsync()) {
                var result = await eval.EvaluateAsync(code, REvaluationKind.Normal);
                CheckEvaluationResult(result);
            }
        }

        private async Task<string> DeparseRepositoriesAsync() {
            var result = await _interactiveWorkflow.RSession.EvaluateAsync("rtvs:::deparse_str(getOption('repos'))", REvaluationKind.Normal);
            CheckEvaluationResult(result);
            return result.StringResult;
        }

        private async Task<string> DeparseLibrariesAsync() {
            var result = await _interactiveWorkflow.RSession.EvaluateAsync("rtvs:::deparse_str(.libPaths())", REvaluationKind.Normal);
            CheckEvaluationResult(result);
            return result.StringResult;
        }

        private void CheckEvaluationResult(REvaluationResult result) {
            if (result.ParseStatus != RParseStatus.OK) {
                throw new RPackageManagerException(Resources.PackageManager_EvalParseError, new InvalidOperationException(result.ToString()));
            }

            if (result.Error != null) {
                throw new RPackageManagerException(string.Format(Resources.PackageManager_EvalError, result.Error), new InvalidOperationException(result.ToString()));
            }
        }

        public void Dispose() {
            _sessionPool.Dispose();
            _dispose();
        }
    }
}
