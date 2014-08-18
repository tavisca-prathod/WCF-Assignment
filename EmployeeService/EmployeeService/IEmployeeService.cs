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
        void AddRemarks(int employeeId, string remark);
        //Create employee
        [OperationContract]
        void CreateEmployee(int id, string name);
    }

    [ServiceContract]
    public interface IGetEmployeeService {

        [OperationContract]
        Employee GetEmployeeDetails(int employeeId);

        Employee GetEmployeeDetails(string employeeName);

        [OperationContract]
        List<Employee> GetAllEmployees();

        IEnumerable<Employee> GetEmployeesWithRemarks();
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
        public int EmployeeId { get; set; }
        public DateTime DateTime { get; set; }
        public string Remark { get; set; }
    }
}
