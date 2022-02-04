using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validators
{
    public class PriceRequestValidator : IPriceRequestValidator
    {
        public List<string> Validate(PriceRequest request)
        {
            var errorMessages = new List<string>();

            if (request.RiskData == null)
            {
                errorMessages.Add("Risk Data is missing"); 
            }
            else
            {
                if (String.IsNullOrEmpty(request.RiskData.FirstName))
                {
                    errorMessages.Add("First name is required");
                }

                if (String.IsNullOrEmpty(request.RiskData.LastName))
                {
                    errorMessages.Add("Surname is required");
                }

                if (request.RiskData.Value == 0)
                {
                    errorMessages.Add("Value is required");
                }
            }
                       
            return errorMessages;
        }
    }
}
