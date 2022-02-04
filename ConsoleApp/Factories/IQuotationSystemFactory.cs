using ConsoleApp1.Model;
using ConsoleApp1.QuotationSystems;
using System.Collections.Generic;

namespace ConsoleApp1.Factories
{
    public interface IQuotationSystemFactory
    {
        IList<IQuotationSystem> GenerateQutationSystems(PriceRequest request);
    }
}