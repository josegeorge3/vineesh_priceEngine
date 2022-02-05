using ConsoleApp1.Builders;
using ConsoleApp1.Enums;
using ConsoleApp1.Model;
using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem1 : BaseQuotationSystem
    {
        public QuotationSystem1(QutationConfiguration config, IExternalQuoteRequestResponseBuilder requestResponseBuilder) 
            : base(QuotationSystem.QuotationSystem1, config.Url, config.Port, requestResponseBuilder)
        {
            
        }

        public override async Task<ExternalQuationResponse> GetPriceAsync(PriceRequest request)
        {
            try
            {
                var externalRequest = _requestResponseBuilder.BuildRequest(System, request);
                //makes a call to an external service - SNIP
                //var response = _someExternalService.PostHttpRequest(requestData);

                dynamic response = new ExpandoObject();
                response.Price = 123.45M;
                response.IsSuccess = true;
                response.Name = "Test Name";
                response.Tax = 123.45M * 0.12M;

                return await Task.FromResult(_requestResponseBuilder.BuildResponse(System, response));
            }
            catch (Exception ex)
            {
                // can implement logging 
                throw ex;
            }
            
        }
    }
}
