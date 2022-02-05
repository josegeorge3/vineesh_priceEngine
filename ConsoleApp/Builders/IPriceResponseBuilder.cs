using ConsoleApp1.Model;
using System.Collections.Generic;

namespace ConsoleApp1.Builders
{
    public interface IPriceResponseBuilder
    {
        PriceResponse BuildResponse(List<ExternalQuationResponse> priceResponses);
    }
}