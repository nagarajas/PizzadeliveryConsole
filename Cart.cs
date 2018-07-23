using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderTaking  
{
    public class Cart
    {
        private static Cart instance;
        private Cart()
        {

        }

        public static Cart Instance => new Cart();

        public delegate void CartUpdatedHandler(IFoodItem item, float total);
        
        public event CartUpdatedHandler CartUpdated;

        public List<FoodItem> Items {get;private set;}
        
        public void Add(FoodItem item)
        {
            Items = Items ?? new List<FoodItem>();
            Items.Add(item);

            CartUpdated?.Invoke(item, Items.Sum(i => i.Price));
        }

        public void Remove(FoodItem item)
        {
            Items?.Remove(item);
            CartUpdated?.Invoke(item,Items.Sum(i => i.Price));
        }

        public void Clear()
        {
            Items?.Clear();
            CartUpdated?.Invoke(null,0);
        }

        public void DisplayCartItems()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Name} - {item.Price.ToString("00.00")}");
            }
        }
    }
}