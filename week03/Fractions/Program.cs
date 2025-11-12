using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fraction Encapsulation Activity\n");

        // Create fractions using the three constructors
        Fraction f1 = new Fraction();          // 1/1
        Fraction f2 = new Fraction(5);         // 5/1
        Fraction f3 = new Fraction(3, 4);      // 3/4
        Fraction f4 = new Fraction(1, 3);      // 1/3

        // Display results
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Demonstrate setters and getters
        Console.WriteLine("\nUpdating fraction f3...");
        f3.SetTop(6);
        f3.SetBottom(7);
        Console.WriteLine($"Updated: {f3.GetFractionString()} = {f3.GetDecimalValue()}");
    }
}
