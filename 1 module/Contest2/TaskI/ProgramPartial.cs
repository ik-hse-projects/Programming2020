partial class Program
{
    // Проверка входных чисел на корректность
    static bool Validate(int a)
    {
        return a > 0;
    }

    static int GetPerfectNumber(int a)
    {
        while (DivisorsSum(a) != a)
        {
            a++;
        }

        return a;
    }

    static int DivisorsSum(int n)
    {
        var result = 0;
        for (var i = 1; i < n; i++)
        {
            if (n % i == 0)
            {
                result += i;
            }
        }
        return result;
    }
  
}
