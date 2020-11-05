using System;

class Program
{
    static void Main(string[] args)
    {
        var result = 0L;
        int number;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            if (number % 2 != 0)
            {
                result += number;
            }
        } while (number != 0);
        Console.WriteLine(result);
    }
}
