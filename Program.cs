using System;
using System.Linq;

namespace PizzaOrderTaking  
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Domminos Order Taking System!");
            var order=new Order();
            order.DisplayMenuItems(() => Console.ReadLine());
            order.Cart.DisplayCartItems();

            Console.ReadKey();
        }
    }
}
