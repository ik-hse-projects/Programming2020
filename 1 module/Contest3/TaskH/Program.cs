using System;

partial class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "code.cs.txt";
        string outputFilePath = "cleanCode.cs.txt";
        string[] codeWithComments = ReadCodeLines(inputFilePath);
        string[] codeWithoutComments = CleanCode(codeWithComments);
        
        WriteCode(outputFilePath, codeWithoutComments);
    }
}
