using System.Collections.Generic;
using System.Linq;

partial class Program
{
    private static string Encrypt(string input)
    {
        if (input.Length == 0)
        {
            return "";
        }
        
        var symbols = new Dictionary<char, int>();
        foreach (var sym in input)
        {
            if (symbols.TryGetValue(sym, out var count))
            {
                symbols[sym] = count + 1;
            }
            else
            {
                symbols[sym] = 1;
            }
        }

        var ordered = symbols
            .OrderBy(i => i.Value)
            .Select(i => i.Key)
            .ToArray();
        var rare = ordered.First();
        var often = ordered.Last();

        var result = new char[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            var sym = input[i];
            if (sym == rare)
            {
                result[i] = often;
            }
            else if (sym == often)
            {
                result[i] = rare;
            }
            else
            {
                result[i] = sym;
            }
        }
        return new string(result);
    }
}
