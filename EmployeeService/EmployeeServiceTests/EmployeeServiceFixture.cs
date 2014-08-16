using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeService;

namespace EmployeeServiceTests
{
    [TestClass]
    public class EmployeeServiceFixture
    {
        [TestMethod]
        public void AddEmployeeFixture()
        {
            IAddEmployeeService addEmployeeService = new EmployeeOperationService();
            addEmployeeService.CreateEmployee(1,"Prashant");
            Assert.AreEqual(1, EmployeeOperationService.GetEmployeeCount());
        }

        [TestMethod]
        public void AddEmployeeWithExistingIdFixture() {
            try
            {
                IAddEmployeeService addEmployeeService = new EmployeeOperationService();
                addEmployeeService.CreateEmployee(1, "Prashant");
            }
            catch (Exception ex) {
                Assert.AreEqual(1, EmployeeOperationService.GetEmployeeCount());
                Console.WriteLine(ex.Message);
            }
        }
    }
}
