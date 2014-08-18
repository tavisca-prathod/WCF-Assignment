using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeService;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeServiceTests
{
    [TestClass]
    public class EmployeeServiceFixture
    {
        [TestMethod]
        public void AddEmployeeFixture()
        {
            IAddEmployeeService addEmployeeService = new EmployeeOperationService();
            IGetEmployeeService getEmployeeService = new EmployeeOperationService();
            addEmployeeService.CreateEmployee(1, "Prashant");
            Assert.AreEqual(1, EmployeeOperationService.GetEmployeeCount());
            Assert.AreEqual(1, getEmployeeService.GetEmployeeDetails(1).Id);
            Assert.AreEqual("Prashant", getEmployeeService.GetEmployeeDetails("Prashant").Name);
            EmployeeOperationService.ClearEmployeeList();
        }

        [TestMethod]
        public void AddEmployeeWithExistingIdFixture()
        {
            try
            {
                IAddEmployeeService addEmployeeService = new EmployeeOperationService();
                addEmployeeService.CreateEmployee(1, "Prashant");
                addEmployeeService.CreateEmployee(1, "Prash");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(1, EmployeeOperationService.GetEmployeeCount());
            }

            finally
            {
                EmployeeOperationService.ClearEmployeeList();
            }
        }

        [TestMethod]
        public void GetEmployeeWithNonExistingEmployeeName()
        {
            Employee emp = null;
            try
            {
                IGetEmployeeService getEmployeeService = new EmployeeOperationService();
                emp = getEmployeeService.GetEmployeeDetails("Prashant");
            }
            catch (Exception ex)
            {
                Assert.IsNull(emp);
            }
            finally
            {
                EmployeeOperationService.ClearEmployeeList();
            }
        }

        [TestMethod]
        public void GetEmployeeWithNonExistingEmployeeId()
        {
            Employee emp = null;
            try
            {
                IGetEmployeeService getEmployeeService = new EmployeeOperationService();
                emp = getEmployeeService.GetEmployeeDetails(1);
            }
            catch (Exception ex)
            {
                Assert.IsNull(emp);
            }
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            IGetEmployeeService getEmployeeService = new EmployeeOperationService();
            List<Employee> employeeList = getEmployeeService.GetAllEmployees();
            Assert.AreEqual(employeeList.Count, 0);
            IAddEmployeeService addEmployeeService = new EmployeeOperationService();
            addEmployeeService.CreateEmployee(1, "Prashant");
            employeeList = getEmployeeService.GetAllEmployees();
            Assert.AreEqual(employeeList.Count, 1);
            EmployeeOperationService.ClearEmployeeList();
        }

        [TestMethod]
        public void AddRemaekForAnExistingEmployee()
        {
            IAddEmployeeService addEmployeeService = new EmployeeOperationService();
            addEmployeeService.CreateEmployee(1, "Prashant");
            addEmployeeService.AddRemarks(1, "Hey There! I am using watsapp");
            Assert.AreEqual(1, EmployeeOperationService.GetEmployeeCount());
            Assert.AreEqual(1, EmployeeOperationService.GetRemarksCount());
            EmployeeOperationService.ClearEmployeeList();
        }

        [TestMethod]
        public void AddRemarkForNonExistingEmployee()
        {
            try
            {
                IAddEmployeeService addEmployeeService = new EmployeeOperationService();
                addEmployeeService.AddRemarks(1, "Hey There! I am using watsapp");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(EmployeeOperationService.GetRemarksCount(), 0);
            }
        }

        [TestMethod]
        public void GetEmployeesWithRemarks()
        {
            IAddEmployeeService addEmployeeService = new EmployeeOperationService();
            addEmployeeService.CreateEmployee(1,"Prashant");
            addEmployeeService.AddRemarks(1, "Hey There! I am using watsapp");
            addEmployeeService.CreateEmployee(2, "Prash");
            IGetEmployeeService getEmployeeService = new EmployeeOperationService();
            List<Employee> employeesWithRemarks = (getEmployeeService.GetEmployeesWithRemarks()).ToList();
            Assert.AreEqual(1,employeesWithRemarks.Count);
            Assert.AreEqual(2,EmployeeOperationService.GetEmployeeCount());
        }
    }
}
