using ConsoleApp1.Model;
using System.Collections.Generic;

namespace ConsoleApp1.Builders
{
    public interface IPriceResonseBuilder
    {
        PriceResponse BuildResponse(List<PriceResponse> priceResponses);
    }
}