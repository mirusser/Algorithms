namespace TestConsole.HashBasedLookup;

public class GroupAnagrams
{
    // For each string, compute a canonical "signature" by sorting its characters.
    // All anagrams share the same signature, so we can use it as a Dictionary key.
    // Each key maps to a bucket (list) of original strings with that signature.

    // Time: O(n * m log m) where m is average word length; Space: O(n * m).

    public List<List<string>> Implementation(string[] strs)
    {
        Dictionary<string, List<string>> groupedAnagrams = new();

        foreach (var s in strs)
        {
            var key = new string(s.OrderBy(c => c).ToArray());

            if (!groupedAnagrams.TryGetValue(key, out var bucket))
            {
                bucket = [];
                groupedAnagrams[key] = bucket;
            }

            bucket.Add(s);
        }

        return groupedAnagrams.Values.ToList();
    }

    // Very verbose overexplaining:

    // I iterate through each given string in an array of strings
    // then to differentiate strings and compare them later if they are anagrams
    // (each sorted string with the same sequence and length of characters is an anagram)
    // I sort each string and use it as a key (anagram) in dictionary
    // then check if the key (anagram) already exists in the dictionary,
    // if doesn't exist I initiate the key with value for the dictionary
    // if it already exists I add it to the values of the key

    // Use a 26-count signature instead of string sorting.
    public List<List<string>> GroupAnagramsOptimized(string[] strs)
    {
        var map = new Dictionary<string, List<string>>();

        foreach (var s in strs)
        {
            string key = GetStringSignature(s);

            if (!map.TryGetValue(key, out var bucket))
            {
                bucket = [];
                map[key] = bucket;
            }

            bucket.Add(s);
        }

        return map.Values.ToList();

        string GetStringSignature(string s)
        {
            int[] counts = new int[26];

            foreach (char c in s)
            {
                counts[c - 'a']++;
            }

            string key = string.Join('#', counts);

            return key;
        }
    }

    //| Approach        | Time per string | Total Time     | Extra Space |
    //| --------------- | --------------- | -------------- | ----------- |
    //| Sort characters | `O(m log m)`    | `O(n m log m)` | Medium      |
    //| Count signature | `O(m)`          | `O(n m)`       | Lower       |

    // Where:
    // n = number of strings 
    // m = average string length
}