using System;
using System.Collections.Generic;

public class Meal
{
    public string Type { get; set; }
    public double Calories { get; set; }
    public List<string> Ingredients { get; set; }

    public Meal(string type, double calories, List<string> ingredients)
    {
        Type = type;
        Calories = calories;
        Ingredients = ingredients;
    }

    public Dictionary<string, double> GetCaloriesPerIngredient()
    {
        Dictionary<string, double> caloriesPerIngredient = new Dictionary<string, double>();

        foreach (string ingredient in Ingredients)
        {
            if (!caloriesPerIngredient.ContainsKey(ingredient))
            {
                caloriesPerIngredient[ingredient] = 0.0;
            }

            caloriesPerIngredient[ingredient] += Calories / Ingredients.Count;
        }

        return caloriesPerIngredient;
    }
}
