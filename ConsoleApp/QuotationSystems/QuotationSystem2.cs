using ConsoleApp1.Builders;
using ConsoleApp1.Enums;
using ConsoleApp1.Model;
using System.Dynamic;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem2 : BaseQuotationSystem
    {
        public QuotationSystem2(QutationConfiguration config, IExternalQuoteRequestResponseBuilder requestResponseBuilder)
     : base(QuotationSystem.QuotationSystem2, config.Url, config.Port, requestResponseBuilder)
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
                response.Price = 234.56M;
                response.HasPrice = true;
                response.Name = "qewtrywrh";
                response.Tax = 234.56M * 0.12M;

                return await Task.FromResult(_requestResponseBuilder.BuildResponse(System, response));
            }
            catch (System.Exception ex)
            {
                // can implement logging 
                throw ex;
            }
            
        }
    }
}
