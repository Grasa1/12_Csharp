using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphobe
{
    public record Hotel(string Name, string City,  int Stars)
    {
        private int _stars { get; init; } = Stars;
        private int _pricepernight { get; set; }
        public double Rating { get; set; }


        public bool Is4Star()
        {
            return _stars >= 4;
        }

        public void SetPricePerNight(int price)
        {
            _pricepernight = price;
        }

        public int SummaPrice(int night)
        {
            return _pricepernight * night;
        }


    }
    
}
