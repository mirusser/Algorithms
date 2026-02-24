namespace TestConsole.HashBasedLookup;

public class ValidAnagram
{
    // Problem overview:
    // Given two strings s and t, determine whether t is an anagram of s.

    // Two strings are anagrams if they contain the same characters with the same frequencies,
    // just in a different order.
    
    
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

        return frequencies.All(f => f.Value == 0);
    }
}