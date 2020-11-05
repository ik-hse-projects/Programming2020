using System;

partial class Program
{
    public static void Main(string[] args)
    {
        if (int.TryParse(Console.ReadLine(), out var a)
            & int.TryParse(Console.ReadLine(), out var b)
            & int.TryParse(Console.ReadLine(), out var c)
            & (a < (b + c)
               && b < (a + c)
               && c < (a + b)))
        {
            Console.WriteLine(a + b + c);
        }
        else
        {
            Console.WriteLine("Incorrect input");
        }
    }
}