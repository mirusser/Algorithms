namespace TestConsole.SlidingWindow;

public class LongestSubstring
{
    // Use a sliding window to find the longest substring without repeating characters.
    // A dictionary stores the last index where each character was seen.
    // When a duplicate appears inside the current window,
    // move the left boundary past the previous occurrence.
    // The window always remains valid, and we track the maximum length seen.
    // Time: O(n), Space: O(n).


    // We maintain a sliding window [leftIndex … rightIndex] such that:
    //
    //      Invariant:
    //          The substring inside the window never contains duplicate characters
    //
    // We expand the window to the right one character at a time.
    // If a duplicate appears, we shrink the window from the left just enough to remove the duplicate.
    //
    // To do this efficiently, we remember where each character was last seen.

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