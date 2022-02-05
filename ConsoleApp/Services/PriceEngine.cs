using ConsoleApp1.Builders;
using ConsoleApp1.Factories;
using ConsoleApp1.Model;
using ConsoleApp1.QuotationSystems;
using ConsoleApp1.Validators;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{

    public class PriceEngine
    {
        private IQuotationFactory _quotationSystemFactory { get; set; }
        private IPriceResponseBuilder _priceResponseBuilder { get; set; }
        private IPriceRequestValidator _priceRequestValidator { get; set; }
        public PriceEngine() : this(new QuotationSystemFactory(new QuotationSystemConfigurations(), new ExternalQuoteRequestResponseBuilder()), new PriceReasonsBuilder(), new PriceRequestValidator())
        { 
        }

        public PriceEngine(IQuotationFactory quotationSystemFactory, IPriceResponseBuilder priceResonseBuilder, IPriceRequestValidator priceRequestValidator)
        {
            _quotationSystemFactory = quotationSystemFactory;
            _priceResponseBuilder = priceResonseBuilder;
            _priceRequestValidator = priceRequestValidator;
        }


        //pass request with risk data with details of a gadget, return the best price retrieved from 3 external quotation engines
        public async Task<PriceResponse> GetPriceAsync(PriceRequest request)
        {
            //initialise return variables
            var priceResponse = new PriceResponse() { InsurerName = String.Empty, Tax = 0, Price = -1 };

            //validation
            priceResponse.ErrorMessage = _priceRequestValidator.Validate(request);

            if (!priceResponse.ErrorMessage.Any())
            {
                //now call 3 external system and get the best price 
                var quotationSystems = _quotationSystemFactory.GenerateQutationSystems(request);

                //get quote from each quation system
                var priceQuoteTasks = (quotationSystems.Select(quotationSystem => quotationSystem.GetPriceAsync(request))).ToList();
                await Task.WhenAll(priceQuoteTasks);

                priceResponse = _priceResponseBuilder.BuildResponse(priceQuoteTasks.Where(t => t.IsCompleted).Select(t => t.Result)?.ToList());
            } 

            return priceResponse;
        }
    }
}
