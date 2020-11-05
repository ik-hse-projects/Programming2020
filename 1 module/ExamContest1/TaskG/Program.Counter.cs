using System.IO;
using System.Linq;

public static partial class Program
{
    private static int GetCountCapitalLetters(string inputPath)
    {
        return File.ReadAllText(inputPath).Count(char.IsUpper);
    }

    private static void WriteCount(string outputPath, int count)
    {
        File.WriteAllText(outputPath, count.ToString());
    }
}