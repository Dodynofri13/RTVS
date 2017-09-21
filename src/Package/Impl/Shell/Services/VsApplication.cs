﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using Microsoft.Common.Core;
using Microsoft.Common.Core.Services;
using Microsoft.Common.Core.Shell;
using Microsoft.Common.Core.Testing;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.R.Package.Shell {
    internal sealed class VsApplication : IApplication {
        internal static string Name => TestEnvironment.Current != null ? "RTVS_Test" : "RTVS";

        #region IApplication
        string IApplication.Name => Name;
        public int LocaleId { get; }

        /// <summary>
        /// Fires when host application has completed it's startup sequence
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        /// Fires when host application is terminating
        /// </summary>
        public event EventHandler Terminating;
        #endregion

        public VsApplication(IServiceContainer services) {
            var hostLocale = services.GetService<IUIHostLocale>(typeof(SUIHostLocale));
            hostLocale.GetUILocale(out var lcid);
            LocaleId = (int)lcid;
        }

        internal void FireStarted() => Started?.Invoke(this, EventArgs.Empty);
        internal void FireTerminating() => Terminating?.Invoke(this, EventArgs.Empty);
    }
}
