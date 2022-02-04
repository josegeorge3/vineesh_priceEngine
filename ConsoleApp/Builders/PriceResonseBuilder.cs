using ConsoleApp1.Model;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Builders
{
    public class PriceResonseBuilder : IPriceResonseBuilder
    {
        public PriceResponse BuildResponse(List<PriceResponse> priceResponses)
        {
            var lowestPrice = priceResponses?.OrderBy(p => p.Price)?.FirstOrDefault();
            if (lowestPrice != null && lowestPrice.Price != 0)
            {
                return lowestPrice;
            }
            else
            {
                return new PriceResponse() { Price = -1, Tax = 0 };
            }
        }

    }
}
