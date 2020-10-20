using System;

partial class Program
{
    private static double FastPow(double n, uint k)
    {
        if (k == 0)
        {
            return 1;
        }

        if (k == 1)
        {
            return n;
        }
        
        if (n == 0)
        {
            return 0;
        }

        if (k % 2 == 0)
        {
            var t = FastPow(n, k / 2);
            return t * t;
        }
        else
        {
            var t = FastPow(n, k - 1);
            return n * t;
        }
    }

    public static void Main(string[] args)
    {
        var nOk = double.TryParse(Console.ReadLine(), out var n);
        var kOk = int.TryParse(Console.ReadLine(), out var k);
        var parsed = nOk && kOk;
        if (!parsed || (k < 0))
        {
            Console.WriteLine("Incorrect input");
        }
        else
        {
            Console.WriteLine(FastPow(n, (uint) k));
        }
    }
}