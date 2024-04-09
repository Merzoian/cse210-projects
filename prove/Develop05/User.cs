using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class User
    {
        public string Name { get; set; }
        public List<Goal> Goals { get; set; }
        public int Score { get; set; }

        public User(string name)
        {
            Name = name;
            Goals = new List<Goal>();
            Score = 0;
        }

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= Goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }

            Goal goal = Goals[index];
            if (!goal.Completed)
            {
                goal.UpdateScore();
                Score += goal.Score;
                goal.Completed = true;
                Console.WriteLine($"Event recorded successfully. {goal.Description} completed. Score updated.");
            }
            else
            {
                Console.WriteLine($"Goal {goal.Description} is already completed. No points awarded.");
            }
        }

        public void DisplayGoals()
        {
            for (int i = 0; i < Goals.Count; i++)
            {
                Goal goal = Goals[i];
                Console.WriteLine($"{i + 1}. {goal.Description} - {goal.DisplayStatus()} - {goal.Score} points");
            }
        }

        public void SaveGoals(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Goal goal in Goals)
                {
                    if (goal is EternalGoal eternalGoal)
                    {
                        writer.WriteLine($"{goal.Description},{goal.Score},{goal.Completed},{eternalGoal.BonusPoints}");
                    }
                    else if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"{goal.Description},{goal.Score},{goal.Completed},{checklistGoal.TargetCount},{checklistGoal.BonusPoints}");
                    }
                    else
                    {
                        writer.WriteLine($"{goal.Description},{goal.Score},{goal.Completed}");
                    }
                }
            }
            Console.WriteLine($"Goals saved to {filename}.");
        }

        public void LoadGoals(string filename)
        {
            Goals.Clear();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Invalid goal format in file.");
                            return;
                        }

                        string description = parts[0];
                        int score;
                        if (!int.TryParse(parts[1], out score))
                        {
                            Console.WriteLine("Invalid score format in file.");
                            return;
                        }

                        bool completed;
                        if (!bool.TryParse(parts[2], out completed))
                        {
                            Console.WriteLine("Invalid completed format in file.");
                            return;
                        }

                        Goal goal;
                        if (parts.Length == 4)
                        {
                            int bonusPoints;
                            if (!int.TryParse(parts[3], out bonusPoints))
                            {
                                Console.WriteLine("Invalid bonus points format in file.");
                                return;
                            }
                            goal = new EternalGoal(description, score, bonusPoints);
                        }
                        else if (parts.Length == 5)
                        {
                            int targetCount, bonusPoints;
                            if (!int.TryParse(parts[3], out targetCount) || !int.TryParse(parts[4], out bonusPoints))
                            {
                                Console.WriteLine("Invalid target count or bonus points format in file.");
                                return;
                            }
                            goal = new ChecklistGoal(description, score, targetCount, bonusPoints);
                        }
                        else
                        {
                            goal = new SimpleGoal(description, score, completed);
                        }

                        goal.Completed = completed;
                        Goals.Add(goal);
                    }
                }
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine($"Unable to read the file: {e.Message}");
            }
        }
    }
}
