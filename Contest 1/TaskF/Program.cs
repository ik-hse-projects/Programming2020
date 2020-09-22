using System;

class Program
{
    static void Main(string[] args)
    {
       double a, b;
       Console.WriteLine(
           // Using & instead of && to fit into one line and to prevent short-circuit evaluation
           double.TryParse(Console.ReadLine(), out a) & double.TryParse(Console.ReadLine(), out b)
                                                      & a > 0 & b > 0
               ? Math.Sqrt(a * a + b * b).ToString()
               : "Incorrect input"
       );
    }
}
