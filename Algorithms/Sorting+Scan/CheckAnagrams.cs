namespace TestConsole.Sorting_Scan;

public class CheckAnagrams
{
    public bool Implementation(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var sortedS = s.OrderBy(x => x).ToArray();
        var sortedT = t.OrderBy(x => x).ToArray();

        for (var i = 0; i < sortedS.Length; i++)
        {
            if (sortedS[i] != sortedT[i])
            {
                return false;
            }
        }

        return true;
    }
    
    public bool AreAnagramsByFrequency(string word1, string word2)
    {
        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        // Count chars in word1
        foreach (char c in word1)
        {
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }

        // Subtract chars in word2
        foreach (char c in word2)
        {
            if (!counts.TryGetValue(c, out int value))
                return false;

            value--;
            if (value == 0) counts.Remove(c);
            else counts[c] = value;
        }

        return counts.Count == 0;
    }

    public bool AreAnagramsBySorting(string word1, string word2)
    {
        if (word1.Length != word2.Length)
            return false;

        var word1Temp = word1.OrderBy(x => x);
        var word2Temp = word2.OrderBy(x => x);
        
        return word1Temp.SequenceEqual(word2Temp);
    }
}