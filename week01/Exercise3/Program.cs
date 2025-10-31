using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 10);

        Console.Write("What is your guess? ");
        string userInput = Console.ReadLine();
        int magicNumber = int.Parse(userInput);

        while (magicNumber != number)
        {
            if (magicNumber < number)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                break;}

            Console.Write("What is your guess? ");
            userInput = Console.ReadLine();
            magicNumber = int.Parse(userInput);
        }

        Console.WriteLine("You guessed it!");
    }
}