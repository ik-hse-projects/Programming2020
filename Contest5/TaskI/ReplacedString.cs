public class ReplacedString
{
    private string replacedString;

    public ReplacedString(string s, string initialSubstring, string finalSubstring)
    {
        string prev;
        do
        {
            prev = s;
            s = s.Replace(initialSubstring, finalSubstring);
        } while (prev != s);

        replacedString = s;
    }

    public override string ToString() => replacedString;
}