using System;

class Program
{
    static void Main(string[] args)
    {
        if (double.TryParse(Console.ReadLine(), out var x))
        {
            var a = (x * x * x * x) / (1 * 2 * 3 * 4);
            var x3 = x * x * x;
            var sum = a;
            var n = 0;
            var prev = -sum;
            do
            {
                prev = sum;
                a = a * (-x3) / ((3 * n + 5) * (3 * n + 6) * (3 * n + 7));
                sum += a;
                n++;
            } while (Math.Abs(sum - prev) >= double.Epsilon);
            Console.WriteLine(sum);
        }
    }
}