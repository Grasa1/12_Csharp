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


       public VendingMachine(string filename)
        {
            balance = 0;
            income = 0;
            LoadPoducts(filename);
        }

        public void InsertCoin(int coin)
        {
            balance += coin;
        }

        public int ReturnChange()
        {
            int change = balance;
            balance = 0;
            return change;
        }

        public Product FindProduct(string code)
        {
            foreach (Product product in products)
            {
                if(product.Code == code)
                {
                    return product;
                }

            }
            return null;
           
        }

        public void ListProduct()
        {
            foreach(Product product in products)
            {
                if(product.IsAvailable == true)
                {
                    Console.WriteLine(product.Code, product.Name, product.Price, product.Category);
                }
                {
                    Console.WriteLine(($"{product.Code}, {product.Name}, {product.Price}, {product.Category} Elfogyott");
                }
            }
        }



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

        public void LoadPoducts(string filename)
        {
            List<Product> products = new List<Product>();

                string[] lines = File.ReadAllLines("products.txt");
            foreach (string line in lines)
            {


                string[] parts = lines[0].Split(';');
                int price = int.Parse(parts[2]);
                int stock = int.Parse(parts[3]);
                ProductCategory category = ParseCategory(parts[4]);

                products.Add(new Product(parts[0], parts[1], price, stock, category));

            }


        }
    }
}
