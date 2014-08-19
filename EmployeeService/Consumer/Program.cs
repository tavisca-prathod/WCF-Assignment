using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer.EmployeeServiceReference;
using System.ServiceModel;

namespace Consumer
{
    public class EmployeeConsumer
    {
        public static void Main(string[] args)
        {
            using(var addEmployeeServiceClient = new AddEmployeeServiceClient())
            using (var getEmployeeServiceClient = new GetEmployeeServiceClient()) {
                try {
                    addEmployeeServiceClient.CreateEmployee(-2,"Prashant");
                }
                catch (FaultException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
