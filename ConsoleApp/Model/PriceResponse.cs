using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class PriceResponse
    {
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public string InsurerName { get; set; }
        public List<string> ErrorMessage { get; set; }

    }
}
