﻿using System;
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
        private static List<Remarks> _remarksList = new List<Remarks>();

        public void AddRemarks(int employeeId, string remarkText)
        {
            if (IsEmployeeIdExists(employeeId))
            {
                Remarks remark = new Remarks();
                remark.DateTime = DateTime.UtcNow;
                remark.EmployeeId = employeeId;
                remark.Remark = remarkText;
                _remarksList.Add(remark);
            }
            else
            {
               throw new FaultException<EmployeeServiceException>(CreateException(101,"Employee With given id does not exists "+employeeId),"Exception Occured");
            }
        }

        public void CreateEmployee(int id, string name)
        {
            Employee employee = null;
            if (!IsEmployeeIdExists(id))
            {
                employee = new Employee();
                employee.Id = id;
                employee.Name = name;
                _employeeList.Add(employee);
                Console.WriteLine("Created the employee");
            }
            else
            {
                throw new FaultException<EmployeeServiceException>(CreateException(101, "The employee with the given id already exists " + id), "Exception Occured");
            }
        }

        public Employee GetEmployeeDetails(int employeeId)
        {
            if (IsEmployeeIdExists(employeeId))
            {
                return _employeeList.First(emp => emp.Id == employeeId);
            }
            else
            {
                throw new FaultException<EmployeeServiceException>(CreateException(101, "The employee with the given id does not exists " + employeeId), "Exception Occured");
            }
        }

        public Employee GetEmployeeDetails(string employeeName)
        {
            if (IsEmployeeNameExists(employeeName))
            {
                return _employeeList.First(emp => emp.Name == employeeName);
            }
            else
            {
                throw new FaultException<EmployeeServiceException>(CreateException(101, "The employee with the given name does not exists " + employeeName), "Exception Occured");
                
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        private bool IsEmployeeIdExists(int employeeId)
        {
            return _employeeList.Any(employee => employee.Id == employeeId);
        }

        private bool IsEmployeeNameExists(string employeeName)
        {
            return _employeeList.Any(employee => employee.Name == employeeName);
        }

        public int GetEmployeeCount()
        {
            return _employeeList.Count;
        }

        public void DeleteAllEMployees()
        {
            _employeeList.Clear();
            _remarksList.Clear();
        }

        public int GetRemarksCount()
        {
            return _remarksList.Count;
        }

        public IEnumerable<Employee> GetEmployeesWithRemarks()
        {
            return _employeeList.Where(emp => _remarksList.All(remark => remark.EmployeeId == emp.Id));
        }

        private EmployeeServiceException CreateException(int faultId, string message) {
            EmployeeServiceException exception = new EmployeeServiceException
            {
                FaultId = faultId,
                Message = message
            };

            return exception;
        }
    }
}
