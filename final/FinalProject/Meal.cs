using System;
using System.Collections.Generic;
using System.Linq;

public class Meal 
{
    private string mealType;

    public string Type { get; set; }
    public double Calories { get; set; }
    public List<string> Ingredients { get; set; }

    public Meal(string type, double calories, List<string> ingredients)
    {
        Type = type;
        Calories = calories;
        Ingredients = ingredients;
    }

    public Meal(string mealType)
    {
        this.mealType = mealType;
    }

    public static List<Meal> GetMealIdeas(string type)
    {
        List<Meal> mealIdeas = new List<Meal>();

        if (type.ToLower() == "losing weight")
        {
            mealIdeas.Add(new Meal("breakfast", 350, new List<string> { "Greek yogurt with berries and honey", "Scrambled eggs with spinach and tomatoes", "Oatmeal with almonds and banana" }));
            mealIdeas.Add(new Meal("lunch", 400, new List<string> { "Grilled chicken salad with vinaigrette", "Quinoa and vegetable stir-fry", "Turkey and avocado wrap with side salad" }));
            mealIdeas.Add(new Meal("dinner", 500, new List<string> { "Grilled salmon with roasted vegetables", "Baked chicken breast with sweet potato", "Vegetable stir-fry with tofu" }));
        }
        else if (type.ToLower() == "gaining weight")
        {
            mealIdeas.Add(new Meal("breakfast", 600, new List<string> { "Protein shake with banana and peanut butter", "Breakfast burrito with sausage and cheese", "Pancakes with syrup and whipped cream" }));
            mealIdeas.Add(new Meal("lunch", 700, new List<string> { "Cheeseburger with fries", "Philly cheesesteak sandwich with chips", "BBQ pulled pork sandwich with coleslaw" }));
            mealIdeas.Add(new Meal("dinner", 800, new List<string> { "Steak with mashed potatoes and gravy", "Lasagna with garlic bread", "Meatball sub with fries" }));
        }
        else
        {
            throw new ArgumentException("Invalid meal type. Please enter 'losing weight' or 'gaining weight'.");
        }

        return mealIdeas;
    }

    public static void DisplayMealIdeas(List<Meal> mealIdeas)
    {
        Console.WriteLine("Meal Ideas:");
        foreach (Meal meal in mealIdeas)
        {
            Console.WriteLine($"\nType: {meal.Type}");
            Console.WriteLine($"Ideas: {string.Join(", ", meal.Ingredients)}");
            Console.WriteLine($"Calories: {meal.Calories}");
        }
    }
}