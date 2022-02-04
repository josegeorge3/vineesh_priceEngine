using ConsoleApp1.Builders;
using ConsoleApp1.Model;
using System.Dynamic;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem2 : BaseQuotationSystem
    {
        public QuotationSystem2(QutationSystemConfiguration config, IExternalQuoteRequestResponseBuilder requestResponseBuilder)
     : base(QutationSystem.QutationSystem2, config.Url, config.Port, requestResponseBuilder)
        {

        }

        public override async Task<PriceResponse> GetPriceAsync(PriceRequest request)
        {
            var externalRequest = _requestResponseBuilder.BuildRequest(_system, request);
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 234.56M;
            response.HasPrice = true;
            response.Name = "qewtrywrh";
            response.Tax = 234.56M * 0.12M;

            return await Task.FromResult(_requestResponseBuilder.BuildResponse(_system, response));
        }
    }
}
