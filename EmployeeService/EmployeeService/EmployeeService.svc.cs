using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeOperationService : IAddEmployeeService, IGetEmployeeService
    {
        private static List<Employee> _employeeList = new List<Employee>();

        public void AddRemarks(int employeeId, string remark)
        {

            Console.WriteLine("Added the remark");
        }

        public void CreateEmployee(int id, string name)
        {
            Employee employee = null;
            if (!IsEmployeeIdExists(id))
            {
                employee = new Employee();
                employee.id = id;
                employee.Name = name;
                _employeeList.Add(employee);
                Console.WriteLine("Created the employee");
            }
            else
            {
                throw new Exception("The employee with the given id already exists");
            }
        }

        public Employee GetEmployeeDetails(int employeeId)
        {
            Console.WriteLine("Got Employe for your employee id");
            return null;
        }

        public Employee GetEmployeeDetails(string employeeName)
        {
            Console.WriteLine("Got Employe for your employee by name");
            return null;
        }

        public List<Employee> GetAllEmployees()
        {
            Console.WriteLine("Got All of your employees");
            return null;
        }

        private bool IsEmployeeIdExists(int employeeId)
        {
            return _employeeList.Any(employee => employee.id == employeeId);
        }

        public static int GetEmployeeCount() {
            return _employeeList.Count;
        }
    }
}
