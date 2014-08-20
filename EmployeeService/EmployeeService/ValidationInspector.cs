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
                    throw new FaultException(
                        "Invalid name. Only alphabetical character");
                }
            }
            else {
                throw new FaultException(
                        "Invalid name. Can not empty");
            }
        }

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId < 0)
                throw new FaultException(
                    "Invalid Id. Id should be greater than zero");
        }
    }
}