using System;

class Program
{
    static void Main(string[] args)
    {
        //base "Assignment" object
        Assignment a1 = new Assignment("Val Marogi", "Multiplication");
        Console.WriteLine(a1.GetSummary());



        //derived class 
        MathAssignment a2 = new MathAssignment("Val Marogi", "Fractions", "705", "8-55");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());


        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }



    }






