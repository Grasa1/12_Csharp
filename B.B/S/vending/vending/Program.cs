using static System.Runtime.InteropServices.JavaScript.JSType;

namespace vending
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

           VendingMachine vending1 = new VendingMachine();
            vending1.LoadPoducts("products.txt");
        }
    }
}
