using ConsoleApp1.Builders;
using ConsoleApp1.Factories;
using ConsoleApp1.Model;
using ConsoleApp1.Validators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests.Services
{
    [TestFixture]
    public class PriceEngine_Test
    {
        private Mock<IQuotationFactory> _quotationSystemFactory;
        private Mock<IPriceResponseBuilder> _priceReasonsBuilder;
        private Mock<IPriceRequestValidator> _priceRequestValidator;

        public PriceRequest _request { get; private set; }
        public PriceResponse _priceResponse { get; private set; }

        [SetUp]
        public void Initialize()
        {
            _priceRequestValidator = new Mock<IPriceRequestValidator>();
            
            _priceResponse = new PriceResponse() { InsurerName = String.Empty, Tax = 0, Price = -1 };
        }

        [Test]
        public void when_request_validation_fails_response_should_return_default()
        {
            //Arrange

            _request = new PriceRequest()
            {
                RiskData = null
            };
            _priceResponse = new PriceResponse
            {
                ErrorMessage = new List<string>
                {
                    "Risk Data is missing"
                }
            };


            //Act 
            _priceRequestValidator.Setup(x => x.Validate(_request)).Returns(_priceResponse.ErrorMessage);


            //Assert
            Assert.AreEqual(_priceResponse.ErrorMessage.Any(), true);


        }

    }
}
