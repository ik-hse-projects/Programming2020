using System;

class Program
{
    static void Main(string[] args)
    {
        double x, y;
        Console.WriteLine(
            // Using & instead of && to fit into one line and to prevent short-circuit evaluation
            !(double.TryParse(Console.ReadLine(), out x) & double.TryParse(Console.ReadLine(), out y))
                ? "Incorrect input"
                : x*x + y*y >= 1 && x*x + y*y <= 2
                    ? "True"
                    : "False"
        );
    }
}
