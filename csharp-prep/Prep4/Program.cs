using System;
//add list fuction
using System.Collections.Generic;
using System.Reflection.Metadata;

class Program
{

    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        //do -while loop
        int userNumber = -1; 
        while (userNumber !=0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if(userNumber !=0)

            {
                numbers.Add(userNumber);

            }

        }
        //part 1 compute the sum
        int sum = 0;
        foreach(int num in numbers)
        {
            int number = 0;
            sum += number;
        }
     Console.WriteLine($"The sum is: {sum}");
     //part 2 find the avrage
     float average = ((float)sum) / numbers.Count;
     Console.WriteLine($"The average is : {average}");
     //finding the max 
     int max =  numbers[0];
     foreach(int number in numbers)
     {
        if (number > max)
        {
            max=number;
        }
     }
         Console.WriteLine($"The max is :{max}");
    }
    }