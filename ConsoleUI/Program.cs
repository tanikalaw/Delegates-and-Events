using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using System.Threading.Tasks;
using DataLibrary;

namespace ConsoleUI
{
    class Program
    {
       static ShoppingCartModel cart = new ShoppingCartModel();

        static void Main(string[] args)
        {
            PopulateOrders();

            Console.WriteLine($"The total amount is {cart.TotalItems():C2}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit the application...");
            Console.ReadKey();
        }

        private static void PopulateOrders()
        {
            cart.Items.Add(new ProductModel { ItemName = "Blueberry", Price = 19.30M });
            cart.Items.Add(new ProductModel { ItemName = "Chocolate", Price = 29.70M });
            cart.Items.Add(new ProductModel { ItemName = "Nuts", Price = 19.30M });
            cart.Items.Add(new ProductModel { ItemName = "Cheese", Price = 29.70M });

        }
    }
}
