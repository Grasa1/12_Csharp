using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending
{
    internal class Product
    {
        private string code;
        private string name;
        private int price;
        private int stock;
        private ProductCategory category;

        public string Code { get { return code; } }
        public string Name { get { return name; } }
        public int Price { get { return price; } }
        public int Stock { get { return stock; } }
        public ProductCategory Category { get { return category; } }
        public bool IsAvailable
        {
            get
            {
                if (stock >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
             }
        }

        public Product(string code, string name, int price, int stock, ProductCategory category)
        {
            this.code = code;
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.category = category;
        }

        public void Sell()
        {
            stock--;
        }



    }
}
