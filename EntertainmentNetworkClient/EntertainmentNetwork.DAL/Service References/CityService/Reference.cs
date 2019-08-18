﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntertainmentNetwork.DAL.CityService {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/")]
    public partial class ServiceException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", ConfigurationName="CityService.CityService")]
    public interface CityService {
        
        // CODEGEN: Parameter 'arg0' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/rem" +
            "oveCityRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/rem" +
            "oveCityResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EntertainmentNetwork.DAL.CityService.ServiceException), Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/rem" +
            "oveCity/Fault/ServiceException", Name="ServiceException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        EntertainmentNetwork.DAL.CityService.removeCityResponse removeCity(EntertainmentNetwork.DAL.CityService.removeCityRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/rem" +
            "oveCityRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/rem" +
            "oveCityResponse")]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.removeCityResponse> removeCityAsync(EntertainmentNetwork.DAL.CityService.removeCityRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/get" +
            "CitiesRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/get" +
            "CitiesResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        EntertainmentNetwork.DAL.CityService.getCitiesResponse getCities(EntertainmentNetwork.DAL.CityService.getCitiesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/get" +
            "CitiesRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/get" +
            "CitiesResponse")]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.getCitiesResponse> getCitiesAsync(EntertainmentNetwork.DAL.CityService.getCitiesRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/sav" +
            "eCitiesRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/sav" +
            "eCitiesResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        EntertainmentNetwork.DAL.CityService.saveCitiesResponse saveCities(EntertainmentNetwork.DAL.CityService.saveCitiesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/sav" +
            "eCitiesRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/sav" +
            "eCitiesResponse")]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.saveCitiesResponse> saveCitiesAsync(EntertainmentNetwork.DAL.CityService.saveCitiesRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/fin" +
            "dCityByIdRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/fin" +
            "dCityByIdResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        EntertainmentNetwork.DAL.CityService.findCityByIdResponse findCityById(EntertainmentNetwork.DAL.CityService.findCityByIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/fin" +
            "dCityByIdRequest", ReplyAction="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/CityService/fin" +
            "dCityByIdResponse")]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.findCityByIdResponse> findCityByIdAsync(EntertainmentNetwork.DAL.CityService.findCityByIdRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="removeCity", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class removeCityRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal arg0;
        
        public removeCityRequest() {
        }
        
        public removeCityRequest(decimal arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="removeCityResponse", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class removeCityResponse {
        
        public removeCityResponse() {
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/")]
    public partial class city : baseModel {
        
        private string citCountryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string citCountry {
            get {
                return this.citCountryField;
            }
            set {
                this.citCountryField = value;
                this.RaisePropertyChanged("citCountry");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(city))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/")]
    public partial class baseModel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private decimal idField;
        
        private bool idFieldSpecified;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public decimal id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
                this.RaisePropertyChanged("idSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getCities", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class getCitiesRequest {
        
        public getCitiesRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getCitiesResponse", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class getCitiesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EntertainmentNetwork.DAL.CityService.city[] @return;
        
        public getCitiesResponse() {
        }
        
        public getCitiesResponse(EntertainmentNetwork.DAL.CityService.city[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="saveCities", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class saveCitiesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("arg0", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EntertainmentNetwork.DAL.CityService.city[] arg0;
        
        public saveCitiesRequest() {
        }
        
        public saveCitiesRequest(EntertainmentNetwork.DAL.CityService.city[] arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="saveCitiesResponse", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class saveCitiesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EntertainmentNetwork.DAL.CityService.city[] @return;
        
        public saveCitiesResponse() {
        }
        
        public saveCitiesResponse(EntertainmentNetwork.DAL.CityService.city[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findCityById", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class findCityByIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal arg0;
        
        public findCityByIdRequest() {
        }
        
        public findCityByIdRequest(decimal arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findCityByIdResponse", WrapperNamespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", IsWrapped=true)]
    public partial class findCityByIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CityServices.Services.EntertainmentNetworkServer.ua.git.dev/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EntertainmentNetwork.DAL.CityService.city[] @return;
        
        public findCityByIdResponse() {
        }
        
        public findCityByIdResponse(EntertainmentNetwork.DAL.CityService.city[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CityServiceChannel : EntertainmentNetwork.DAL.CityService.CityService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CityServiceClient : System.ServiceModel.ClientBase<EntertainmentNetwork.DAL.CityService.CityService>, EntertainmentNetwork.DAL.CityService.CityService {
        
        public CityServiceClient() {
        }
        
        public CityServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CityServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EntertainmentNetwork.DAL.CityService.removeCityResponse EntertainmentNetwork.DAL.CityService.CityService.removeCity(EntertainmentNetwork.DAL.CityService.removeCityRequest request) {
            return base.Channel.removeCity(request);
        }
        
        public void removeCity(decimal arg0) {
            EntertainmentNetwork.DAL.CityService.removeCityRequest inValue = new EntertainmentNetwork.DAL.CityService.removeCityRequest();
            inValue.arg0 = arg0;
            EntertainmentNetwork.DAL.CityService.removeCityResponse retVal = ((EntertainmentNetwork.DAL.CityService.CityService)(this)).removeCity(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.removeCityResponse> EntertainmentNetwork.DAL.CityService.CityService.removeCityAsync(EntertainmentNetwork.DAL.CityService.removeCityRequest request) {
            return base.Channel.removeCityAsync(request);
        }
        
        public System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.removeCityResponse> removeCityAsync(decimal arg0) {
            EntertainmentNetwork.DAL.CityService.removeCityRequest inValue = new EntertainmentNetwork.DAL.CityService.removeCityRequest();
            inValue.arg0 = arg0;
            return ((EntertainmentNetwork.DAL.CityService.CityService)(this)).removeCityAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EntertainmentNetwork.DAL.CityService.getCitiesResponse EntertainmentNetwork.DAL.CityService.CityService.getCities(EntertainmentNetwork.DAL.CityService.getCitiesRequest request) {
            return base.Channel.getCities(request);
        }
        
        public EntertainmentNetwork.DAL.CityService.city[] getCities() {
            EntertainmentNetwork.DAL.CityService.getCitiesRequest inValue = new EntertainmentNetwork.DAL.CityService.getCitiesRequest();
            EntertainmentNetwork.DAL.CityService.getCitiesResponse retVal = ((EntertainmentNetwork.DAL.CityService.CityService)(this)).getCities(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.getCitiesResponse> EntertainmentNetwork.DAL.CityService.CityService.getCitiesAsync(EntertainmentNetwork.DAL.CityService.getCitiesRequest request) {
            return base.Channel.getCitiesAsync(request);
        }
        
        public System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.getCitiesResponse> getCitiesAsync() {
            EntertainmentNetwork.DAL.CityService.getCitiesRequest inValue = new EntertainmentNetwork.DAL.CityService.getCitiesRequest();
            return ((EntertainmentNetwork.DAL.CityService.CityService)(this)).getCitiesAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EntertainmentNetwork.DAL.CityService.saveCitiesResponse EntertainmentNetwork.DAL.CityService.CityService.saveCities(EntertainmentNetwork.DAL.CityService.saveCitiesRequest request) {
            return base.Channel.saveCities(request);
        }
        
        public EntertainmentNetwork.DAL.CityService.city[] saveCities(EntertainmentNetwork.DAL.CityService.city[] arg0) {
            EntertainmentNetwork.DAL.CityService.saveCitiesRequest inValue = new EntertainmentNetwork.DAL.CityService.saveCitiesRequest();
            inValue.arg0 = arg0;
            EntertainmentNetwork.DAL.CityService.saveCitiesResponse retVal = ((EntertainmentNetwork.DAL.CityService.CityService)(this)).saveCities(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.saveCitiesResponse> EntertainmentNetwork.DAL.CityService.CityService.saveCitiesAsync(EntertainmentNetwork.DAL.CityService.saveCitiesRequest request) {
            return base.Channel.saveCitiesAsync(request);
        }
        
        public System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.saveCitiesResponse> saveCitiesAsync(EntertainmentNetwork.DAL.CityService.city[] arg0) {
            EntertainmentNetwork.DAL.CityService.saveCitiesRequest inValue = new EntertainmentNetwork.DAL.CityService.saveCitiesRequest();
            inValue.arg0 = arg0;
            return ((EntertainmentNetwork.DAL.CityService.CityService)(this)).saveCitiesAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EntertainmentNetwork.DAL.CityService.findCityByIdResponse EntertainmentNetwork.DAL.CityService.CityService.findCityById(EntertainmentNetwork.DAL.CityService.findCityByIdRequest request) {
            return base.Channel.findCityById(request);
        }
        
        public EntertainmentNetwork.DAL.CityService.city[] findCityById(decimal arg0) {
            EntertainmentNetwork.DAL.CityService.findCityByIdRequest inValue = new EntertainmentNetwork.DAL.CityService.findCityByIdRequest();
            inValue.arg0 = arg0;
            EntertainmentNetwork.DAL.CityService.findCityByIdResponse retVal = ((EntertainmentNetwork.DAL.CityService.CityService)(this)).findCityById(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.findCityByIdResponse> EntertainmentNetwork.DAL.CityService.CityService.findCityByIdAsync(EntertainmentNetwork.DAL.CityService.findCityByIdRequest request) {
            return base.Channel.findCityByIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EntertainmentNetwork.DAL.CityService.findCityByIdResponse> findCityByIdAsync(decimal arg0) {
            EntertainmentNetwork.DAL.CityService.findCityByIdRequest inValue = new EntertainmentNetwork.DAL.CityService.findCityByIdRequest();
            inValue.arg0 = arg0;
            return ((EntertainmentNetwork.DAL.CityService.CityService)(this)).findCityByIdAsync(inValue);
        }
    }
}