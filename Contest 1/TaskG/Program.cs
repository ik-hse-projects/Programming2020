using System;

class Program
{
    static void Main(string[] args)
    {
        double a;
        Console.WriteLine(
            double.TryParse(Console.ReadLine(), out a) && a >= 0
                ? ((int) ((a - (int) a) * 10)).ToString()
                : "Incorrect input"
        );
    }
}
