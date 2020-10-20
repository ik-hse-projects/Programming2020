using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

partial class Program
{
    private static string[] ReadCodeLines(string codePath)
    {
        return File.ReadAllLines(codePath);
    }

    private static string[] CleanCode(string[] codeWithComments)
    {
        var isMultiline = false;
        var result = new List<string>();
        foreach (var ln in codeWithComments)
        {
            var isSingleline = false;
	    var isQuote = false;
            var lineWithComment = isMultiline;
            var res = new StringBuilder();
            for (var i=0; i < ln.Length; i++)
            {
                var isNotLast = i+1 < ln.Length;
                if (isSingleline)
                {
                }
                else if (isMultiline)
                {
                    lineWithComment = true;
                    if (isNotLast && ln[i] == '*' && ln[i+1] == '/')
                    {
                        isMultiline = false;
                        i++;
                    }
                }
		else if (ln[i] == '"')
		{
			if (i == 0 || ln[i-1] != '\\')
			{
				isQuote = !isQuote;
			}
			res.Append(ln[i]);
		}
                else if (!isQuote && isNotLast && ln[i] == '/')
                {
                    if (ln[i+1] == '/')
                    {
                        isSingleline = true;
                        lineWithComment = true;
                        i++;
                    }
                    else if (ln[i+1] == '*')
                    {
                        lineWithComment = true;
                        isMultiline = true;
                        i++;
                    }
                    else
                    {
                        res.Append(ln[i]);
                    }
                }
                else
                {
                    res.Append(ln[i]);
                }
            }
            if (!lineWithComment)
            {
                result.Add(res.ToString());
            }
        }
        return result.ToArray();
    }

    private static void WriteCode(string codeFilePath, string[] codeLines)
    {
        File.WriteAllLines(codeFilePath, codeLines);
    }
}
