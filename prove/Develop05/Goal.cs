using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Description { get; set; }
        public int Score { get; set; }
        public bool Completed { get; set; }

        public abstract void UpdateScore();
        public abstract string DisplayStatus();
    }

    public class SimpleGoal : Goal
    {
        public SimpleGoal(string description, int score, bool completed)
        {
            Description = description;
            Score = score;
            Completed = completed;
        }

        public override void UpdateScore()
        {
            if (!Completed)
            {
                Score = 10;
                Completed = true;
            }
        }

        public override string DisplayStatus()
        {
            return Completed ? "[X]" : "[ ]";
        }
    }

    public class EternalGoal : Goal
    {
        public int BonusPoints { get; set; }

        public EternalGoal(string description, int score, int bonusPoints)
        {
            Description = description;
            Score = score;
            BonusPoints = bonusPoints;
            Completed = false;
        }

        public override void UpdateScore()
        {
            Score += BonusPoints;
        }

        public override string DisplayStatus()
        {
            return "[ ]";
        }
    }

    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int BonusPoints { get; set; }
        private int completedCount = 0;

        public ChecklistGoal(string description, int score, int targetCount, int bonusPoints)
        {
            Description = description;
            Score = score;
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            Completed = false;
        }

        public override void UpdateScore()
        {
            completedCount++;
            if (completedCount == TargetCount)
            {
                Score += BonusPoints;
                Completed = true;
            }
        }

        public override string DisplayStatus()
        {
            return $"Completed {completedCount}/{TargetCount} times";
        }
    }
}
