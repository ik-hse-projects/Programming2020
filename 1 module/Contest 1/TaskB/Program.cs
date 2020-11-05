using System;

class Program
{
    static void Main(string[] args)
    {
       int a, b;
       Console.WriteLine(
           // Using & instead of && to fit into one line and to prevent short-circuit evaluation
           int.TryParse(Console.ReadLine(), out a) & int.TryParse(Console.ReadLine(), out b)
           ? (a - b).ToString()
           : "Incorrect input"
       );
    }
}

