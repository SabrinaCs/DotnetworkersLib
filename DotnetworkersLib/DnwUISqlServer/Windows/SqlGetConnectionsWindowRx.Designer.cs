﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dnw.UI.SqlServer.Windows {
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
    public class SqlGetConnectionsWindowRx {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlGetConnectionsWindowRx() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Dnw.UI.SqlServer.Windows.SqlGetConnectionsWindowRx", typeof(SqlGetConnectionsWindowRx).Assembly);
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
        ///   Looks up a localized string similar to Export connection data.
        /// </summary>
        public static string txtSGCWExportTitle {
            get {
                return ResourceManager.GetString("txtSGCWExportTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Import connection data.
        /// </summary>
        public static string txtSGCWImportTitle {
            get {
                return ResourceManager.GetString("txtSGCWImportTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning!.
        /// </summary>
        public static string warGEN {
            get {
                return ResourceManager.GetString("warGEN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are unsaved changes do you wish to continue anyway?.
        /// </summary>
        public static string warSGCWDiscardChanges {
            get {
                return ResourceManager.GetString("warSGCWDiscardChanges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No file specified to load and save connections informations, this window will be closed..
        /// </summary>
        public static string warSGCWNoFileName {
            get {
                return ResourceManager.GetString("warSGCWNoFileName", resourceCulture);
            }
        }
    }
}
