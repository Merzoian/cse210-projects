using System;

//Base class for all activities

public class Activity
{

public string Name {get; set;}
public string Description {get; set;}

public Activity(string name, string description)
{
    Name = name;
    Description = description;

}

public virtual void Start( int duration)
{
Console.WriteLine($"Starting {Name}...");
Console.WriteLine(Description);
Console.WriteLine($"Setting duration to {duration} seconds.");
Console.WriteLine("Prepare to begain in 3 seconds...");
Thread.Sleep(3000); //simulating the activity taking place
}
public virtual void End(int duration)
{
    Console.WriteLine("Well done!");
    Console.WriteLine($"You have completed {Name} for {duration} seconds. Great job!");
    Thread.Sleep(3000);// simulating the activity taking place, incase the user want to try something else.
}
}