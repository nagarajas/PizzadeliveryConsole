using System.Collections.Generic;

namespace PizzaOrderTaking  
{    
    public class MenuItem
    {
        public FoodCategory Category { get; set; }

        public FoodType Type {  get; set;   }

        public List<FoodItem> FoodItems {get;set;}
    }
}