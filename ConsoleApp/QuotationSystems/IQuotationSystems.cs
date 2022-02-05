using ConsoleApp1.Enums;
using ConsoleApp1.Model;
using System.Threading.Tasks;

namespace ConsoleApp1.QuotationSystems
{
    public interface IQuotationSystems
    {
        QuotationSystem System { get;  }
        Task<ExternalQuationResponse> GetPriceAsync(PriceRequest request);
    }
}