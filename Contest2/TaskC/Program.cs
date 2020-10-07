using System;

class Program
{
    static void Main(string[] args)
    {
        var isA = int.TryParse(Console.ReadLine(), out var a);
        var isB = int.TryParse(Console.ReadLine(), out var b);
        if (!isA || !isB || a >= b)
        {
            Console.WriteLine("Incorrect input");
            return;
        }

        if (a % 2 != 0)
        {
            a++;
        }

        for (var i = a; i < b; i += 2)
        {
            Console.WriteLine(i);
        }
    }
}
