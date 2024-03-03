using System;
// in the main program , adding list of the activity that the user will choose from.
//useing whiel loop and uf statment

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Maindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit  Application ");

            Console.WriteLine("Choose an activity or exit:");

            string choice = Console.ReadLine();
            if (choice == "1")
            {

            Console.WriteLine("Enter the duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
                //calling function for breathing
            Activity activity = new BreathingActivity();
            activity.Start(duration);
            }
    //         else  if  (choice == "2")
    //         {
    //             //calling reflection function
    //             Console.WriteLine("Enter the duration in seconds:");
    //             int duration = int.Parse(Console.ReadLine());
    //             Activity activity = new ReflecitonActivity();
    //         }
    //         }
    //     }
    // }
        }}}