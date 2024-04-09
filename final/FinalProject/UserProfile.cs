using System;
using System.Collections.Generic;
using System.Data;
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

    public UserProfile(double weight, int age)
    {
        this.weight = weight;
        this.age = age;
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
            Console.WriteLine($"Type: {exercise.Type}, Duration: {exercise.Duration}, Calories: {exercise.CaloriesBurned}");
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
    private const string FilePath = "profile.txt";

    
    public static void SaveUserProfile(UserProfile userProfile)
    
    {
        using (StreamWriter writer = new StreamWriter(FilePath, false)) // Overwrite file
        {
            writer.WriteLine(userProfile.Name);
            writer.WriteLine(userProfile.Age);
            writer.WriteLine(userProfile.Weight);
            writer.WriteLine(userProfile.Height);

            foreach (Exercise exercise in userProfile.Exercises)
            {
                writer.WriteLine($"Exercise,{exercise.Type},{exercise.Duration}");
            }

            foreach (Meal meal in userProfile.Meals)
            {
                writer.WriteLine($"Meal,{meal.Type}");
            }

            foreach (FitnessGoal goal in userProfile.FitnessGoals)
            {
                writer.WriteLine($"Goal,{goal.Type},{goal.Target},{goal.Progress}");
            }
        }
    }

    public static UserProfile LoadUserProfile()
    {
        if (!File.Exists(FilePath))
        {
            return null;
        }

        UserProfile userProfile = null;

        using (StreamReader reader = new StreamReader(FilePath))
        {
            string name = reader.ReadLine();
            int age = int.Parse(reader.ReadLine());
            double weight = double.Parse(reader.ReadLine());
            double height = double.Parse(reader.ReadLine());

            userProfile = new UserProfile(name, age, weight, height);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 4)
                {
                    string type = parts[0];

                    switch (type)
                    {
                        case "Exercise":
                            string exerciseType = parts[1];
                            int duration = int.Parse(parts[2]);
                            Exercise exercise = new Exercise(exerciseType, duration, age, weight);
                            userProfile.Exercises.Add(exercise);
                            break;
                        case "Meal":
                            string mealType = parts[1];
                            Meal meal = new Meal(mealType);
                            userProfile.Meals.Add(meal);
                            break;
                        
                    
                }
            }
        }

        return userProfile;
    }
}


}