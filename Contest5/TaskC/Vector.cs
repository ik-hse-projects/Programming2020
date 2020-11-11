using System.IO;

partial class Program
{
    static bool TryParseVectorFromFile(string filename, out int[] vector)
    {
        var numbers = File.ReadAllText(filename).Split(" ");
        vector = new int[numbers.Length];
        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];
            if (!int.TryParse(number, out vector[i]))
            {
                return false;
            }
        }

        return true;
    }

    static int[,] MakeMatrixFromVector(int[] vector)
    {
        var result = new int[vector.Length, vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            for (int j = 0; j < vector.Length; j++)
            {
                result[i, j] = vector[i] * vector[j];
            }
        }

        return result;
    }

    static void WriteMatrixToFile(int[,] matrix, string filename)
    {
        using var file = new StreamWriter(filename);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                file.Write("{0} ", matrix[i, j]);
            }
            file.Write("{0}\n", matrix[i, matrix.GetUpperBound(1)]);
        }
    }
}