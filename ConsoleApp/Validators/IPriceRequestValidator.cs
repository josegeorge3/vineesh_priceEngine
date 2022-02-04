using ConsoleApp1.Model;
using System.Collections.Generic;

namespace ConsoleApp1.Validators
{
    public interface IPriceRequestValidator
    {
        List<string> Validate(PriceRequest request);
    }
}