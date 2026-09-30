using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphobe
{
    internal record SmartPhone(String Brand, string Model,  int Releaseyear)
    {
        private int _releaseyear { get; init; } = Releaseyear;
        private int _price { get; set; }
        public double Rating { get; set; }




        public int GetReleaseYear()
        {
            return _releaseyear;
        }

        public void SetPrice(int newprice)
        {
            _price = newprice;
        }

        public void UpdatePice(int percent)
        {
            _price = _price * (100 - percent) / 100;
        }


    }
   
}
