using ConsoleApp1.Builders;
using ConsoleApp1.Enums;
using ConsoleApp1.Model;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public abstract class BaseQuotationSystem : IQuotationSystems
    {
        protected string _url { get; set; }
        protected string _port { get; set; }
        public QuotationSystem System { get; private set; }
        protected IExternalQuoteRequestResponseBuilder _requestResponseBuilder { get; set; }

        public BaseQuotationSystem(QuotationSystem system, string url, string port, IExternalQuoteRequestResponseBuilder requestResponseBuilder)
        {
            _url = url;
            _port = port;
            System = system;
            _requestResponseBuilder = requestResponseBuilder;
        }


        public abstract Task<ExternalQuationResponse> GetPriceAsync(PriceRequest request);

    }
}
