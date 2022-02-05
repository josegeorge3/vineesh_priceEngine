using ConsoleApp1.Enums;
using ConsoleApp1.Model;
using System;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Builders
{
    public class ExternalQuoteRequestResponseBuilder : IExternalQuoteRequestResponseBuilder
    {
        public dynamic BuildRequest(QuotationSystem system, PriceRequest priceRequest)
        {
            dynamic exRequest = new ExpandoObject();

            switch (system)
            {
                case QuotationSystem.QuotationSystem1:
                case QuotationSystem.QuotationSystem3:
                    exRequest.FirstName = priceRequest.RiskData.FirstName;
                    exRequest.Surname = priceRequest.RiskData.LastName;
                    exRequest.DOB = priceRequest.RiskData.DOB;
                    exRequest.Make = priceRequest.RiskData.Make;
                    exRequest.Amount = priceRequest.RiskData.Value;
                    break;
                case QuotationSystem.QuotationSystem2:
                    exRequest.FirstName = priceRequest.RiskData.FirstName;
                    exRequest.LastName = priceRequest.RiskData.LastName;
                    exRequest.Make = priceRequest.RiskData.Make;
                    exRequest.Value = priceRequest.RiskData.Value;
                    break;               
                default:
                    throw new NotImplementedException($"Response builder method is not implemented for {system}");
            }

            return exRequest;
        }

        public ExternalQuationResponse BuildResponse(QuotationSystem system, dynamic externalResponse)
        {
            var res = new ExternalQuationResponse();

            switch (system)
            {
                case QuotationSystem.QuotationSystem1:
                    if (externalResponse.IsSuccess)
                    {
                        res.Price = externalResponse.Price;
                        res.InsurerName = externalResponse.Name;
                        res.Tax = externalResponse.Tax;
                    }
                    break;
                case QuotationSystem.QuotationSystem2:
                    if (externalResponse.HasPrice) // Where we are setting this Has price ?
                    {
                        res.Price = externalResponse.Price;
                        res.InsurerName = externalResponse.Name;
                        res.Tax = externalResponse.Tax;
                    }
                    break;
                case QuotationSystem.QuotationSystem3:
                    if (externalResponse.IsSuccess)
                    {
                        res.Price = externalResponse.Price;
                        res.InsurerName = externalResponse.Name;
                        res.Tax = externalResponse.Tax;
                    }
                    break;
                default:
                    throw new NotImplementedException($"Response builder method is not implemented for {system}");
            }

            return res;
        }

    }
}
