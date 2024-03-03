using System;
public class Program
{

public static void Main()
{
    Activity[] activities = {
        new BreathingActivity(" Start Breathing Activity", "Relax by breathing in and out slowly."),
        new ReflectionActivity(" Start Reflection Activity", "Reflect on times in your life when you have shown strength and resilience."),
        new ListingActivity(" Start Listing Activity", "Reflect on the good things in your life by listing as many as you can in a certain area.")
    };

    while (true)
    {
        Console.WriteLine("Select an activity:");
        for (int i = 0; i < activities.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name}");
        }

        Console.WriteLine($"{activities.Length + 1}. Quit");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > activities.Length + 1)
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }

        if (choice == activities.Length + 1)
        {
            break;
        }

        Console.WriteLine("Enter the duration in seconds:");
        int duration = int.Parse(Console.ReadLine());

        activities[choice - 1].Start(duration);
    }
}
}


