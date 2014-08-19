﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeServiceTests.EmployeeTestServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeTestServiceReference.IAddEmployeeService")]
    public interface IAddEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/AddRemarks", ReplyAction="http://tempuri.org/IAddEmployeeService/AddRemarksResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeService.EmployeeServiceException), Action="http://tempuri.org/IAddEmployeeService/AddRemarksEmployeeServiceExceptionFault", Name="EmployeeServiceException", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        void AddRemarks(int employeeId, string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/AddRemarks", ReplyAction="http://tempuri.org/IAddEmployeeService/AddRemarksResponse")]
        System.Threading.Tasks.Task AddRemarksAsync(int employeeId, string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/IAddEmployeeService/CreateEmployeeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeService.EmployeeServiceException), Action="http://tempuri.org/IAddEmployeeService/CreateEmployeeEmployeeServiceExceptionFaul" +
            "t", Name="EmployeeServiceException", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        void CreateEmployee(int id, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/IAddEmployeeService/CreateEmployeeResponse")]
        System.Threading.Tasks.Task CreateEmployeeAsync(int id, string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAddEmployeeServiceChannel : EmployeeServiceTests.EmployeeTestServiceReference.IAddEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddEmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeServiceTests.EmployeeTestServiceReference.IAddEmployeeService>, EmployeeServiceTests.EmployeeTestServiceReference.IAddEmployeeService {
        
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
        
        public void AddRemarks(int employeeId, string remark) {
            base.Channel.AddRemarks(employeeId, remark);
        }
        
        public System.Threading.Tasks.Task AddRemarksAsync(int employeeId, string remark) {
            return base.Channel.AddRemarksAsync(employeeId, remark);
        }
        
        public void CreateEmployee(int id, string name) {
            base.Channel.CreateEmployee(id, name);
        }
        
        public System.Threading.Tasks.Task CreateEmployeeAsync(int id, string name) {
            return base.Channel.CreateEmployeeAsync(id, name);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeTestServiceReference.IGetEmployeeService")]
    public interface IGetEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsById", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeService.EmployeeServiceException), Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByIdEmployeeServiceExcep" +
            "tionFault", Name="EmployeeServiceException", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        EmployeeService.Employee GetEmployeeDetailsById(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsById", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByIdResponse")]
        System.Threading.Tasks.Task<EmployeeService.Employee> GetEmployeeDetailsByIdAsync(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByName", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeService.EmployeeServiceException), Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByNameEmployeeServiceExc" +
            "eptionFault", Name="EmployeeServiceException", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        EmployeeService.Employee GetEmployeeDetailsByName(string employeeName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByName", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeDetailsByNameResponse")]
        System.Threading.Tasks.Task<EmployeeService.Employee> GetEmployeeDetailsByNameAsync(string employeeName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IGetEmployeeService/GetAllEmployeesResponse")]
        EmployeeService.Employee[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IGetEmployeeService/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<EmployeeService.Employee[]> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeesWithRemarks", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeesWithRemarksResponse")]
        EmployeeService.Employee[] GetEmployeesWithRemarks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeesWithRemarks", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeesWithRemarksResponse")]
        System.Threading.Tasks.Task<EmployeeService.Employee[]> GetEmployeesWithRemarksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/DeleteAllEMployees", ReplyAction="http://tempuri.org/IGetEmployeeService/DeleteAllEMployeesResponse")]
        void DeleteAllEMployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/DeleteAllEMployees", ReplyAction="http://tempuri.org/IGetEmployeeService/DeleteAllEMployeesResponse")]
        System.Threading.Tasks.Task DeleteAllEMployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeCount", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeCountResponse")]
        int GetEmployeeCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetEmployeeCount", ReplyAction="http://tempuri.org/IGetEmployeeService/GetEmployeeCountResponse")]
        System.Threading.Tasks.Task<int> GetEmployeeCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetRemarksCount", ReplyAction="http://tempuri.org/IGetEmployeeService/GetRemarksCountResponse")]
        int GetRemarksCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeService/GetRemarksCount", ReplyAction="http://tempuri.org/IGetEmployeeService/GetRemarksCountResponse")]
        System.Threading.Tasks.Task<int> GetRemarksCountAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGetEmployeeServiceChannel : EmployeeServiceTests.EmployeeTestServiceReference.IGetEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetEmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeServiceTests.EmployeeTestServiceReference.IGetEmployeeService>, EmployeeServiceTests.EmployeeTestServiceReference.IGetEmployeeService {
        
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
        
        public EmployeeService.Employee GetEmployeeDetailsById(int employeeId) {
            return base.Channel.GetEmployeeDetailsById(employeeId);
        }
        
        public System.Threading.Tasks.Task<EmployeeService.Employee> GetEmployeeDetailsByIdAsync(int employeeId) {
            return base.Channel.GetEmployeeDetailsByIdAsync(employeeId);
        }
        
        public EmployeeService.Employee GetEmployeeDetailsByName(string employeeName) {
            return base.Channel.GetEmployeeDetailsByName(employeeName);
        }
        
        public System.Threading.Tasks.Task<EmployeeService.Employee> GetEmployeeDetailsByNameAsync(string employeeName) {
            return base.Channel.GetEmployeeDetailsByNameAsync(employeeName);
        }
        
        public EmployeeService.Employee[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<EmployeeService.Employee[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public EmployeeService.Employee[] GetEmployeesWithRemarks() {
            return base.Channel.GetEmployeesWithRemarks();
        }
        
        public System.Threading.Tasks.Task<EmployeeService.Employee[]> GetEmployeesWithRemarksAsync() {
            return base.Channel.GetEmployeesWithRemarksAsync();
        }
        
        public void DeleteAllEMployees() {
            base.Channel.DeleteAllEMployees();
        }
        
        public System.Threading.Tasks.Task DeleteAllEMployeesAsync() {
            return base.Channel.DeleteAllEMployeesAsync();
        }
        
        public int GetEmployeeCount() {
            return base.Channel.GetEmployeeCount();
        }
        
        public System.Threading.Tasks.Task<int> GetEmployeeCountAsync() {
            return base.Channel.GetEmployeeCountAsync();
        }
        
        public int GetRemarksCount() {
            return base.Channel.GetRemarksCount();
        }
        
        public System.Threading.Tasks.Task<int> GetRemarksCountAsync() {
            return base.Channel.GetRemarksCountAsync();
        }
    }
}
