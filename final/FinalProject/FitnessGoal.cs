using System;

public enum FitnessGoalType
{
    WeightLoss,
    MuscleGain
}

public class FitnessGoal 
{
    public FitnessGoalType Type { get; set; }
    public double Target { get; set; }
    public double Progress { get; set; }

    public FitnessGoal(FitnessGoalType type, double target, double progress)
    {
        Type = type;
        Target = target;
        Progress = progress;
    }

    public double GetProgressPercentage()
    {
        if (Target == 0)
        {
            return 0.0; // Prevent division by zero
        }

        return (Progress / Target) * 100.0;
    }
}
