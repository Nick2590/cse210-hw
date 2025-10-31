using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradePercentage = int.Parse(grade);

        if (gradePercentage >= 90)
        {
            Console.WriteLine("Your letter grade is: A");
        }
        else if (gradePercentage >= 80)
        {
            Console.WriteLine("Your letter grade is: B");
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine("Your letter grade is: C");
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine("Your letter grade is: D");
        }
        else
        {
            Console.WriteLine("Your letter grade is: F");
        }

    }
}