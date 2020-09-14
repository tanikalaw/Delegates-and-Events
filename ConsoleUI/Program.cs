using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            Console.WriteLine($"The total for the cart is {cart.TotalItems(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");
           
            Console.WriteLine();

            //creating anonymous delegate - inline code
            decimal total = cart.TotalItems((subTotal) => Console.WriteLine($"The subtotal for cart 2 is {subTotal:C2}"),
               (products, subTotal) =>
               { 
               if (products.Count > 3)
                   {
                      return subTotal * 0.5M;
                   }
               else
                   {
                       return subTotal;
                   }},
               (message) => Console.WriteLine($"Cart 2 alert {message}") );

            Console.WriteLine($"The total for cart2 is {total:C2}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit the application...");
            Console.ReadKey();
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;

            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;

            }
            else if (subTotal > 10)
            {

                return subTotal * 0.90M;
            }
            else
            {
                return subTotal;
            }
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is  {subTotal:C2}");
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
