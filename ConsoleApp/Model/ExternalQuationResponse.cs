using System.Collections.Generic;

namespace ConsoleApp1.Model
{
    public class ExternalQuationResponse
    {
        public bool IsSuccessful { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public string InsurerName { get; set; }
        public List<string> ErrorMessage { get; set; }

    }
}
