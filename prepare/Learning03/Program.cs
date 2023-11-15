using System;
using Learning03;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();

        Fraction fraction2 = new Fraction(500);

        Fraction fraction3 = new Fraction(500, 150);

        Console.WriteLine();
        Console.WriteLine("Fraction 1");
        Console.WriteLine(fraction.GetDecimalValue());
        Console.WriteLine(fraction.GetFractionString());

        Console.WriteLine();
        Console.WriteLine("Fraction 2");
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction2.GetFractionString());

        Console.WriteLine();
        Console.WriteLine("Fraction 3");
        Console.WriteLine(fraction3.GetDecimalValue());
        Console.WriteLine(fraction3.GetFractionString());

    }
}