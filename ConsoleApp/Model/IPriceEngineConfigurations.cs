using System.Collections.Generic;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Model
{
    public interface IPriceEngineConfigurations
    {
        List<string> QuotationSystem2_Makes { get; }
        QutationSystemConfiguration GetQutationSystemConfiguration(QutationSystem system);
    }
}