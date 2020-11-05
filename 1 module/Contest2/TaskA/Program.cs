using System;

class Program
{
    static void Main(string[] args)
    {
        if (uint.TryParse(Console.ReadLine(), out var number))
        {
            var result = 0L;
            while (number != 0)
            {
                result += number % 10;
                number /= 10;
            }
            Console.WriteLine($"{result}");
        }
        else
        {
            Console.WriteLine("Incorrect input");
        }
    }
}
