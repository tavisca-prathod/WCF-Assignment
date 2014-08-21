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
        private static int _currentCount;
        private static int _totalRowCount;
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        } 
        [TestInitialize]
        public void ClearData()
        {
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                if (_totalRowCount == _currentCount) {
                    getEmployeeService.DeleteAllEMployees();
                    _currentCount = 0;
                    _totalRowCount = 0;
                }
            }
        }

        [TestMethod]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "Employee",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeFixture()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                _currentCount++;
                _totalRowCount = _testContextInstance.DataRow.Table.Rows.Count;
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(_currentCount, getEmployeeService.GetEmployeeCount());
                Assert.AreEqual(employeeId, getEmployeeService.GetEmployeeDetailsById(employeeId).Id);
                Assert.AreEqual(employeeName, getEmployeeService.GetEmployeeDetailsByName(employeeName).Name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "ExistingEmployee",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeWithExistingIdFixture()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(1, getEmployeeService.GetEmployeeCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmployeeWithOnlyName",
                            DataAccessMethod.Sequential)]
        public void GetEmployeeWithNonExistingEmployeeName()
        {
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                Employee emp = null;
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                emp = getEmployeeService.GetEmployeeDetailsByName(employeeName);
                Assert.IsNull(emp);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "NonExistingEmployee",
                            DataAccessMethod.Sequential)]
        public void GetEmployeeWithNonExistingEmployeeId()
        {
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                Employee emp = null;
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                emp = getEmployeeService.GetEmployeeDetailsById(employeeId);
                Assert.IsNull(emp);
            }
        }

        [TestMethod]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "Employee",
                            DataAccessMethod.Sequential)]
        public void GetAllEmployees()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                _currentCount++;
                _totalRowCount = _testContextInstance.DataRow.Table.Rows.Count;
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(_currentCount, getEmployeeService.GetAllEmployees().Count());
            }
        }

        [TestMethod]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmployeeWithRemark",
                            DataAccessMethod.Sequential)]
        public void AddRemarkForAnExistingEmployee()
        {

            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                string remarkText = _testContextInstance.DataRow["RemarkString"].ToString();

                addEmployeeService.CreateEmployee(employeeId,employeeName);
                addEmployeeService.AddRemarks(employeeId, remarkText);
                Assert.AreEqual(1, getEmployeeService.GetEmployeeCount());
                Assert.AreEqual(1, getEmployeeService.GetRemarksCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "RemarkForNonExistingEmployee",
                            DataAccessMethod.Sequential)]
        public void AddRemarkForNonExistingEmployee()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string remarkText = _testContextInstance.DataRow["RemarkString"].ToString();
                addEmployeeService.AddRemarks(employeeId, remarkText);
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
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "Employee",
                            DataAccessMethod.Sequential)]
        public void GetEmployeeWithIdAndName()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                 _currentCount++;
                _totalRowCount = _testContextInstance.DataRow.Table.Rows.Count;
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(_currentCount, getEmployeeService.GetEmployeeCount());
                Assert.AreEqual(employeeId, getEmployeeService.GetEmployeeDetailsById(employeeId).Id);
                Assert.AreEqual(employeeName, getEmployeeService.GetEmployeeDetailsByName(employeeName).Name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmployeeWithIncorrectName",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeWithInCorrectName()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(0, getEmployeeService.GetEmployeeCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmployeeWithIncorrectId",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeWithInCorrectId()
        {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(0, getEmployeeService.GetEmployeeCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmployeeWithEmptyName",
                            DataAccessMethod.Sequential)]
        public void AddEmployeeWithEmptyName() {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                addEmployeeService.CreateEmployee(employeeId, employeeName);
                Assert.AreEqual(0, getEmployeeService.GetEmployeeCount());
            }
        }


        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "RemarkForEmployeeWithNegativeId",
                            DataAccessMethod.Sequential)]
        public void AddRemarkForEmployeeWithNegativeId() {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string remark = _testContextInstance.DataRow["RemarkString"].ToString();
                addEmployeeService.AddRemarks(employeeId, remark);
                Assert.AreEqual(0, getEmployeeService.GetRemarksCount());
            }
        }


        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmptyRemarkForEmployee",
                            DataAccessMethod.Sequential)]
        public void AddEmptyRemark() {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string remark = _testContextInstance.DataRow["RemarkString"].ToString();
                addEmployeeService.AddRemarks(employeeId, remark);
                Assert.AreEqual(0, getEmployeeService.GetRemarksCount());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeServiceException>))]
        [DeploymentItem(@"EmployeeData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                           @"EmployeeData.xml",
                           "EmployeeWithIncorrectRemark",
                            DataAccessMethod.Sequential)]
        public void AddInValidRemark() {
            using (var addEmployeeService = new AddEmployeeServiceClient())
            using (var getEmployeeService = new GetEmployeeServiceClient())
            {
                int employeeId = Int32.Parse((string)_testContextInstance.DataRow["EmployeeId"]);
                string remark = _testContextInstance.DataRow["RemarkString"].ToString();
                addEmployeeService.AddRemarks(employeeId, remark);
                Assert.AreEqual(0, getEmployeeService.GetRemarksCount());
            }
        }
    }
}
