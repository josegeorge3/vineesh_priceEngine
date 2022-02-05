using System.Collections.Generic;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Model
{
    public interface IQuotationConfigurations
    {
        List<string> QuotationSystem2_Makes { get; }
        QutationConfiguration GetQutationConfiguration(QuotationSystem system);
    }
}