using System;
using System.IO;
using System.Linq;

partial class Program
{
    private static readonly string[] Separators = {" ", ". ", ", ", "? ", "! ", ": ", "; "};

    private static void CountInFile(string filePath, out int linesCount, out int wordsCount, out int charsCount)
    {
        var lines = File.ReadAllLines(filePath);
        wordsCount = lines.Sum(ln => 
            ln.Split(Separators, StringSplitOptions.None).Length
        );
        linesCount = lines.Length;
        charsCount = lines.Sum(ln => ln.Length);
    }
}