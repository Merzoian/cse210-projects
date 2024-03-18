using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Valentina");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Eternal Quest - Goal Tracking Program");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Display Total Score");
                Console.WriteLine("7. Quit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Goal goal = GoalCreator.CreateGoal();
                        user.AddGoal(goal);
                        Console.WriteLine("Goal created successfully.");
                        break;
                    case "2":
                        user.DisplayGoals();
                        break;
                    case "3":
                        Console.Write("Enter the filename to save goals: ");
                        string saveFilename = Console.ReadLine();
                        user.SaveGoals(saveFilename);
                        break;
                    case "4":
                        Console.Write("Enter the filename to load goals: ");
                        string loadFilename = Console.ReadLine();
                        user.LoadGoals(loadFilename);
                        break;
                    case "5":
                        Console.Write("Enter the index of the goal you completed: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            user.RecordEvent(index - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid index.");
                        }
                        break;
                    case "6":
                        Console.WriteLine($"Total Score: {user.Score}");
                        break;
                    case "7":
                        Console.WriteLine("Thank you for using Eternal Quest!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                        break;
                }
            }
        }
    }
}
