
// this game is for user to guss the magic number
// and if they guess correctly, then they will get a prize.
using System;

class Program 
{
   
    static void Main (string[] args)
    {

    Random randomGenerator = new Random();
    int magicNumber = randomGenerator.Next(10, 220);

    int guess = -1;

    while(guess != magicNumber)
    {
        Console.Write("guess the magic numebr: " );
        guess = int.Parse(Console.ReadLine());

        if (magicNumber > guess)
        {
            Console.WriteLine("higher");

        }
        else if( magicNumber < guess)
        {
            Console.WriteLine("lower");

        }
        else
        {
            Console.WriteLine("Your guessed it!");
        }
}

    }
}