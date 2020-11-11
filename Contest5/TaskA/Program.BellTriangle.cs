using System;

partial class Program
{
    static int[][] GetBellTriangle(uint rowCount)
    {
        if (rowCount == 0)
        {
            return new int[0][];
        }

        var result = new int[rowCount][];
        result[0] = new[] {1};
        for (var i = 1; i < rowCount; i++)
        {
            result[i] = new int[i + 1];
            result[i][0] = result[i - 1][i - 1];
            for (int j = 1; j <= i; j++)
            {
                result[i][j] = result[i][j - 1] + result[i - 1][j - 1];
            }
        }

        return result;
    }

    private static void PrintJaggedArray(int[][] array)
    {
        foreach (var row in array)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}