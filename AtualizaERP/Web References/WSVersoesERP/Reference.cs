﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace AtualizaERP.WSVersoesERP {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VersoesERPSoap", Namespace="controllernet")]
    public partial class VersoesERP : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CadNovaVersaoOperationCompleted;
        
        private System.Threading.SendOrPostCallback ListAllVersionsOperationCompleted;
        
        private System.Threading.SendOrPostCallback VersionByNameOperationCompleted;
        
        private System.Threading.SendOrPostCallback VersionByCodOperationCompleted;
        
        private System.Threading.SendOrPostCallback LastVersionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetClienteOperationCompleted;
        
        private System.Threading.SendOrPostCallback CadClienteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public VersoesERP() {
            this.Url = global::AtualizaERP.Properties.Settings.Default.AtualizaERP_WSVersoesERP_VersoesERP;
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
        public event CadNovaVersaoCompletedEventHandler CadNovaVersaoCompleted;
        
        /// <remarks/>
        public event ListAllVersionsCompletedEventHandler ListAllVersionsCompleted;
        
        /// <remarks/>
        public event VersionByNameCompletedEventHandler VersionByNameCompleted;
        
        /// <remarks/>
        public event VersionByCodCompletedEventHandler VersionByCodCompleted;
        
        /// <remarks/>
        public event LastVersionCompletedEventHandler LastVersionCompleted;
        
        /// <remarks/>
        public event GetClienteCompletedEventHandler GetClienteCompleted;
        
        /// <remarks/>
        public event CadClienteCompletedEventHandler CadClienteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/CadNovaVersao", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CadNovaVersao(Versao Versao, int caso) {
            object[] results = this.Invoke("CadNovaVersao", new object[] {
                        Versao,
                        caso});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CadNovaVersaoAsync(Versao Versao, int caso) {
            this.CadNovaVersaoAsync(Versao, caso, null);
        }
        
        /// <remarks/>
        public void CadNovaVersaoAsync(Versao Versao, int caso, object userState) {
            if ((this.CadNovaVersaoOperationCompleted == null)) {
                this.CadNovaVersaoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCadNovaVersaoOperationCompleted);
            }
            this.InvokeAsync("CadNovaVersao", new object[] {
                        Versao,
                        caso}, this.CadNovaVersaoOperationCompleted, userState);
        }
        
        private void OnCadNovaVersaoOperationCompleted(object arg) {
            if ((this.CadNovaVersaoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CadNovaVersaoCompleted(this, new CadNovaVersaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/ListAllVersions", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Versao[] ListAllVersions() {
            object[] results = this.Invoke("ListAllVersions", new object[0]);
            return ((Versao[])(results[0]));
        }
        
        /// <remarks/>
        public void ListAllVersionsAsync() {
            this.ListAllVersionsAsync(null);
        }
        
        /// <remarks/>
        public void ListAllVersionsAsync(object userState) {
            if ((this.ListAllVersionsOperationCompleted == null)) {
                this.ListAllVersionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListAllVersionsOperationCompleted);
            }
            this.InvokeAsync("ListAllVersions", new object[0], this.ListAllVersionsOperationCompleted, userState);
        }
        
        private void OnListAllVersionsOperationCompleted(object arg) {
            if ((this.ListAllVersionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListAllVersionsCompleted(this, new ListAllVersionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/VersionByName", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Versao[] VersionByName(string name) {
            object[] results = this.Invoke("VersionByName", new object[] {
                        name});
            return ((Versao[])(results[0]));
        }
        
        /// <remarks/>
        public void VersionByNameAsync(string name) {
            this.VersionByNameAsync(name, null);
        }
        
        /// <remarks/>
        public void VersionByNameAsync(string name, object userState) {
            if ((this.VersionByNameOperationCompleted == null)) {
                this.VersionByNameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVersionByNameOperationCompleted);
            }
            this.InvokeAsync("VersionByName", new object[] {
                        name}, this.VersionByNameOperationCompleted, userState);
        }
        
        private void OnVersionByNameOperationCompleted(object arg) {
            if ((this.VersionByNameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VersionByNameCompleted(this, new VersionByNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/VersionByCod", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Versao VersionByCod(int cod) {
            object[] results = this.Invoke("VersionByCod", new object[] {
                        cod});
            return ((Versao)(results[0]));
        }
        
        /// <remarks/>
        public void VersionByCodAsync(int cod) {
            this.VersionByCodAsync(cod, null);
        }
        
        /// <remarks/>
        public void VersionByCodAsync(int cod, object userState) {
            if ((this.VersionByCodOperationCompleted == null)) {
                this.VersionByCodOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVersionByCodOperationCompleted);
            }
            this.InvokeAsync("VersionByCod", new object[] {
                        cod}, this.VersionByCodOperationCompleted, userState);
        }
        
        private void OnVersionByCodOperationCompleted(object arg) {
            if ((this.VersionByCodCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VersionByCodCompleted(this, new VersionByCodCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/LastVersion", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Versao LastVersion() {
            object[] results = this.Invoke("LastVersion", new object[0]);
            return ((Versao)(results[0]));
        }
        
        /// <remarks/>
        public void LastVersionAsync() {
            this.LastVersionAsync(null);
        }
        
        /// <remarks/>
        public void LastVersionAsync(object userState) {
            if ((this.LastVersionOperationCompleted == null)) {
                this.LastVersionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLastVersionOperationCompleted);
            }
            this.InvokeAsync("LastVersion", new object[0], this.LastVersionOperationCompleted, userState);
        }
        
        private void OnLastVersionOperationCompleted(object arg) {
            if ((this.LastVersionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LastVersionCompleted(this, new LastVersionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/GetCliente", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Cliente GetCliente(string doc) {
            object[] results = this.Invoke("GetCliente", new object[] {
                        doc});
            return ((Cliente)(results[0]));
        }
        
        /// <remarks/>
        public void GetClienteAsync(string doc) {
            this.GetClienteAsync(doc, null);
        }
        
        /// <remarks/>
        public void GetClienteAsync(string doc, object userState) {
            if ((this.GetClienteOperationCompleted == null)) {
                this.GetClienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetClienteOperationCompleted);
            }
            this.InvokeAsync("GetCliente", new object[] {
                        doc}, this.GetClienteOperationCompleted, userState);
        }
        
        private void OnGetClienteOperationCompleted(object arg) {
            if ((this.GetClienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetClienteCompleted(this, new GetClienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("controllernet/CadCliente", RequestNamespace="controllernet", ResponseNamespace="controllernet", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CadCliente(Cliente Cli, int caso) {
            object[] results = this.Invoke("CadCliente", new object[] {
                        Cli,
                        caso});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CadClienteAsync(Cliente Cli, int caso) {
            this.CadClienteAsync(Cli, caso, null);
        }
        
        /// <remarks/>
        public void CadClienteAsync(Cliente Cli, int caso, object userState) {
            if ((this.CadClienteOperationCompleted == null)) {
                this.CadClienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCadClienteOperationCompleted);
            }
            this.InvokeAsync("CadCliente", new object[] {
                        Cli,
                        caso}, this.CadClienteOperationCompleted, userState);
        }
        
        private void OnCadClienteOperationCompleted(object arg) {
            if ((this.CadClienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CadClienteCompleted(this, new CadClienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="controllernet")]
    public partial class Versao {
        
        private int idVersaoField;
        
        private int codVersaoField;
        
        private string descVersaoField;
        
        private string dataVersaoField;
        
        private string impactDBField;
        
        private string uRLVersaoField;
        
        private string uRLReleaseField;
        
        /// <remarks/>
        public int IdVersao {
            get {
                return this.idVersaoField;
            }
            set {
                this.idVersaoField = value;
            }
        }
        
        /// <remarks/>
        public int CodVersao {
            get {
                return this.codVersaoField;
            }
            set {
                this.codVersaoField = value;
            }
        }
        
        /// <remarks/>
        public string DescVersao {
            get {
                return this.descVersaoField;
            }
            set {
                this.descVersaoField = value;
            }
        }
        
        /// <remarks/>
        public string DataVersao {
            get {
                return this.dataVersaoField;
            }
            set {
                this.dataVersaoField = value;
            }
        }
        
        /// <remarks/>
        public string ImpactDB {
            get {
                return this.impactDBField;
            }
            set {
                this.impactDBField = value;
            }
        }
        
        /// <remarks/>
        public string URLVersao {
            get {
                return this.uRLVersaoField;
            }
            set {
                this.uRLVersaoField = value;
            }
        }
        
        /// <remarks/>
        public string URLRelease {
            get {
                return this.uRLReleaseField;
            }
            set {
                this.uRLReleaseField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="controllernet")]
    public partial class Cliente {
        
        private int clienteIdField;
        
        private string docClienteField;
        
        private string nomeClienteField;
        
        private string serieClienteField;
        
        private int versaoClienteField;
        
        private System.DateTime dataAtualizacaoField;
        
        /// <remarks/>
        public int ClienteId {
            get {
                return this.clienteIdField;
            }
            set {
                this.clienteIdField = value;
            }
        }
        
        /// <remarks/>
        public string DocCliente {
            get {
                return this.docClienteField;
            }
            set {
                this.docClienteField = value;
            }
        }
        
        /// <remarks/>
        public string NomeCliente {
            get {
                return this.nomeClienteField;
            }
            set {
                this.nomeClienteField = value;
            }
        }
        
        /// <remarks/>
        public string SerieCliente {
            get {
                return this.serieClienteField;
            }
            set {
                this.serieClienteField = value;
            }
        }
        
        /// <remarks/>
        public int VersaoCliente {
            get {
                return this.versaoClienteField;
            }
            set {
                this.versaoClienteField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DataAtualizacao {
            get {
                return this.dataAtualizacaoField;
            }
            set {
                this.dataAtualizacaoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void CadNovaVersaoCompletedEventHandler(object sender, CadNovaVersaoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CadNovaVersaoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CadNovaVersaoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void ListAllVersionsCompletedEventHandler(object sender, ListAllVersionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListAllVersionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListAllVersionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Versao[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Versao[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void VersionByNameCompletedEventHandler(object sender, VersionByNameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VersionByNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VersionByNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Versao[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Versao[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void VersionByCodCompletedEventHandler(object sender, VersionByCodCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VersionByCodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VersionByCodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Versao Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Versao)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void LastVersionCompletedEventHandler(object sender, LastVersionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LastVersionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LastVersionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Versao Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Versao)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void GetClienteCompletedEventHandler(object sender, GetClienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetClienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetClienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Cliente Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Cliente)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void CadClienteCompletedEventHandler(object sender, CadClienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CadClienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CadClienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    }
}

#pragma warning restore 1591