using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    public class Program
    {
        private static int totalPoints = 0;

        public static void Main()
        {
            Console.WriteLine($"You have {totalPoints} points.");

            User user = new User("John");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create new Goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Save goals");
                Console.WriteLine("4. Load goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Display score");
                Console.WriteLine("7. Quit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateNewGoal(user);
                        break;
                    case 2:
                        user.DisplayGoals();
                        break;
                    case 3:
                        SaveGoals(user.Goals);
                        Console.WriteLine("Saving goals...");
                        Console.WriteLine("Goal saved");
                        break;
                    case 4:
                        user.Goals = LoadGoals();
                        Console.WriteLine("Loading goals...");
                        break;
                    case 5:
                        RecordEvent(user);
                        break;
                    case 6:
                        Console.WriteLine($"Total Score: {totalPoints}");
                        break;
                    case 7:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private static void CreateNewGoal(User user)
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            int type;
            if (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Console.WriteLine("Enter goal description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter amount of points associated with this goal:");
            int points;
            if (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Goal goal = null;
            switch (type)
            {
                case 1:
                    goal = new SimpleGoal { Description = description, Score = points, Completed = false };
                    break;
                case 2:
                    goal = new EternalGoal { Description = description, Score = points, Completed = false };
                    break;
                case 3:
                    Console.WriteLine("Enter target count for checklist goal:");
                    int targetCount;
                    if (!int.TryParse(Console.ReadLine(), out targetCount))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        return;
                    }

                    Console.WriteLine("Enter bonus points for checklist goal:");
                    int bonusPoints;
                    if (!int.TryParse(Console.ReadLine(), out bonusPoints))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        return;
                    }

                    goal = new ChecklistGoal { Description = description, Score = points, Completed = false, TargetCount = targetCount, BonusPoints = bonusPoints };
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Please select a valid option.");
                    break;
            }

            if (goal != null)
            {
                user.AddGoal(goal);
                Console.WriteLine("Goal created successfully.");
            }
        }

        private static void SaveGoals(List<Goal> goals)
        {
            Console.WriteLine("Enter the filename to save the goals:");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Goal goal in goals)
                {
                    writer.WriteLine($"{goal.Description},{goal.Score},{goal.Completed},{(goal is ChecklistGoal ? ((ChecklistGoal)goal).TargetCount + "," + ((ChecklistGoal)goal).BonusPoints : "")}");
                }
            }
        }

        private static List<Goal> LoadGoals()
        {
            Console.WriteLine("Enter the filename to load the goals:");
            string fileName = Console.ReadLine();

            List<Goal> goals = new List<Goal>();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3)
                {
                    Console.WriteLine("Invalid goal format in file.");
                    return new List<Goal>();
                }

                string description = parts[0];
                int score;
                if (!int.TryParse(parts[1], out score))
                {
                    Console.WriteLine("Invalid score format in file.");
                    return new List<Goal>();
                }

                bool completed;
                if (!bool.TryParse(parts[2], out completed))
                {
                    Console.WriteLine("Invalid completed format in file.");
                    return new List<Goal>();
                }

                Goal goal = null;
                if (parts.Length == 3)
                {
                    goal = new EternalGoal { Description = description, Score = score, Completed = completed };
                }
                else if (parts.Length == 4)
                {
                    goal = new SimpleGoal { Description = description, Score = score, Completed = completed };
                }
                else if (parts.Length == 5)
                {
                    int targetCount;
                    if (!int.TryParse(parts[3], out targetCount))
                    {
                        Console.WriteLine("Invalid target count format in file.");
                        return new List<Goal>();
                    }

                    int bonusPoints;
                    if (!int.TryParse(parts[4], out bonusPoints))
                    {
                        Console.WriteLine("Invalid bonus points format in file.");
                        return new List<Goal>();
                    }

                    goal = new ChecklistGoal { Description = description, Score = score, Completed = completed, TargetCount = targetCount, BonusPoints = bonusPoints };
                }
                else
                {
                    Console.WriteLine("Invalid goal format in file.");
                    return new List<Goal>();
                }

                goals.Add(goal);
            }

            return goals;
        }

        private static void RecordEvent(User user)
        {
            Console.WriteLine("Select goal to record event for:");
            user.DisplayGoals();

            int index;
            if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > user.Goals.Count)
            {
                Console.WriteLine("Invalid goal selection. Please enter a valid number.");
                return;
            }

            Goal goal = user.Goals[index - 1];
            if (!goal.Completed)
            {
                goal.Completed = true;
                totalPoints += goal.Score;
            }

            Console.WriteLine("Event recorded successfully.");
        }
    }
}
