public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);

        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine("");
        Console.WriteLine("Press any key to begin breathing...");
        
        Console.ReadKey(); // Wait for user to press a key

        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine(); // Add a blank line for spacing

            Console.Write("Start breathing slow in ... ");
            for (int j = 4; j > 0; j--)
            {
                Console.Write($"{j} ");
                System.Threading.Thread.Sleep(1000); // Pause for 1 second
            }
            Console.WriteLine(); // Add a blank line for spacing

            if (i > 1)
            {
                Console.Write("Now breathing out .... ");
                for (int j = 4; j > 1; j--)
                {
                    Console.Write($"{j} ");
                    System.Threading.Thread.Sleep(1000); // Pause for 1 second
                }
                Console.WriteLine(); // Add a blank line for spacing
            }
            else
            {
                Console.WriteLine($"Hold..");
            }

            System.Threading.Thread.Sleep(2000); // Pause for 1 second
        }

        base.End(duration);
    }
}