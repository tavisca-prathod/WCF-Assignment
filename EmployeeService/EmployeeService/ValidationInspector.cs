using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text.RegularExpressions;
using System.Web;

namespace EmployeeService
{
    public class ValidationInspector : IParameterInspector
    {
        const string NameFormat = "^[a-zA-Z ]{1,}$";
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {

        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "CreateEmployee" || operationName == "AddRemarks")
                ValidateStringInput((string)inputs[1], operationName);

            if (operationName == "CreateEmployee" || operationName == "AddRemarks" || operationName == "GetEmployeeDetails")
                ValidateEmployeeId((Int32)inputs[0]);
            return null;
        }

        private void ValidateStringInput(string param, string operationName)
        {
            if (param != null && param != "")
            {
                if (!Regex.IsMatch(
                    param, NameFormat))
                {
                    throw new FaultException<EmployeeServiceException>(CreateException(101, "Invalid name. Only alphabetical character"), "Exception Occured");
                }
            }
            else
            {
                throw new FaultException<EmployeeServiceException>(CreateException(101, "Invalid name. Can not empty"), "Exception Occured");
            }
        }

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId < 0)
                throw new FaultException<EmployeeServiceException>(CreateException(101, "Invalid Id. Id should be greater than zero"), "Exception Occured");
        }

        private EmployeeServiceException CreateException(int faultId, string message)
        {
            EmployeeServiceException exception = new EmployeeServiceException
            {
                FaultId = faultId,
                Message = message
            };

            return exception;
        }
    }
}