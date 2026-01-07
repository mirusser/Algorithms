namespace TestConsole.HashBasedLookup;

public class LongestSubstring
{
    // Exercise: Longest Substring Without Repeating Characters
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        Dictionary<char, int> lastSeenIndex = [];
        int maxLength = 0, leftIndex = 0;

        for (var rightIndex = 0; rightIndex < s.Length; rightIndex++)
        {
            var character = s[rightIndex];
            if (lastSeenIndex.TryGetValue(character, out int index))
            {
                leftIndex = Math.Max(leftIndex, index + 1);
            }

            var currentLength = rightIndex - leftIndex + 1;
            maxLength = Math.Max(maxLength, currentLength);
            lastSeenIndex[character] = rightIndex;
        }

        return maxLength;
    }
}