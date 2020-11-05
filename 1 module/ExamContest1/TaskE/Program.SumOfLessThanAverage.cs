using System;
using System.Linq;

public partial class Program
{
    static bool IsArrayLengthCorrect(int length) => length > 0;

    static bool GenerateArray(int length, out int[] arr)
    {
        arr = new int[length];
        var correct = true;
        for (int i = 0; i < length; i++)
        {
            if (int.TryParse(Console.ReadLine(), out var n))
                arr[i] = n;
            else
                correct = false;
        }

        return correct;
    }

    public static double GetArrayAverage(int[] arr) => arr.Average();

    public static int GetSumOfNumbersLessThanAverage(int[] arr, double average) => arr.Where(n => n < average).Sum();
}