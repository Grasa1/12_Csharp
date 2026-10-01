using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphobe
{
    internal record Laptop(string Brand, string Model, string Processor)
    {
        private string _processor { get; init; } = Processor;
        private int _price { get; set; }
        public int Memory { get; set; }



        public string GetPricesor()
        {
            return _processor;
        }

        public void SetPrice(int price)
        {
            _price = price;
        }

        public void UpdateMemory(int plus)
        {
            Memory = plus;

        }

        public int GetPrice()
        {
            return _price;
        }

      

    }
}
