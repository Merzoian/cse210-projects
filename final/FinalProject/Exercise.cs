public class Exercise : UserProfile
{
    internal object CaloriesBurned;

    public string Type { get; set; }
    public int Duration { get; set; }

    public Exercise(string type, int duration, double weight, int age):  base ( weight, age)
    {
        Type = type;
        Duration = duration;
    }

    public Exercise(string name, int age, double weight, double height) : base(name, age, weight, height)
    {
    }
    public double CalculateCaloriesBurned()
    {
        double caloriesBurned = 0.0;

        if (Type.ToLower() == "cardio")
        {
            caloriesBurned = (0.052 * Weight + 0.63) * Duration;
        }
        else if (Type.ToLower() == "strength")
        {
            caloriesBurned = (0.020 * Weight + 0.35) * Duration;
        }

        return caloriesBurned;
    }
}