using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Computer Engineer";
        job1._company = "Google";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "HR";
        job2._company = "Microsoft";
        job2._startYear = 2023;
        job2._endYear  = 2024;

        Resume myResume = new Resume();
        myResume._name = "Val Marogi";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();



    }
    
}
