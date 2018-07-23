namespace PizzaOrderTaking  
{
    public interface IFoodItem
    {
        string Name { get; }

        FoodType Type {get; }

        FoodCategory Category { get; }

        SizeType Size {get;}
        
        float Price {get;}       
    }
}