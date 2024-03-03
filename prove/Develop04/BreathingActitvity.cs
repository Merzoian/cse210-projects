
//in this class we will  be using the concept of inheritance,
// to create a new class that inherits properties and methods from an existing class.
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);
        while (duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(5000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(5000);
            duration -= 4;/// repet ever 4 sec
        }
        base.End(duration); //end of the activity
    }
}
