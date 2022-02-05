﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Builders;
using ConsoleApp1.Enums;
using ConsoleApp1.Model;
using ConsoleApp1.QuotationSystems;

namespace ConsoleApp1.Factories
{
    public class QuotationSystemFactory : IQuotationSystemFactory
    {
        private IQuotationSystemConfigurations _configurations { get; set; }
        private IExternalQuoteRequestResponseBuilder _externalQuoteRequestResponseBuilder { get; set; }
        public QuotationSystemFactory(IQuotationSystemConfigurations priceEngineConfigurations, IExternalQuoteRequestResponseBuilder externalQuoteRequestResponseBuilder)
        {
            _configurations = priceEngineConfigurations;
            _externalQuoteRequestResponseBuilder = externalQuoteRequestResponseBuilder;
        }

        public QuotationSystemFactory(): this(new QuotationSystemConfigurations(), new ExternalQuoteRequestResponseBuilder())
        {

        }

        public IList<IQuotationSystem> GenerateQutationSystems(PriceRequest request)
        {
            var quoteSystems = new List<IQuotationSystem>();
            if (request.RiskData.DOB != null)
            { 
                quoteSystems.Add(new QuotationSystem1(_configurations.GetQutationSystemConfiguration(QuotationSystem.QuotationSystem1), _externalQuoteRequestResponseBuilder));
            }
            
            if (_configurations.QuotationSystem2_Makes.Contains(request.RiskData.Make?.Trim(), StringComparer.OrdinalIgnoreCase))
            {                 
                quoteSystems.Add(new QuotationSystem2(_configurations.GetQutationSystemConfiguration(QuotationSystem.QuotationSystem2), _externalQuoteRequestResponseBuilder));
            }

            quoteSystems.Add(new QuotationSystem3(_configurations.GetQutationSystemConfiguration(QuotationSystem.QuotationSystem3), _externalQuoteRequestResponseBuilder));


            return quoteSystems;

        }
    }
}
