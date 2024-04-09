using System;

public enum FitnessGoalType
{
    WeightLoss,
    MuscleGain
}

public class FitnessGoal : Goal
{
    public FitnessGoalType Type { get; set; }
    public double Target { get; set; }
    public double Progress { get; set; }

    public FitnessGoal(FitnessGoalType type, double target, string description, int score, bool completed) : base(description, score, completed)
    {
        Type = type;
        Target = target;
        Progress = 0.0;
    }


    public override void UpdateScore()
    {
        if (!Completed)
        {
            Progress = Target;
            Completed = true;
        }
    }

    public override string DisplayStatus()
    {
        return Completed? $"Progress: {Progress}/{Target}" : $"Progress: {Progress}/{Target}";
    }
}
  