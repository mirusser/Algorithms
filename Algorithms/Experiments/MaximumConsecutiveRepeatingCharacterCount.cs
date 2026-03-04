namespace TestConsole.Experiments;

public class MaximumConsecutiveRepeatingCharacterCount
{
    // Return the length of the longest run of consecutive identical characters in a string.
    
    // Scan the string and count how many times the same character appears in a row.
    // Return the largest count you find.

    // Examples:
    // "aaabbcccaab" → 3
    // "abcd" → 1
    // "" → 0

    public int Implementation(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        
        var maxLength = 1;
        var currentLength = 1;
        
        var previousChar = s[0];
        
        for (var i = 1; i < s.Length; i++)
        {
            var currentChar = s[i];

            if (currentChar == previousChar)
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }
            
            maxLength = Math.Max(maxLength, currentLength);
            
            previousChar = currentChar;
        }

        return maxLength;
    }
}