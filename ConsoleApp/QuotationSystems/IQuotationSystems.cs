using ConsoleApp1.Model;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public interface IQuotationSystems
    {
        Task<ExternalQuationResponse> GetPriceAsync(PriceRequest request);
    }
}