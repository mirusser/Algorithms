namespace TestConsole.HashBasedLookup;

public class FirstNonRepeatingCharacter
{
    // Pattern: Hash-based lookup
    // Naive: For each character, scan the rest of the string (O(n^2))
    // Optimized: Count frequencies with a dictionary, then scan once more (O(n))
    // Key Insight: Order matters → scan the original string, not the frequency map

    // I use a dictionary to count how many times each character appears in the string.
    // I make one pass through the string to build this frequency map.
    // Then I iterate through the string a second time, preserving the original order,
    // and return the index of the first character whose frequency is exactly one.
    // If no such character exists, I return -1.
    
    // This method runs in O(n) time with O(n) extra space.
    
    public int FirstUniqueCharIndex(string s)
    {
        Dictionary<char, int> frequencies = [];

        foreach (var character in s)
        {
            if (!frequencies.TryAdd(character, 1))
            {
                frequencies[character]++;
            }
        }

        // Technically I could iterate through dictionary: `frequencies` instead of original string 
        // cause .net implementation of dictionary actually preserve order of added keys
        // but that's an implementation detail,
        // or alternatively I could use OrderedDictionary
        
        for (var i = 0; i < s.Length; i++)
        {
            if (frequencies[s[i]] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}