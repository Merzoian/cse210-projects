using System;
using System.Collections.Generic;
//Base file Represent a user Profile. personal  information, and tracking of fitness goal, exercise and meals.
public class UserProfile
{
    private string name;
    private int age;
    private double weight;
    private double height;
    public List<Exercise> Exercises { get; }
    public List<Meal> Meals { get; }
    public List<FitnessGoal> FitnessGoals { get; }

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value < 150)
            {
                age = value;
            }
            else
            {
                throw new ArgumentException("Invalid age");
            }
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
            else
            {
                throw new ArgumentException("Weight must be greater than 0");
            }
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value > 0)
            {
                height = value;
            }
            else
            {
                throw new ArgumentException("Height must be greater than 0");
            }
        }
    }

    public UserProfile(string name, int age, double weight, double height)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        Exercises = new List<Exercise>();
        Meals = new List<Meal>();
        FitnessGoals = new List<FitnessGoal>();
    }

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }

    public void RemoveExercise(Exercise exercise)
    {
        Exercises.Remove(exercise);
    }

    public void ListExercises()
    {
        foreach (Exercise exercise in Exercises)
        {
            Console.WriteLine($"Type: {exercise.Type}, Duration: {exercise.Duration}, Calories Burned: {exercise.CaloriesBurned}");
        }
    }

    public void AddMeal(Meal meal)
    {
        Meals.Add(meal);
    }

    public void RemoveMeal(Meal meal)
    {
        Meals.Remove(meal);
    }

    public void ListMeals()
    {
        foreach (Meal meal in Meals)
        {
            Console.WriteLine($"Type: {meal.Type}, Calories: {meal.Calories}, Ingredients: {string.Join(", ", meal.Ingredients)}");
        }
    }

    public void AddFitnessGoal(FitnessGoal goal)
    {
        FitnessGoals.Add(goal);
    }

    public void RemoveFitnessGoal(FitnessGoal goal)
    {
        FitnessGoals.Remove(goal);
    }

    public void ListFitnessGoals()
    {
        foreach (FitnessGoal goal in FitnessGoals)
        {
            Console.WriteLine($"Type: {goal.Type}, Target: {goal.Target}, Progress: {goal.Progress}");
        }
    }
}
