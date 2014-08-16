using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Consumer
{
    public class EmployeeConsumer
    {
        public static void Main(string[] args)
        {
            var client = new EmployeeConsumer.EmployeeServiceReference();
        }
    }
}
