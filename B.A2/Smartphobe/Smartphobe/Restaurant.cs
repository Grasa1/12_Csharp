using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphobe
{
    public record Restaurant(string Name, string City, string Category)
    {
        private int _averageprice {  get; set; }
        private double _rating { get; set; }




        public void SetRating(double newrating)
        {
            _rating = newrating >= 0 && newrating <= 10 ? newrating : _rating;
        }

        public bool ISExpensive()
        {
            return _averageprice >= 12000;
        }

        public void SetPrice(int price)
        {
            _averageprice = price;
        }

        public double GetRating()
        {
            return _rating;
        }

        public int GetAveragePrice()
        {
            return _averageprice;
        }
    }
}
