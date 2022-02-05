using ConsoleApp1.Builders;
using ConsoleApp1.Factories;
using ConsoleApp1.Model;
using ConsoleApp1.QuotationSystems;
using ConsoleApp1.Services;
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
    public class PriceEngine_Test : BaseTest
    {
        private PriceEngine _priceEngine { get; set; }
        public PriceRequest _request { get; private set; }
        public PriceResponse _priceResponse { get; private set; }

        [SetUp]
        public void Initialize()
        {
            InitalizeMoqObjects();
            _request = new PriceRequest();
            _priceEngine = new PriceEngine(_quotationSystemFactoryMock.Object, _priceReasponseBuilderMock.Object, _priceRequestValidatorMock.Object);
        }

        //[Test]
        //public async Task when_request_validation_fails_response_should_return_default()
        //{
        //    //Arrange
        //    _request = new PriceRequest()
        //    {
        //        RiskData = null
        //    };

        //    _priceRequestValidatorMock.Setup(v => v.Validate(_request)).Returns(new List<string>());


        //    //Act 
        //    var actualResponse =  await  _priceEngine.GetPriceAsync(_request);


        //    //Assert
        //    Assert.IsTrue(_priceResponse.Price == -1, $"Price returned in response is not -1 (Actual value returned : {_priceResponse.Price})");
        //    Assert.IsTrue(_priceResponse.ErrorMessage.Any(),"No error messages returned");
        //    Assert.IsTrue(_priceResponse.ErrorMessage.Any(e=>e.Contains("Risk Data is missing")), "Error message 'Risk Data is missing' is not returned"); 
        //}

        [Test]
        public async Task If_Request_Has_ValidationErrors_Engine_Should_Not_InvokeAnyActions()
        {
            _priceRequestValidatorMock.Setup(v => v.Validate(_request)).Returns(new List<string>() { "Risk data can't be null" });
            _quotationSystemFactoryMock.Setup(v => v.GenerateQutationSystems(_request)).Returns(new List<IQuotationSystems> { _quotationSystemsMock.Object });
            _priceReasponseBuilderMock.Setup(v => v.BuildResponse(It.IsAny<List<ExternalQuationResponse>>())).Returns(new PriceResponse());

            //Act 
            var actualResponse = await _priceEngine.GetPriceAsync(_request);

            _quotationSystemFactoryMock.Verify(q => q.GenerateQutationSystems(It.IsAny<PriceRequest>()), Times.Never, "Validation failed but the method 'GenerateQutationSystems' has been invoked");
            _quotationSystemsMock.Verify(q => q.GetPriceAsync(It.IsAny<PriceRequest>()), Times.Never);
            _priceReasponseBuilderMock.Verify(q => q.BuildResponse(It.IsAny<List<ExternalQuationResponse>>()), Times.Never, "Validation failed but the method 'BuildResponse' has been invoked");

        }

        [Test]
        public async Task If_Request_Is_Valid_Then_Engine_Should_InvokeRequiredActions()
        {
            _quotationSystemsMock.Setup(q => q.GetPriceAsync(_request)).Returns(Task.FromResult(new ExternalQuationResponse()));
            _priceRequestValidatorMock.Setup(v => v.Validate(_request)).Returns(new List<string>());
            _quotationSystemFactoryMock.Setup(v => v.GenerateQutationSystems(_request)).Returns(new List<IQuotationSystems> { _quotationSystemsMock.Object });
            _priceReasponseBuilderMock.Setup(v => v.BuildResponse(It.IsAny<List<ExternalQuationResponse>>())).Returns(new PriceResponse());

            //Act 
            var actualResponse = await _priceEngine.GetPriceAsync(_request);

            _quotationSystemFactoryMock.Verify(q => q.GenerateQutationSystems(It.IsAny<PriceRequest>()), Times.Once, "Validation failed but the method 'GenerateQutationSystems' has not been invoked");
            _quotationSystemsMock.Verify(q => q.GetPriceAsync(It.IsAny<PriceRequest>()), Times.Once);
            _priceReasponseBuilderMock.Verify(q => q.BuildResponse(It.IsAny<List<ExternalQuationResponse>>()), Times.Once, "Validation failed but the method 'BuildResponse' has not been invoked");

        }
    }
}
