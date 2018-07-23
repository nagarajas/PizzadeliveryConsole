using System;
using System.Linq;

namespace PizzaOrderTaking  
{
    public class Order
    {
        public Cart Cart { get;}

        public MenuCard MenuCard { get; }

        public delegate string ChooseMenuItemHandler();
        public Order()
        {
            MenuCard = MenuCard.Instance;
            Cart = Cart.Instance;
            Cart.CartUpdated += Cart_Updated;
        }

        public void DisplayMenuItems(ChooseMenuItemHandler chooseMenuItemHandler)
        {
            var categorywiseItems = MenuCard.Items;
            ConsoleKeyInfo readEscKey;
            do{
                Console.WriteLine("Choose your menu item");

                for (int c = 1; c <= categorywiseItems.Count(); c++)
                {
                    var category=categorywiseItems.ElementAt(c-1);
                    var categoryTitle=category.Type==FoodType.NotApplicable?  category.Category.ToString() : $"{category.Category} - {category.Type}";
                    Console.WriteLine("\n"+categoryTitle);

                    for (int i = 1; i <= category.FoodItems.Count(); i++)
                    {
                        var item=category.FoodItems.ElementAt(i-1);
                        Console.WriteLine($"{c}-{i}. {item.Name} - {item.Size}  {item.Price.ToString("00.00")}");
                    }
                }
               
                Console.WriteLine("\n Choose your Item");
                var selectedItem=chooseMenuItemHandler.Invoke();
                var selectedCategory=Convert.ToInt32(selectedItem.Split('-')[0]);
                var selectedFoodItem=Convert.ToInt32(selectedItem.Split('-')[1]);
                Cart.Add(categorywiseItems.ElementAt(selectedCategory-1).FoodItems.ElementAt(selectedFoodItem-1));

                Console.WriteLine("\n Presss Any Key to add other items, else enter esc. ");
                readEscKey=Console.ReadKey();

            }while(ConsoleKey.Escape!=readEscKey.Key);
        }

        private void Cart_Updated(IFoodItem item, float total)
        {
            Console.WriteLine($"{item.Name} added to the cart. Total = {total.ToString("00.00")}");
        }
    }
}
