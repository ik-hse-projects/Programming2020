using System;

class Program
{
    static void Main(string[] args)
    {
        double n;
        Console.WriteLine(
            !double.TryParse(Console.ReadLine(), out n)
            ? "Incorrect input"
            : Math.Abs(n) - (int) Math.Abs(n) != 0.5  // 1/2 is represented correct using double numbers, so we can not use epsilon
                ? Math.Round(n).ToString()
                : new[] {(int) n, (int) n + Math.Sign(n)}
                    .Single(x => (x & 1) != 0)
                    .ToString()
        );
    }
}
