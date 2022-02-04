using ConsoleApp1.Model;

namespace ConsoleApp1.Builders
{
    public interface IExternalQuoteRequestResponseBuilder
    {
        dynamic BuildRequest(QutationSystem system, PriceRequest priceRequest);
        PriceResponse BuildResponse(QutationSystem system, dynamic externalResponse);
    }
}