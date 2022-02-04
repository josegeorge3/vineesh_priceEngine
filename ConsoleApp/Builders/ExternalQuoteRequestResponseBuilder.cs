using ConsoleApp1.Model;
using System;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Builders
{
    public class ExternalQuoteRequestResponseBuilder : IExternalQuoteRequestResponseBuilder
    {
        public dynamic BuildRequest(QutationSystem system, PriceRequest priceRequest)
        {
            dynamic exRequest = new ExpandoObject();

            switch (system)
            {
                case QutationSystem.QutationSystem1:
                case QutationSystem.QutationSystem3:
                    exRequest.FirstName = priceRequest.RiskData.FirstName;
                    exRequest.Surname = priceRequest.RiskData.LastName;
                    exRequest.DOB = priceRequest.RiskData.DOB;
                    exRequest.Make = priceRequest.RiskData.Make;
                    exRequest.Amount = priceRequest.RiskData.Value;
                    break;
                case QutationSystem.QutationSystem2:
                    exRequest.FirstName = priceRequest.RiskData.FirstName;
                    exRequest.LastName = priceRequest.RiskData.LastName;
                    exRequest.Make = priceRequest.RiskData.Make;
                    exRequest.Value = priceRequest.RiskData.Value;
                    break;               
                default:
                    throw new NotImplementedException($"Response builder method is not implemented for {system}");
                    break;
            }

            return exRequest;
        }

        public PriceResponse BuildResponse(QutationSystem system, dynamic externalResponse)
        {
            var res = new PriceResponse();

            switch (system)
            {
                case QutationSystem.QutationSystem1:
                    if (externalResponse.IsSuccess)
                    {
                        res.Price = externalResponse.Price;
                        res.InsurerName = externalResponse.Name;
                        res.Tax = externalResponse.Tax;
                    }
                    break;
                case QutationSystem.QutationSystem2:
                    if (externalResponse.HasPrice)
                    {
                        res.Price = externalResponse.Price;
                        res.InsurerName = externalResponse.Name;
                        res.Tax = externalResponse.Tax;
                    }
                    break;
                case QutationSystem.QutationSystem3:
                    if (externalResponse.IsSuccess)
                    {
                        res.Price = externalResponse.Price;
                        res.InsurerName = externalResponse.Name;
                        res.Tax = externalResponse.Tax;
                    }
                    break;
                default:
                    throw new NotImplementedException($"Response builder method is not implemented for {system}");
                    break;
            }

            return res;
        }

    }
}
