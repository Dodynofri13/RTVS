﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.R.Host.Monitor {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.R.Host.Monitor.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Change User.
        /// </summary>
        public static string Btn_AddOrChangeBrokerUser {
            get {
                return ResourceManager.GetString("Btn_AddOrChangeBrokerUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove User.
        /// </summary>
        public static string Btn_RemoveBrokerUser {
            get {
                return ResourceManager.GetString("Btn_RemoveBrokerUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Broker.
        /// </summary>
        public static string Btn_StartBroker {
            get {
                return ResourceManager.GetString("Btn_StartBroker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stop Broker.
        /// </summary>
        public static string Btn_StopBroker {
            get {
                return ResourceManager.GetString("Btn_StopBroker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add or change user failed with exception: {0}.
        /// </summary>
        public static string Error_AddOrChangeUserFailed {
            get {
                return ResourceManager.GetString("Error_AddOrChangeUserFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Auto restart Broker failed , exception: {0}.
        /// </summary>
        public static string Error_AutoRestartFailed {
            get {
                return ResourceManager.GetString("Error_AutoRestartFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to parse credential data with Win32 error {0}..
        /// </summary>
        public static string Error_CredentialData {
            get {
                return ResourceManager.GetString("Error_CredentialData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User credential unpacking failed with Win32 error {0}..
        /// </summary>
        public static string Error_CredentialUnpackingFailed {
            get {
                return ResourceManager.GetString("Error_CredentialUnpackingFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to retrieve credentials from credential manager, with Win32 error {0}..
        /// </summary>
        public static string Error_CredRetreiveFailed {
            get {
                return ResourceManager.GetString("Error_CredRetreiveFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Credential save failed with Win32 error {0}..
        /// </summary>
        public static string Error_CredSaveFailed {
            get {
                return ResourceManager.GetString("Error_CredSaveFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CredUIPromptForWindowsCredentials failed to load, with error: {0}.
        /// </summary>
        public static string Error_CredUIFailedToLoad {
            get {
                return ResourceManager.GetString("Error_CredUIFailedToLoad", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log on attempt failed, with Win32 error {0}..
        /// </summary>
        public static string Error_LogOnAttemptFailed {
            get {
                return ResourceManager.GetString("Error_LogOnAttemptFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Startup failed with exception: {0}.
        /// </summary>
        public static string Error_StartUpFailed {
            get {
                return ResourceManager.GetString("Error_StartUpFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stop Broker failed , exception: {0}.
        /// </summary>
        public static string Error_StopBrokerFailed {
            get {
                return ResourceManager.GetString("Error_StopBrokerFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to parse user name with Win32 error {0}..
        /// </summary>
        public static string Error_UserNameParsing {
            get {
                return ResourceManager.GetString("Error_UserNameParsing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Broker is already running, process id {0}..
        /// </summary>
        public static string Info_BrokerAlreadyRunning {
            get {
                return ResourceManager.GetString("Info_BrokerAlreadyRunning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trying to acquire credentials, attempt {0}..
        /// </summary>
        public static string Info_CredAttempt {
            get {
                return ResourceManager.GetString("Info_CredAttempt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully retrieved credentials from credential manager..
        /// </summary>
        public static string Info_CredRetreiveSucceeded {
            get {
                return ResourceManager.GetString("Info_CredRetreiveSucceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Credential save succeeded..
        /// </summary>
        public static string Info_CredSaveSucceeded {
            get {
                return ResourceManager.GetString("Info_CredSaveSucceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User entered credentials..
        /// </summary>
        public static string Info_CredUICredsReceived {
            get {
                return ResourceManager.GetString("Info_CredUICredsReceived", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User dismissed Credential UI without entering credentials..
        /// </summary>
        public static string Info_CredUIDismissed {
            get {
                return ResourceManager.GetString("Info_CredUIDismissed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User credentials were successfully unpacked..
        /// </summary>
        public static string Info_CredUnpacked {
            get {
                return ResourceManager.GetString("Info_CredUnpacked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Broker is configured to run as a different user than the Monitor. Broker user credential were not found..
        /// </summary>
        public static string Info_DidNotFindSavedCredentails {
            get {
                return ResourceManager.GetString("Info_DidNotFindSavedCredentails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log on attempt succeeded..
        /// </summary>
        public static string Info_LogOnAttemptSucceeded {
            get {
                return ResourceManager.GetString("Info_LogOnAttemptSucceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New Broker instance started, process id {0}..
        /// </summary>
        public static string Info_NewBrokerInstanceStarted {
            get {
                return ResourceManager.GetString("Info_NewBrokerInstanceStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removed credentials from credential manager..
        /// </summary>
        public static string Info_RemovedCredentials {
            get {
                return ResourceManager.GetString("Info_RemovedCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to too many attempts to add Broker user login credentials..
        /// </summary>
        public static string Info_TooManyLoginAttempts {
            get {
                return ResourceManager.GetString("Info_TooManyLoginAttempts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add or change the credentials which will be used to run R Host Broker..
        /// </summary>
        public static string Text_AddOrChangeBrokerUser {
            get {
                return ResourceManager.GetString("Text_AddOrChangeBrokerUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removes the credentials used for R Host Broker..
        /// </summary>
        public static string Text_RemoveBrokerUser {
            get {
                return ResourceManager.GetString("Text_RemoveBrokerUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to R Host Broker Credentials.
        /// </summary>
        public static string Text_RHostBrokerCredentials {
            get {
                return ResourceManager.GetString("Text_RHostBrokerCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The credentials entered below will be used to start the R Host Broker Process. If you choose to save the credentials monitor will automatically start the broker process..
        /// </summary>
        public static string Text_RHostBrokerCredentialsDetail {
            get {
                return ResourceManager.GetString("Text_RHostBrokerCredentialsDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user could not be logged in on this machine, please try again. The credentials entered below will be used to start the R Host Broker Process. If you choose to save the credentials monitor will automatically start the broker process..
        /// </summary>
        public static string Text_RHostBrokerCredentialsInvalidTryAgain {
            get {
                return ResourceManager.GetString("Text_RHostBrokerCredentialsInvalidTryAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starts and monitors an instance of the R Host Broker..
        /// </summary>
        public static string Text_StartBroker {
            get {
                return ResourceManager.GetString("Text_StartBroker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stops the monitored R Host Broker instance..
        /// </summary>
        public static string Text_StopBroker {
            get {
                return ResourceManager.GetString("Text_StopBroker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use a different user to run the Broker..
        /// </summary>
        public static string Text_UseDifferentBroker {
            get {
                return ResourceManager.GetString("Text_UseDifferentBroker", resourceCulture);
            }
        }
    }
}