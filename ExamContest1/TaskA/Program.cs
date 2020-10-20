using System;

class Program
{
    public static void Main(string[] args)
    {
        if (short.TryParse(Console.ReadLine(), out var a)
            & short.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine(a ^ b);
        }
        else
        {
            Console.WriteLine("Incorrect input");
        }
    }
}