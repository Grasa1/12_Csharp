using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending
{
    public class VendingMachine
    {
        private List<Product> products;
        private int balance;
        private int income;

        public int Balance { get { return balance; } }
            public int Income { get { return income; } }

        private ProductCategory ParseCategory(string category)
        {

            switch (category)
            {
                case "Drink":
                    return ProductCategory.Drink;
                        break;

                case "Snack":
                    return ProductCategory.Snack;
                    break;

                case "Food":
                    return ProductCategory.Food;
                    break;


                default:
                    return ProductCategory.Snack;
                    break;
            }


        }
    }
}
