using System;
public class Program
{
    public static void Main(string[] args)
    {
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        ScriptureReference scriptureRef = new ScriptureReference("Romans 11:33");
        Scripture scripture = new Scripture(scriptureRef, scriptureText);
        scripture.Display();

        Console.WriteLine("Press Enter to hide words (type 'quit' to exit): ");
        string userInput = Console.ReadLine();
        while (!string.Equals(userInput, "quit", StringComparison.OrdinalIgnoreCase) && !scripture.AllWordsHidden())
        {
            scripture.HideRandomWord();
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
            userInput = Console.ReadLine();
        }
    }
}