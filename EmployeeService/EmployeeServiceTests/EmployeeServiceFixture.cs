using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeService;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Diagnostics;
using EmployeeServiceTests.EmployeeTestServiceReference;

namespace EmployeeServiceTests
{
    [TestClass]
    public class EmployeeServiceFixture
    {
        private static int currentCount;
        private int totalRowCount;
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

       
        [TestInitialize]
        public void ClearData()
        {
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                if (totalRowCount == currentCount) {
                    getEmployeeService.DeleteAllEMployees();
                    currentCount = 0;
                    totalRowCount = 0;
                }
            }
        }

        [TestMethod]
        [DeploymentItem(@"D:\WCF-Assignment\EmployeeService\EmployeeServiceTests\EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"D:\WCF-Assignment\EmployeeService\EmployeeServiceTests\EmployeeData.xml",
                           "Employee",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeFixture()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                currentCount++;
                totalRowCount = testContextInstance.DataRow.Table.Rows.Count;
                int employeeId = Int32.Parse((string)testContextInstance.DataRow["EmployeeId"]);
                string employeeName = testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(currentCount, getEmployeeService.GetEmployeeCount());
                Assert.AreEqual(employeeId, getEmployeeService.GetEmployeeDetailsById(employeeId).Id);
                Assert.AreEqual(employeeName, getEmployeeService.GetEmployeeDetailsByName(employeeName).Name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
          [DeploymentItem(@"D:\WCF-Assignment\EmployeeService\EmployeeServiceTests\EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"D:\WCF-Assignment\EmployeeService\EmployeeServiceTests\EmployeeData.xml",
                           "Employee",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeWithExistingIdFixture()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)testContextInstance.DataRow["EmployeeId"]);
                string employeeName = testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);

                employeeId = Int32.Parse((string)testContextInstance.DataRow["EmployeeId"]);
                employeeName = testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(1, getEmployeeService.GetEmployeeCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        public void GetEmployeeWithNonExistingEmployeeName()
        {
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                Employee emp = null;
                emp = getEmployeeService.GetEmployeeDetailsByName("Prashant");
                Assert.IsNull(emp);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        public void GetEmployeeWithNonExistingEmployeeId()
        {
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                Employee emp = null;
                emp = getEmployeeService.GetEmployeeDetailsById(1);
                Assert.IsNull(emp);
            }
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                List<Employee> employeeList = getEmployeeService.GetAllEmployees().ToList();
                Assert.AreEqual(employeeList.Count, 0);
                addEmployeeService.CreateEmployee(1, "Prashant");
                employeeList = getEmployeeService.GetAllEmployees().ToList();
                Assert.AreEqual(employeeList.Count, 1);
            }
        }

        [TestMethod]
        public void AddRemaekForAnExistingEmployee()
        {

            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                addEmployeeService.CreateEmployee(1, "Prashant");
                addEmployeeService.AddRemarks(1, "Hey There I am using watsapp");
                Assert.AreEqual(1, getEmployeeService.GetEmployeeCount());
                Assert.AreEqual(1, getEmployeeService.GetRemarksCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        public void AddRemarkForNonExistingEmployee()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                addEmployeeService.AddRemarks(1, "Hey There I am using watsapp");
                Assert.AreEqual(getEmployeeService.GetRemarksCount(), 0);
            }
        }

        [TestMethod]
        public void GetEmployeesWithRemarks()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                addEmployeeService.CreateEmployee(1, "Prashant");
                addEmployeeService.AddRemarks(1, "Hey There I am using watsapp");
                addEmployeeService.CreateEmployee(2, "Prash");
                List<Employee> employeesWithRemarks = (getEmployeeService.GetEmployeesWithRemarks()).ToList();
                Assert.AreEqual(1, employeesWithRemarks.Count);
                Assert.AreEqual(2, getEmployeeService.GetEmployeeCount());
            }
        }

        [TestMethod]
        public void GetEmployeeWithIdAndName()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                addEmployeeService.CreateEmployee(1, "Prashant");
                addEmployeeService.CreateEmployee(2, "Prash");
                Employee emp = getEmployeeService.GetEmployeeDetailsById(1);
                Assert.AreEqual(emp.Name, "Prashant");
                Employee empWithId2 = getEmployeeService.GetEmployeeDetailsById(2);
                Assert.AreEqual(empWithId2.Id, 2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddEmployeeWithInCorrectName()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                addEmployeeService.CreateEmployee(1, "Prashant56565");
                Assert.AreEqual(0, getEmployeeService.GetEmployeeCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddEmployeeWithInCorrectId()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                addEmployeeService.CreateEmployee(-1, "Prashant");
                Assert.AreEqual(0, getEmployeeService.GetEmployeeCount());
            }
        }
    }
}
