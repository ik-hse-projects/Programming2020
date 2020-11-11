using System;
using System.Linq;
using System.Text;

class Polynom
{
    public static bool TryParsePolynom(string line, out int[] arr)
    {
        var numbers = line.Split(' ');
        arr = new int[numbers.Length];
        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];
            if (!int.TryParse(number, out arr[i]))
            {
                return false;
            }
        }

        return true;
    }

    public static int[] Sum(int[] longer, int[] shorter)
    {
        if (longer.Length < shorter.Length)
        {
            return Sum(shorter, longer);
        }

        var result = longer.ToArray();
        for (int i = 0; i < shorter.Length; i++)
        {
            //result[result.Length - i] = longer[longer.Length - i] + shorter[shorter.Length - i];
            result[i] = longer[i] + shorter[i];
        }

        return result;
    }

    public static int[] Dif(int[] a, int[] b)
    {
        return Sum(a, MultiplyByNumber(b, -1));
    }

    public static int[] MultiplyByNumber(int[] a, int n)
    {
        return a.Select(x => x * n).ToArray();
    }

    public static int[] MultiplyByPolynom(int[] a, int[] b)
    {
        var result = new int[a.Length + b.Length];
        for (int i = 0; i < result.Length; i++)
        {
            // Результат решения системы неравенств
            //     0 ≤ i-k < A
            //     0 ≤ k < B
            // относительно k
            var start = Math.Max(0, i - a.Length + 1);
            var end = Math.Min(i, b.Length - 1);
            
            var sum = 0;
            for (int k = start; k <= end; k++)
            {
                sum += a[i - k] * b[k];
            }

            result[i] = sum;
        }

        return result;
    }

    public static string PolynomToString(int[] polynom)
    {
        if (polynom.All(x => x == 0))
        {
            return "0";
        }
        
        var result = new StringBuilder();
        for (var i = polynom.Length - 1; i >= 0; i--)
        {
            var x = polynom[i];
            if (x == 0)
            {
                continue;
            }

            result.Append(x);
            if (i == 1)
            {
                result.Append("x");
            }
            else if (i != 0)
            {
                result.Append($"x{i}");
            }

            result.Append(" + ");
        }

        result.Remove(result.Length - 3, 3);
        return result.ToString();
    }
}