using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

class Program
{
    static void  Main()
    {
        Journal journal  = new Journal();

        //create while loop to show menu entries to the journal .
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal  from a file");
            Console.WriteLine("5.  Exit the program");
            // to convert the value from string to int we use the follwing code
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                                //this statement it control  the flow of our proram based on the user's input
            case 1:// to add
                Console.WriteLine("Enter your response: ");
                string response = Console.ReadLine();
                string prompt = GetRandomPrompt();
                string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//get current time and date
                Entry newEntry = new Entry (prompt, response, date);
                journal.AddEntry(newEntry);
                break;

            case 2:// to display 
            journal.DisplayEntries();
            break;

            case 3: //tosave
            Console.WriteLine("Enter the filename to save the journal:");
            string saveFileName = Console.ReadLine();
            journal.SaveToFile(saveFileName + ".txt");
            break;

            case 4: // to load
            Console.WriteLine("Enter the filename to load the journal:");
            string loadFileName = Console.ReadLine();
            journal.LoadFormFile(loadFileName);
            break;

            case 5: // to end the program
            Environment.Exit(0);
            break;

            default:
            Console.WriteLine("Invalid option!");
            break;

            }
        }

    }
// here we end this program by adding Random Prompts on form of list
   static string GetRandomPrompt()
    {
  //Add your prompts to the list 
   List<string> prompts = new List<string>
        {

        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
            // Add more prompts as needed    
        };

    Random random = new Random();//to read  from the random generator index.
    int index = random.Next(prompts.Count);//to return the random number with a maximum of the number of the items 
    return prompts[index];
    }


}

