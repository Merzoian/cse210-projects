using System;

public class Exercise
{
    public string Type { get; set; }
    public int Duration { get; set; } // in minutes
    public double CaloriesBurned { get; set; }

    public Exercise(string type, int duration, double caloriesBurned)
    {
        Type = type;
        Duration = duration;
        CaloriesBurned = caloriesBurned;
    }

    public double GetAverageCaloriesBurnedPerMinute()
    {
        if (Duration == 0)
        {
            return 0.0; // Prevent division by zero
        }

        return CaloriesBurned / Duration;
    }
}
