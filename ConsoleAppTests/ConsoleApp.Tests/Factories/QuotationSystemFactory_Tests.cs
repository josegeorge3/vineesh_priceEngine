using ConsoleApp1;
using ConsoleApp1.Factories;
using ConsoleApp1.Model;
using ConsoleApp1.QuotationSystems;
using NUnit.Framework;
using System;
using System.Linq;

namespace ConsoleApp.Tests
{
    [TestFixture]
    public class QuotationSystemFactory_Tests
    {
     
        private IQuotationFactory _quotationSystemFactory { get; set; }
        [SetUp]
        public void Initialize()
        { 
            _quotationSystemFactory = new QuotationSystemFactory();
        }



        [Test]
        public void If_DOB_NotNull_Should_Return_QuotationSystem1()
        {
            var request = GeneratePriceRequest();
            request.RiskData.DOB = DateTime.Today.AddMonths(-360);

            var qutationSystem = _quotationSystemFactory.GenerateQutationSystems(request);

            Assert.True(typeof(QuotationSystem1) == qutationSystem[0].GetType(), $" For the request with DBO qutations system generated is {qutationSystem.GetType()}");
            Assert.True(typeof(QuotationSystem3) == qutationSystem[1].GetType(), $" For the request with DBO qutations system generated is {qutationSystem.GetType()}");

        }

        [TestCase("examplemake1", true)]
        [TestCase("examplemake2", true)]
        [TestCase("examplemake3", true)]
        public void If_BasedOnMake_Should_Return_QuotationSystem2(string make,bool isReturnSystemQuationSystem2)
        {
            var request = GeneratePriceRequest();
            request.RiskData.Make = make;

            var qutationSystems = _quotationSystemFactory.GenerateQutationSystems(request);
            qutationSystems.Where(q)


            Assert.AreEqual(typeof(QuotationSystem2) == qutationSystems., isReturnSystemQuationSystem2, 
                $" For the make '{make}' qutations system generated is {qutationSystems.GetType()}");
            Assert.AreEqual(typeof(QuotationSystem3) == qutationSystems[1].GetType(), isReturnSystemQuationSystem2, 
                $" For the make '{make}' qutations system generated is {qutationSystems.GetType()}");
       }


        [TestCase("no make", true)]
        public void If_Based_on_No_Make_Should_Return_QuotationSystem2(string make, bool isReturnSystemQuationSystem2)
        {
            var request = GeneratePriceRequest();
            request.RiskData.Make = make;

            var qutationSystem = _quotationSystemFactory.GenerateQutationSystems(request);

            Assert.AreEqual(typeof(QuotationSystem3) == qutationSystem[0].GetType(), isReturnSystemQuationSystem2, $" For the make '{make}' qutations system generated is {qutationSystem.GetType()}");
        }

        [Test]
        public void If_NoConditionSatisfies_Should_Return_QuotationSystem3()
        {
            var request = GeneratePriceRequest(); 

            var qutationSystem = _quotationSystemFactory.GenerateQutationSystems(request);

            Assert.True(typeof(QuotationSystem3) == qutationSystem[0].GetType() , $" For the default qutations system generated is {qutationSystem.GetType()}"); 
        }




        private PriceRequest GeneratePriceRequest()
        {
            return new PriceRequest { RiskData = new RiskData() };
        }

    }
}
