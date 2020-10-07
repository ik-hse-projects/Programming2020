using System;

partial class Program
{
    static int Factorial(int value)
    {
        if (value == 0)
        {
            return 1;
        }

        return Factorial(value - 1) * value;
    }

    static bool IsInputNumberCorrect(int number)
    {
        return number >= 0;
    }
}