using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderTaking  
{    
    public class FoodItem : IFoodItem
    {
        public FoodItem(string name, FoodCategory category, float price, SizeType size= SizeType.Regular, FoodType foodType=FoodType.NotApplicable)
        {
            Name = name;
            Type = foodType;
            Category=category;    
            Price= price;
            Size = size;
        }

        public string Name { get; }

        public FoodType Type { get; }

        public FoodCategory Category { get;}

        public float Price {get;}

        public SizeType Size {get;}
    }
}