using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description) : base(name, description)
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);

        Console.WriteLine("This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.");

        foreach (var prompt in prompts)
        {
            Console.WriteLine(""); // Add a blank line for spacing between questions
            Console.WriteLine(prompt);
            Console.WriteLine(""); // Add a blank line for spacing
            Console.WriteLine("Start listing your items. Type 'next' on a new line to move to the next prompt. Type 'menu' to finish the activity and go back to the menu.");
            Console.WriteLine(""); // Add a blank line for spacing
            Console.WriteLine(""); // Add a blank line for spacing
            List<string> items = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "next" && items.Count > 0)
                {
                    break;
                }
                else if (input.ToLower() == "menu")
                {
                    Console.WriteLine("Returning to the menu...");
                    return;
                }
                else
                {
                    items.Add(input);
                }
            }

            Console.WriteLine($"You listed {items.Count} items:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        base.End(duration);
    }
}
