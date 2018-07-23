using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderTaking  
{
    public class MenuCard
    {
        private static MenuCard instance;
        private MenuCard()
        {

        }
        
        public static MenuCard Instance => instance = instance ?? new MenuCard();

        public List<MenuItem> Items
        {
            get => FoodItems
                        .GroupBy(m => new { m.Category, m.Type })
                        .Select (y => new MenuItem 
                                        { 
                                              Category=y.Key.Category
                                            , Type= y.Key.Type
                                            , FoodItems=y.ToList()}).ToList();
            
        }

        private List<FoodItem> FoodItems => new List<FoodItem>()
        {
            new FoodItem("MARGHERITA",FoodCategory.Pizza, 200.00f,foodType: FoodType.Veg),
            new FoodItem("MARGHERITA",FoodCategory.Pizza, 300.00f,SizeType.Medium,FoodType.Veg),
            new FoodItem("MARGHERITA",FoodCategory.Pizza, 400.00f,SizeType.Large, FoodType.Veg),
            new FoodItem("PERI-PERI CHICKEN",FoodCategory.Pizza, 250.00f, foodType:FoodType.NonVeg),
            new FoodItem("PERI-PERI CHICKEN",FoodCategory.Pizza, 350.00f,SizeType.Medium,FoodType.NonVeg),
            new FoodItem("PERI-PERI CHICKEN",FoodCategory.Pizza, 450.00f,SizeType.Large,  FoodType.NonVeg),
            new FoodItem("COKE",FoodCategory.Beverage, 40.00f),
            new FoodItem("GARLIC BREADSTICKS",FoodCategory.Sides, 100.00f)
        };
    }
}