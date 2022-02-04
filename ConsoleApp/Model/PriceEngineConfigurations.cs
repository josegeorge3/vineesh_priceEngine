using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Model
{
    public class PriceEngineConfigurations : IPriceEngineConfigurations
    {
        private static List<string> _quotationSystem2_Makes;


        public List<string> QuotationSystem2_Makes
        {
            get
            {
                if (_quotationSystem2_Makes == null)
                {
                    _quotationSystem2_Makes = new List<string>();

                    QuotationSystem2_Makes.AddRange(ConfigurationManager.AppSettings["QuotationSystem2_Makes"]?.Split(',').Select(m=>m.Trim()));
                }
                return _quotationSystem2_Makes;
            }

        }

        public QutationSystemConfiguration GetQutationSystemConfiguration(QutationSystem system)
        {
            return new QutationSystemConfiguration 
            {
                   Url = ConfigurationManager.AppSettings[$"{system}_Url"]?.ToString(),
                   Port = ConfigurationManager.AppSettings[$"{system}_Port"]?.ToString()
            };
        }
         
    }
}
