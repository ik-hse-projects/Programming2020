using System;

public abstract class Function
{
    public static Function GetFunction(string functionName)
    {
        return functionName switch
        {
            "Parabola" => new Parabola(),
            "Exp" => new Exponent(),
            "Sin" => new Sin(),
            _ => throw new ArgumentException("Incorrect input")
        };
    }

    public abstract double GetValueInX(double x);

    public static double SolveIntegral(Function func, double left, double right, double step)
    {
        if (left >= right)
        {
            throw new ArgumentException("Left border greater than right");
        }

        if (!double.IsFinite(func.GetValueInX(left)) || !double.IsFinite(func.GetValueInX(right)))
        {
            throw new ArgumentException("Function is not defined in point");
        }

        var result = 0d;
        var l = func.GetValueInX(left);
        for (double x = left + step; x <= right; x += step)
        {
            var r = func.GetValueInX(x);
            result += step * (l + r) / 2;
            l = r;
        }

        return result;
    }
}