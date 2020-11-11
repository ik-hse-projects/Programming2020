using System.IO;
using System.Linq;

internal class Matrix
{
    private readonly int[][] matrix;

    public Matrix(string filename)
    {
        matrix = File
            .ReadLines(filename)
            .Select(line => line
                .Split(';')
                .Select(int.Parse)
                .ToArray())
            .ToArray();
    }

    public int SumOffEvenElements => matrix.SelectMany(x => x).Where(x => x % 2 == 0).Sum();


    public override string ToString()
    {
        return string.Join("", matrix
            .Select(row => string.Join("\t", row) + "\n"));
    }
}