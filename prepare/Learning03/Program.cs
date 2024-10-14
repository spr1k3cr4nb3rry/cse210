using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fract1 = new(); // No values given.
        Fraction fract2 = new(5); // Whole number given.
        Fraction fract3 = new(3, 4); // Numerator and denominator given.

        Console.WriteLine(fract1.GetFractionString());
        Console.WriteLine(fract2.GetFractionString());
        Console.WriteLine(fract3.GetFractionString());

        Console.WriteLine();

        Console.WriteLine(fract1.GetDecimalValue());
        Console.WriteLine(fract2.GetDecimalValue());
        Console.WriteLine(fract3.GetDecimalValue());
    }
}