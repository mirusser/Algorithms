namespace TestConsole.HashBasedLookup;

public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> frequencies = [];

        for (var i = 0; i < s.Length; i++)
        {
            if (!frequencies.TryAdd(s[i], 1))
            {
                frequencies[s[i]]++;
            }

            if (!frequencies.TryAdd(t[i], -1))
            {
                frequencies[t[i]]--;
            }
        }

        return frequencies.All(f => f.Value == 0);;
    }
}