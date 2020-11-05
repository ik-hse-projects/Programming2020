using System;

partial class Program
{
    private static bool TryParseInput(string inputA, string inputB, out int a, out int b)
    {
        var aOk = int.TryParse(inputA, out a) && a >= 0;
        var bOk = int.TryParse(inputB, out b) && b >= 0;
        return aOk && bOk;
    }

    private static void SwapMaxDigit(ref int a, ref int b)
    {
        var maxA = FindMaxDigit(a);
        var maxB = FindMaxDigit(b);
        
        a = ReplaceDigit(a, maxA, maxB);
        b = ReplaceDigit(b, maxB, maxA);
    }

    private static int ReplaceDigit(int number, int old, int @new)
    {
        return int.Parse(number.ToString().Replace(old.ToString(), @new.ToString()));
    }

    private static int FindMaxDigit(int number)
    {
        var result = 0;
        while (number != 0)
        {
            var digit = number % 10;
            if (digit > result)
            {
                result = digit;
            }

            number /= 10;
        }

        return result;
    }
}