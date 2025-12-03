using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test single square
        Square testSquare = new Square("Red", 5);
        Console.WriteLine($"Square Color: {testSquare.GetColor()}");
        Console.WriteLine($"Square Area: {testSquare.GetArea()}");

        // Create List of Shapes (polymorphism)
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Blue", 4));
        shapes.Add(new Rectangle("Green", 5, 10));
        shapes.Add(new Circle("Yellow", 3));

        Console.WriteLine("\n--- Shape List Output ---");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}
