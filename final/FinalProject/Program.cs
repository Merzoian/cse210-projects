using System;
using System.Collections.Generic;
using System.Runtime;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Fitness Tracker Program!");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0 || age > 150)
        {
        Console.WriteLine("Invalid age. Please enter a valid age between 0 and 150.");
        Console.Write("Enter your age: ");
        }
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
            Console.WriteLine("2. Meals Ideas");
            Console.WriteLine("3. Add Fitness Goal");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. View Progress");
            Console.WriteLine("6. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter exercise type: strength or cardio: ");
                    string exerciseType = Console.ReadLine();

                    Console.Write("Enter exercise duration (minutes): ");
                    int exerciseDuration = int.Parse(Console.ReadLine());

                    Exercise exercise = new Exercise(exerciseType, exerciseDuration, weight, age);
                    user.AddExercise(exercise);
                    //Calculate and display the calories burned 
                    double caloriesBurned= exercise.CalculateCaloriesBurned();
                    Console.WriteLine($"Calories burned: {caloriesBurned}");

                    break;
                case 2:

                    Console.Write("Enter meal type (Gaining weight or Losing weight): ");
                    string mealType = Console.ReadLine();

                    List<Meal> mealIdeas = Meal.GetMealIdeas(mealType);
                    Console.WriteLine("Recommended meals are as follows: \n");
                    Meal.DisplayMealIdeas(mealIdeas);
                
                    break;
                case 3:
                    Console.Write("Enter fitness goal type (WeightLoss or MuscleGain): ");
                    string goalTypeString = Console.ReadLine();
                    FitnessGoalType goalType = (FitnessGoalType)Enum.Parse(typeof(FitnessGoalType), goalTypeString, true);

                    Console.Write("Enter target value: ");
                    double targetValue = double.Parse(Console.ReadLine());

                    FitnessGoal goal = new FitnessGoal(goalType, targetValue, "Lose weight", 0, false);
                    user.AddFitnessGoal(goal);

                    Console.Write("Enter new progress value: ");
                    double newProgress = double.Parse(Console.ReadLine());

                    goal.UpdateScore();
                    Console.WriteLine($"Progress: {goal.DisplayStatus()}");
                    break;
                case 4:

                    UserProfile.SaveUserProfile(user);
                    
                    Console.WriteLine("User profile saved to file.");
                    break;
                case 5:
                    UserProfile loadedProfile = UserProfile.LoadUserProfile();
                    if (loadedProfile!= null)
                    {
                    Console.WriteLine($"Loaded user profile: {loadedProfile.Name}, Age:{loadedProfile.Age}, Weight:{loadedProfile.Weight}, Height:{loadedProfile.Height}");

                    Console.WriteLine("\nExercises:");
                    foreach (Exercise loadedExercise in loadedProfile.Exercises)
                    {
                    Console.WriteLine($"Type: {loadedExercise.Type}, Duration: {loadedExercise.Duration}, Calories: {loadedExercise.CaloriesBurned}");
                    }

                    Console.WriteLine("\nMeals:");
                    foreach (Meal loadedMeal in loadedProfile.Meals)
                    {
                    Console.WriteLine($"Type: {loadedMeal.Type}");
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
