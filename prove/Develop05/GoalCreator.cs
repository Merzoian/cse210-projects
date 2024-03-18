using System;

namespace EternalQuest
{
    public static class GoalCreator
    {
        public static Goal CreateGoal()
        {
            Console.WriteLine("Select the type of goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return CreateSimpleGoal();
                case "2":
                    return CreateEternalGoal();
                case "3":
                    return CreateChecklistGoal();
                default:
                    Console.WriteLine("Invalid choice. Creating a Simple Goal by default.");
                    return CreateSimpleGoal();
            }
        }

        private static Goal CreateSimpleGoal()
        {
            Console.Write("Enter the description of the goal: ");
            string description = Console.ReadLine();
            Console.Write("Enter the points associated with this goal: ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid input. Setting points to 0.");
                points = 0;
            }
            return new SimpleGoal(description, points, false);
        }

        private static Goal CreateEternalGoal()
        {
            Console.Write("Enter the description of the goal: ");
            string description = Console.ReadLine();
            Console.Write("Enter the points associated with this goal: ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid input. Setting points to 0.");
                points = 0;
            }
            Console.Write("Enter the bonus points for completing this goal: ");
            if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
            {
                Console.WriteLine("Invalid input. Setting bonus points to 0.");
                bonusPoints = 0;
            }
            return new EternalGoal(description, points, bonusPoints);
        }

        private static Goal CreateChecklistGoal()
        {
            Console.Write("Enter the description of the goal: ");
            string description = Console.ReadLine();
            Console.Write("Enter the points associated with this goal: ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid input. Setting points to 0.");
                points = 0;
            }
            Console.Write("Enter the target count for completing this goal: ");
            if (!int.TryParse(Console.ReadLine(), out int targetCount))
            {
                Console.WriteLine("Invalid input. Setting target count to 0.");
                targetCount = 0;
            }
            Console.Write("Enter the bonus points for completing this goal: ");
            if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
            {
                Console.WriteLine("Invalid input. Setting bonus points to 0.");
                bonusPoints = 0;
            }
            return new ChecklistGoal(description, points, targetCount, bonusPoints);
        }
    }
}
