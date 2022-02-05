using ConsoleApp1.Enums;
using ConsoleApp1.Model;

namespace ConsoleApp1.Builders
{
    public interface IExternalQuoteRequestResponseBuilder
    {
        dynamic BuildRequest(QuotationSystem system, PriceRequest priceRequest);
        ExternalQuationResponse BuildResponse(QuotationSystem system, dynamic externalResponse);
    }
}