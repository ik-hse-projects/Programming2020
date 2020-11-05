partial class Program
{
    private static double MaxOfThree(double a, double b, double c)
    {
        if (a > b)
        {
            return c > a ? c : a;
        }

        return c > b ? c : b;
    }
}