using System;
using System.Linq;

internal static class Program
{
    private static void Main(string[] args)
    {
        var row = Console.ReadLine().Split(',');
        for (int i = 0; i < row.Length; i++)
        {
            var shifted = row.Skip(i).Concat(row.Take(i));
            Console.WriteLine(string.Join("", shifted));
        }
    }
}