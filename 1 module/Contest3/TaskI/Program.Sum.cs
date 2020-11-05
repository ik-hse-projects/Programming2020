using System;
using System.IO;
using System.Linq;

partial class Program
{
    private static string GetTextFromFile(string inputPath)
    {
        return File.ReadAllText(inputPath);
    }

    private static int GetSumFromText(string text)
    {
        var result = 0;
        foreach (var word in text.Split(new[] {'\r', '\n', '.', '!', '?', ' ', ','}))
        {
            if (int.TryParse(word, out var n))
            {
                result += n;
            }
        }
        return result;
    }
}
