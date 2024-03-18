// Goal.cs
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
        public int Value { get; set; }

        public override void UpdateScore()
        {
            if (!Completed)
            {
                Score = Value;
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
        public int Value { get; set; }

        public override void UpdateScore()
        {
            Score += Value;
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

        public override void UpdateScore()
        {
            completedCount++;
            Score += completedCount == TargetCount ? BonusPoints : 0;
            Completed = completedCount == TargetCount;
        }

        public override string DisplayStatus()
        {
            return $"Completed {completedCount}/{TargetCount} times";
        }
    }
}
