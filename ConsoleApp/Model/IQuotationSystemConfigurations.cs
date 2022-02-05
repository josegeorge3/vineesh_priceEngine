using System.Collections.Generic;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Model
{
    public interface IQuotationSystemConfigurations
    {
        List<string> QuotationSystem2_Makes { get; }
        QutationSystemConfiguration GetQutationSystemConfiguration(QuotationSystem system);
    }
}