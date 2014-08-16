using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer.EmployeeServiceReference;

namespace Consumer
{
    public class EmployeeConsumer
    {
        public static void Main(string[] args)
        {
            using(var addEmployeeServiceClient = new AddEmployeeServiceClient())
            using (var getEmployeeServiceClient = new GetEmployeeServiceClient()) {
                addEmployeeServiceClient.CreateEmployee(7,"Prashant");
                addEmployeeServiceClient.AddRemarks(7,"this is our employee");
            }
        }
    }
}
