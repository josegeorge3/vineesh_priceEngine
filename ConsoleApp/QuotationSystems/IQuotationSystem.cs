using ConsoleApp1.Model;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public interface IQuotationSystem
    {
        Task<PriceResponse> GetPriceAsync(PriceRequest request);
    }
}