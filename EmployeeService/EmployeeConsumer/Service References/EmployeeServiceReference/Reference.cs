﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeConsumer.EmployeeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Remarks", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class Remarks : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateTime {
            get {
                return this.DateTimeField;
            }
            set {
                if ((this.DateTimeField.Equals(value) != true)) {
                    this.DateTimeField = value;
                    this.RaisePropertyChanged("DateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmployeeId {
            get {
                return this.EmployeeIdField;
            }
            set {
                if ((this.EmployeeIdField.Equals(value) != true)) {
                    this.EmployeeIdField = value;
                    this.RaisePropertyChanged("EmployeeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.IAddEmployeeService")]
    public interface IAddEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/AddRemarks", ReplyAction="http://tempuri.org/IAddEmployeeService/AddRemarksResponse")]
        void AddRemarks(EmployeeConsumer.EmployeeServiceReference.Remarks remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/AddRemarks", ReplyAction="http://tempuri.org/IAddEmployeeService/AddRemarksResponse")]
        System.Threading.Tasks.Task AddRemarksAsync(EmployeeConsumer.EmployeeServiceReference.Remarks remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/IAddEmployeeService/CreateEmployeeResponse")]
        EmployeeConsumer.EmployeeServiceReference.Employee CreateEmployee(EmployeeConsumer.EmployeeServiceReference.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/IAddEmployeeService/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeServiceReference.Employee> CreateEmployeeAsync(EmployeeConsumer.EmployeeServiceReference.Employee employee);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAddEmployeeServiceChannel : EmployeeConsumer.EmployeeServiceReference.IAddEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddEmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeConsumer.EmployeeServiceReference.IAddEmployeeService>, EmployeeConsumer.EmployeeServiceReference.IAddEmployeeService {
        
        public AddEmployeeServiceClient() {
        }
        
        public AddEmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AddEmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddEmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddEmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddRemarks(EmployeeConsumer.EmployeeServiceReference.Remarks remark) {
            base.Channel.AddRemarks(remark);
        }
        
        public System.Threading.Tasks.Task AddRemarksAsync(EmployeeConsumer.EmployeeServiceReference.Remarks remark) {
            return base.Channel.AddRemarksAsync(remark);
        }
        
        public EmployeeConsumer.EmployeeServiceReference.Employee CreateEmployee(EmployeeConsumer.EmployeeServiceReference.Employee employee) {
            return base.Channel.CreateEmployee(employee);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeServiceReference.Employee> CreateEmployeeAsync(EmployeeConsumer.EmployeeServiceReference.Employee employee) {
            return base.Channel.CreateEmployeeAsync(employee);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.IGetEmployeeService")]
    public interface IGetEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetails", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsResponse")]
        EmployeeConsumer.EmployeeServiceReference.Employee GetEmployeeDetails(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetails", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeServiceReference.Employee> GetEmployeeDetailsAsync(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IGetEmployeeService/GetAllEmployeesResponse")]
        EmployeeConsumer.EmployeeServiceReference.Employee[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IGetEmployeeService/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeServiceReference.Employee[]> GetAllEmployeesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGetEmployeeServiceChannel : EmployeeConsumer.EmployeeServiceReference.IGetEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetEmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeConsumer.EmployeeServiceReference.IGetEmployeeService>, EmployeeConsumer.EmployeeServiceReference.IGetEmployeeService {
        
        public GetEmployeeServiceClient() {
        }
        
        public GetEmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetEmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetEmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetEmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeConsumer.EmployeeServiceReference.Employee GetEmployeeDetails(int employeeId) {
            return base.Channel.GetEmployeeDetails(employeeId);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeServiceReference.Employee> GetEmployeeDetailsAsync(int employeeId) {
            return base.Channel.GetEmployeeDetailsAsync(employeeId);
        }
        
        public EmployeeConsumer.EmployeeServiceReference.Employee[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeServiceReference.Employee[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
    }
}