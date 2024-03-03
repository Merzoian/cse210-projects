using System;
using System.Threading;

public class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

   public virtual void Start(int duration)
{
    Console.WriteLine($"Starting {Name}...");
    Console.WriteLine("");
    Console.WriteLine(Description);
    Console.WriteLine("");
    Console.WriteLine($"Setting duration to {duration} seconds.");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.Write($"Prepare to begin in 3 seconds... ");

    // Spinner animation
    string[] spinner = { "|", "/", "-", "\\" };
    int spinnerIndex = 0;
    DateTime endTime = DateTime.Now.AddSeconds(3);
    while (DateTime.Now < endTime)
    {
        Console.Write(spinner[spinnerIndex]);
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Move cursor back
        spinnerIndex = (spinnerIndex + 1) % spinner.Length;
        System.Threading.Thread.Sleep(250); // Pause for 250 milliseconds
    }

    Console.WriteLine("\nBegin activity...");
}

    public virtual void End(int duration)
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed {Name} for {duration} seconds. Great job!");
        Thread.Sleep(3000); // Simulating the activity taking place, in case the user wants to try something else.
    }
}
