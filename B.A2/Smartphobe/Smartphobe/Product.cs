using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphobe
{
    public record Product(string Name, string Category, string Manufacturer)
    {
        private int _price {  get; set; }
        private int _stock { get; set; }



        public void UpdaStock(int stock)
        {
            _stock += stock;
        }
        public void Setprice(int price)
        {
            _price = price;
        }

        public int GetStock()
        {
            return _stock;
        }

        public int GetPrice()
        {
            return _price;
        }

        public int SummaPrice()
        {
            return _price * _price;
        }
    }
}
