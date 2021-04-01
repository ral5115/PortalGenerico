﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Infraestructura.Ws_GT_Pruebas {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="wsGenerarPlanoSoap", Namespace="http://generictransfer.com/")]
    public partial class wsGenerarPlano : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GenerarPlanoXMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback ImportarDatosXMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback ImportarDatosDSOperationCompleted;
        
        private System.Threading.SendOrPostCallback ImportarDatosTablasXMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback ImportarDatosTablasDSOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public wsGenerarPlano() {
            this.Url = global::Infraestructura.Properties.Settings.Default.Infraestructura_Ws_GT_Pruebas_wsGenerarPlano;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GenerarPlanoXMLCompletedEventHandler GenerarPlanoXMLCompleted;
        
        /// <remarks/>
        public event ImportarDatosXMLCompletedEventHandler ImportarDatosXMLCompleted;
        
        /// <remarks/>
        public event ImportarDatosDSCompletedEventHandler ImportarDatosDSCompleted;
        
        /// <remarks/>
        public event ImportarDatosTablasXMLCompletedEventHandler ImportarDatosTablasXMLCompleted;
        
        /// <remarks/>
        public event ImportarDatosTablasDSCompletedEventHandler ImportarDatosTablasDSCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/GenerarPlanoXML", RequestNamespace="http://generictransfer.com/", ResponseNamespace="http://generictransfer.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GenerarPlanoXML(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, ref string Path, ref string strResultado) {
            object[] results = this.Invoke("GenerarPlanoXML", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        dsFuenteDatos,
                        Path,
                        strResultado});
            Path = ((string)(results[1]));
            strResultado = ((string)(results[2]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GenerarPlanoXMLAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string Path, string strResultado) {
            this.GenerarPlanoXMLAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path, strResultado, null);
        }
        
        /// <remarks/>
        public void GenerarPlanoXMLAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string Path, string strResultado, object userState) {
            if ((this.GenerarPlanoXMLOperationCompleted == null)) {
                this.GenerarPlanoXMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGenerarPlanoXMLOperationCompleted);
            }
            this.InvokeAsync("GenerarPlanoXML", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        dsFuenteDatos,
                        Path,
                        strResultado}, this.GenerarPlanoXMLOperationCompleted, userState);
        }
        
        private void OnGenerarPlanoXMLOperationCompleted(object arg) {
            if ((this.GenerarPlanoXMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GenerarPlanoXMLCompleted(this, new GenerarPlanoXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosXML", RequestNamespace="http://generictransfer.com/", ResponseNamespace="http://generictransfer.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ImportarDatosXML(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, string strFuenteDatos, ref string Path) {
            object[] results = this.Invoke("ImportarDatosXML", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        strFuenteDatos,
                        Path});
            Path = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ImportarDatosXMLAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, string strFuenteDatos, string Path) {
            this.ImportarDatosXMLAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, Path, null);
        }
        
        /// <remarks/>
        public void ImportarDatosXMLAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, string strFuenteDatos, string Path, object userState) {
            if ((this.ImportarDatosXMLOperationCompleted == null)) {
                this.ImportarDatosXMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnImportarDatosXMLOperationCompleted);
            }
            this.InvokeAsync("ImportarDatosXML", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        strFuenteDatos,
                        Path}, this.ImportarDatosXMLOperationCompleted, userState);
        }
        
        private void OnImportarDatosXMLOperationCompleted(object arg) {
            if ((this.ImportarDatosXMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ImportarDatosXMLCompleted(this, new ImportarDatosXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosDS", RequestNamespace="http://generictransfer.com/", ResponseNamespace="http://generictransfer.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ImportarDatosDS(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, ref string Path) {
            object[] results = this.Invoke("ImportarDatosDS", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        dsFuenteDatos,
                        Path});
            Path = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ImportarDatosDSAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string Path) {
            this.ImportarDatosDSAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path, null);
        }
        
        /// <remarks/>
        public void ImportarDatosDSAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string Path, object userState) {
            if ((this.ImportarDatosDSOperationCompleted == null)) {
                this.ImportarDatosDSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnImportarDatosDSOperationCompleted);
            }
            this.InvokeAsync("ImportarDatosDS", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        dsFuenteDatos,
                        Path}, this.ImportarDatosDSOperationCompleted, userState);
        }
        
        private void OnImportarDatosDSOperationCompleted(object arg) {
            if ((this.ImportarDatosDSCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ImportarDatosDSCompleted(this, new ImportarDatosDSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosTablasXML", RequestNamespace="http://generictransfer.com/", ResponseNamespace="http://generictransfer.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ImportarDatosTablasXML(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, string strFuenteDatos, string tsProceso, ref string Path) {
            object[] results = this.Invoke("ImportarDatosTablasXML", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        strFuenteDatos,
                        tsProceso,
                        Path});
            Path = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ImportarDatosTablasXMLAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, string strFuenteDatos, string tsProceso, string Path) {
            this.ImportarDatosTablasXMLAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, tsProceso, Path, null);
        }
        
        /// <remarks/>
        public void ImportarDatosTablasXMLAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, string strFuenteDatos, string tsProceso, string Path, object userState) {
            if ((this.ImportarDatosTablasXMLOperationCompleted == null)) {
                this.ImportarDatosTablasXMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnImportarDatosTablasXMLOperationCompleted);
            }
            this.InvokeAsync("ImportarDatosTablasXML", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        strFuenteDatos,
                        tsProceso,
                        Path}, this.ImportarDatosTablasXMLOperationCompleted, userState);
        }
        
        private void OnImportarDatosTablasXMLOperationCompleted(object arg) {
            if ((this.ImportarDatosTablasXMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ImportarDatosTablasXMLCompleted(this, new ImportarDatosTablasXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosTablasDS", RequestNamespace="http://generictransfer.com/", ResponseNamespace="http://generictransfer.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ImportarDatosTablasDS(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string tsProceso, ref string Path) {
            object[] results = this.Invoke("ImportarDatosTablasDS", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        dsFuenteDatos,
                        tsProceso,
                        Path});
            Path = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ImportarDatosTablasDSAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string tsProceso, string Path) {
            this.ImportarDatosTablasDSAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, tsProceso, Path, null);
        }
        
        /// <remarks/>
        public void ImportarDatosTablasDSAsync(int idDocumento, string strNombreDocumento, int idCompania, string strCompania, string strUsuario, string strClave, System.Data.DataSet dsFuenteDatos, string tsProceso, string Path, object userState) {
            if ((this.ImportarDatosTablasDSOperationCompleted == null)) {
                this.ImportarDatosTablasDSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnImportarDatosTablasDSOperationCompleted);
            }
            this.InvokeAsync("ImportarDatosTablasDS", new object[] {
                        idDocumento,
                        strNombreDocumento,
                        idCompania,
                        strCompania,
                        strUsuario,
                        strClave,
                        dsFuenteDatos,
                        tsProceso,
                        Path}, this.ImportarDatosTablasDSOperationCompleted, userState);
        }
        
        private void OnImportarDatosTablasDSOperationCompleted(object arg) {
            if ((this.ImportarDatosTablasDSCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ImportarDatosTablasDSCompleted(this, new ImportarDatosTablasDSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GenerarPlanoXMLCompletedEventHandler(object sender, GenerarPlanoXMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GenerarPlanoXMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GenerarPlanoXMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string Path {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string strResultado {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ImportarDatosXMLCompletedEventHandler(object sender, ImportarDatosXMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ImportarDatosXMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ImportarDatosXMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string Path {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ImportarDatosDSCompletedEventHandler(object sender, ImportarDatosDSCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ImportarDatosDSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ImportarDatosDSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string Path {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ImportarDatosTablasXMLCompletedEventHandler(object sender, ImportarDatosTablasXMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ImportarDatosTablasXMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ImportarDatosTablasXMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string Path {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ImportarDatosTablasDSCompletedEventHandler(object sender, ImportarDatosTablasDSCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ImportarDatosTablasDSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ImportarDatosTablasDSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string Path {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591