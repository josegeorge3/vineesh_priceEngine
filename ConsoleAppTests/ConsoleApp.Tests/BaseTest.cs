using ConsoleApp1.Builders;
using ConsoleApp1.Enums;
using ConsoleApp1.Factories;
using ConsoleApp1.Model;
using ConsoleApp1.QuotationSystems;
using ConsoleApp1.Validators;
using Moq;
using System.Collections.Generic;

namespace ConsoleApp.Tests
{
    public abstract class BaseTest
    {
        protected Mock<IQuotationSystems> _quotationSystemsMock;
        protected Mock<IQuotationFactory> _quotationSystemFactoryMock;
        protected Mock<IPriceResponseBuilder> _priceReasponseBuilderMock;
        protected Mock<IPriceRequestValidator> _priceRequestValidatorMock;
        protected Mock<IQuotationConfigurations> _configurationMock;
        protected Mock<IExternalQuoteRequestResponseBuilder> _requestResponseBuilderMock;

        protected void InitalizeMoqObjects()
        {
            _requestResponseBuilderMock = new Mock<IExternalQuoteRequestResponseBuilder>();

            _configurationMock = new Mock<IQuotationConfigurations>();
            _configurationMock.Setup(c => c.GetQutationConfiguration(It.IsAny<QuotationSystem>())).Returns(new QutationConfiguration());
            _configurationMock.Setup(m => m.QuotationSystem2_Makes).Returns(new List<string> { });

            _quotationSystemsMock = new Mock<IQuotationSystems>();

            _quotationSystemFactoryMock = new Mock<IQuotationFactory>();

            _priceReasponseBuilderMock = new Mock<IPriceResponseBuilder>();

            _priceRequestValidatorMock = new Mock<IPriceRequestValidator>();
        }


    }
}
