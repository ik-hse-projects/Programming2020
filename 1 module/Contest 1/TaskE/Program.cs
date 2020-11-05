using System;

class Program
{
    static void Main(string[] args)
    {
        uint a;
        Console.WriteLine(
            !uint.TryParse(Console.ReadLine(), out a) || a < 1000 || a >= 10000
                ? "Incorrect input"
                : a % 10 == a / 1000 && a % 100 / 10 == a % 1000 / 100
                    ? "True"
                    : "False"
        );
    }
}
