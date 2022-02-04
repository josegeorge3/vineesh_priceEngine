using ConsoleApp1.Model;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //SNIP - collect input (risk data from the user)

            var request = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                }
            };
                  

            var priceEngine = new PriceEngine();
            var priceTask = priceEngine.GetPriceAsync(request);

            Task.WaitAll(priceTask);

            if (priceTask.Result.Price == -1)
            {
                Console.WriteLine(String.Format("There was an error - {0}", String.Join(", ",priceTask.Result.ErrorMessage)));
            }
            else
            {
                Console.WriteLine(String.Format("You price is {0}, from insurer: {1}. This includes tax of {2}", priceTask.Result.Price, priceTask.Result.InsurerName, priceTask.Result.Tax));
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
