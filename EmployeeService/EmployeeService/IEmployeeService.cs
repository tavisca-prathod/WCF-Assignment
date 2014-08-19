using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAddEmployeeService
    {

        //Add Remarks
        [OperationContract]
        [FaultContract(typeof(EmployeeServiceException))]
        void AddRemarks(int employeeId, string remark);
        //Create employee
        [OperationContract]
        [FaultContract(typeof(EmployeeServiceException))]
        void CreateEmployee(int id, string name);
    }

    [ServiceContract]
    public interface IGetEmployeeService {

        [OperationContract(Name = "GetEmployeeDetailsById")]
        [FaultContract(typeof(EmployeeServiceException))]
        Employee GetEmployeeDetails(int employeeId);

        [OperationContract(Name = "GetEmployeeDetailsByName")]
        [FaultContract(typeof(EmployeeServiceException))]
        Employee GetEmployeeDetails(string employeeName);

        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract]
        IEnumerable<Employee> GetEmployeesWithRemarks();

        [OperationContract]
        void DeleteAllEMployees();

        [OperationContract]
        int GetEmployeeCount();

        [OperationContract]
        int GetRemarksCount();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class Remarks
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string Remark { get; set; }
    }

    [DataContract]
    public class EmployeeServiceException {

        [DataMember]
        public int FaultId { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
