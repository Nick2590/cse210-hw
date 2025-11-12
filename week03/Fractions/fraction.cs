using System;

public class Fraction
{
    // Private attributes (encapsulation)
    private int top;
    private int bottom;

    // Constructors
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int top)
    {
        this.top = top;
        bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        this.top = top;
        this.bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return top;
    }

    public void SetTop(int value)
    {
        top = value;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int value)
    {
        bottom = value;
    }

    // Method to return the fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{top}/{bottom}";
    }

    // Method to return the decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)top / (double)bottom;
    }
}
