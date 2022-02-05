using ConsoleApp1.Model;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Builders
{
    public class PriceReasonsBuilder : IPriceResponseBuilder
    {

        public PriceResponse BuildResponse(List<ExternalQuationResponse> priceResponses)
        {
            var response = new PriceResponse() { Price = -1, Tax = 0 };
            var lowestPrice = priceResponses?.OrderBy(p => p.Price)?.FirstOrDefault();
            if (lowestPrice != null && lowestPrice.Price != 0)
            {
                response.Price = lowestPrice.Price;
                response.InsurerName = lowestPrice.InsurerName;
                response.Tax = lowestPrice.Tax;
            }
            return response;
        }

    }
}
