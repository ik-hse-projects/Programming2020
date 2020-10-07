partial class Program
{
    static bool Validate(int n)
    {
        return n >= 0;
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
