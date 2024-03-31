using System;
using System.Collections.Generic;
// The programming class  for the main game logic and user interface 
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Fitness Tracker Program!");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your weight (kg): ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height (cm): ");
        double height = double.Parse(Console.ReadLine());

        UserProfile user = new UserProfile(name, age, weight, height);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add Exercise");
            Console.WriteLine("2. Add Meal");
            Console.WriteLine("3. Add Fitness Goal");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. View Progress");
            Console.WriteLine("6. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter exercise type: ");
                    string exerciseType = Console.ReadLine();

                    Console.Write("Enter exercise duration (minutes): ");
                    int exerciseDuration = int.Parse(Console.ReadLine());

                    Console.Write("Enter calories burned: ");
                    double caloriesBurned = double.Parse(Console.ReadLine());

                    Exercise exercise = new Exercise(exerciseType, exerciseDuration, caloriesBurned);
                    user.AddExercise(exercise);
                    break;
                case 2:
                    Console.Write("Enter meal type: ");
                    string mealType = Console.ReadLine();

                    Console.Write("Enter calories: ");
                    double calories = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter ingredients (comma-separated): ");
                    string[] ingredients = Console.ReadLine().Split(',');
                    List<string> ingredientList = new List<string>(ingredients);

                    Meal meal = new Meal(mealType, calories, ingredientList);
                    user.AddMeal(meal);
                    break;
                case 3:
                    Console.Write("Enter fitness goal type (WeightLoss or MuscleGain): ");
                    string goalTypeString = Console.ReadLine();
                    FitnessGoalType goalType = (FitnessGoalType)Enum.Parse(typeof(FitnessGoalType), goalTypeString, true);

                    Console.Write("Enter target value: ");
                    double targetValue = double.Parse(Console.ReadLine());

                    Console.Write("Enter progress value: ");
                    double progressValue = double.Parse(Console.ReadLine());

                    FitnessGoal goal = new FitnessGoal(goalType, targetValue, progressValue);
                    user.AddFitnessGoal(goal);
                    break;
                case 4:
                    FileHandler.SaveUserProfile(user);
                    Console.WriteLine("User profile saved to file.");
                    break;
                case 5:
                    UserProfile loadedProfile = FileHandler.LoadUserProfile();
                    if (loadedProfile != null)
                    {
                        Console.WriteLine($"Loaded user profile: {loadedProfile.Name}, {loadedProfile.Age}, {loadedProfile.Weight}, {loadedProfile.Height}");

                        Console.WriteLine("\nExercises:");
                        foreach (Exercise loadedExercise in loadedProfile.Exercises)
                        {
                            Console.WriteLine($"Type: {loadedExercise.Type}, Duration: {loadedExercise.Duration}, Calories Burned: {loadedExercise.CaloriesBurned}");
                        }

                        Console.WriteLine("\nMeals:");
                        foreach (Meal loadedMeal in loadedProfile.Meals)
                        {
                            Console.WriteLine($"Type: {loadedMeal.Type}, Calories: {loadedMeal.Calories}, Ingredients: {string.Join(", ", loadedMeal.Ingredients)}");
                        }

                        Console.WriteLine("\nFitness Goals:");
                        foreach (FitnessGoal loadedGoal in loadedProfile.FitnessGoals)
                        {
                            Console.WriteLine($"Type: {loadedGoal.Type}, Target: {loadedGoal.Target}, Progress: {loadedGoal.Progress}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No user profile found.");
                    }
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
