using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileHandler
{
    private const string FilePath = "Profile.txt";

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
                writer.WriteLine($"Exercise,{exercise.Type},{exercise.Duration},{exercise.CaloriesBurned}");
            }

            foreach (Meal meal in userProfile.Meals)
            {
                writer.WriteLine($"Meal,{meal.Type},{meal.Calories},{string.Join(";", meal.Ingredients)}");
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
                            double caloriesBurned = double.Parse(parts[3]);
                            Exercise exercise = new Exercise(exerciseType, duration, caloriesBurned);
                            userProfile.Exercises.Add(exercise);
                            break;
                        case "Meal":
                            string mealType = parts[1];
                            double calories = double.Parse(parts[2]);
                            List<string> ingredients = parts[3].Split(';').ToList();
                            Meal meal = new Meal(mealType, calories, ingredients);
                            userProfile.Meals.Add(meal);
                            break;
                        case "Goal":
                            string goalType = parts[1];
                            double target = double.Parse(parts[2]);
                            double progress = double.Parse(parts[3]);
                            FitnessGoalType enumType = (FitnessGoalType)Enum.Parse(typeof(FitnessGoalType), goalType);
                            FitnessGoal goal = new FitnessGoal(enumType, target, progress);
                            userProfile.FitnessGoals.Add(goal);
                            break;
                    }
                }
            }
        }

        return userProfile;
    }
}
