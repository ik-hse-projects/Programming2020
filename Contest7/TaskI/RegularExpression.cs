using System;
using System.Text.RegularExpressions;

public class RegularExpression
{
    private readonly string regularExpression;

    public RegularExpression(string expression)
    {
        regularExpression = expression
            .Replace("*", "\\*")
            .Replace("+", "\\+")
            .Replace(".", "\\.")
            .Replace("|", "\\|")
            .Replace("{", "\\{")
            .Replace("}", "\\}")
            .Replace("[^", "[\\^")
            .Replace("[!", "[^")
            .Replace("\\?", "ё")
            .Replace("?", ".")
            .Replace("ё", "\\?");
    }

    public string FindAndReplace(string text, string replace)
    {
        replace = replace.Replace("$", "ё");
        for (int i = 1; i < 10; i++)
        {
            replace = replace.Replace($"\\{i}", $"${{{i}}}");
        }

        replace = replace.Replace("ё", "$$");
        
        return System.Text.RegularExpressions.Regex.Replace(text, regularExpression, replace);
    }
}
