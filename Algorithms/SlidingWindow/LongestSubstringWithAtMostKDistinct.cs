namespace TestConsole.SlidingWindow;

public class LongestSubstringWithAtMostKDistinct
{
    /// <summary>
    /// Returns the length of the longest contiguous substring that contains
    /// at most <paramref name="k"/> distinct characters.
    /// A substring is defined as a sequence of consecutive characters
    /// from the original string.
    /// </summary>
    /// <param name="s">
    /// The input string to analyze. Must not be <c>null</c>.
    /// </param>
    /// <param name="k">
    /// The maximum number of distinct characters allowed in the substring.
    /// Must be greater than or equal to zero.
    /// </param>
    /// <returns>
    /// The maximum length of any contiguous substring of <paramref name="s"/>
    /// that contains at most <paramref name="k"/> distinct characters.
    /// Returns <c>0</c> if <paramref name="s"/> is empty or if <paramref name="k"/> is zero.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="s"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="k"/> is negative.
    /// </exception>
    public int Implementation(string s, int k)
    {
        if (k < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(k));
        }

        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        if (s.Length == 0 || k == 0)
        {
            return 0;
        }

        // initial element
        Dictionary<char, int> distinctCharactersFreq = new() { { s[0], 1 } };

        int left = 0, right = 1, maxLength = 1;

        while (right < s.Length)
        {
            var rightValue = s[right];
            if (distinctCharactersFreq.ContainsKey(rightValue))
            {
                distinctCharactersFreq[rightValue]++;
                right++;
            }
            else if (distinctCharactersFreq.Count < k)
            {
                distinctCharactersFreq.Add(rightValue, 1);
                right++;
            }
            else
            {
                var leftValue = s[left];
                distinctCharactersFreq[leftValue]--;
                if (distinctCharactersFreq[leftValue] == 0)
                {
                    distinctCharactersFreq.Remove(leftValue);
                }
                left++;
            }

            maxLength = Math.Max(maxLength, right - left);
        }

        return maxLength;
    }

    public int StandardSolution(string s, int k)
    {
        if (string.IsNullOrEmpty(s) || k <= 0)
            return 0;

        var freq = new Dictionary<char, int>();
        int left = 0, maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            freq[c] = freq.GetValueOrDefault(c) + 1;

            while (freq.Count > k)
            {
                char leftChar = s[left];
                freq[leftChar]--;
                if (freq[leftChar] == 0)
                {
                    freq.Remove(leftChar);
                }

                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}