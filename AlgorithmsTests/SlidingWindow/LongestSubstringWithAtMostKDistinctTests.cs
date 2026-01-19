using TestConsole.SlidingWindow;

namespace AlgorithmsTests.SlidingWindow;

public class LongestSubstringWithAtMostKDistinctTests
{
    public static TheoryData<string, int, int> LongestSubstringTestCases
        => new()
        {
            { "araaci", 2, 4 }, // "araa" has 2 distinct characters
            { "araaci", 1, 2 }, // "aa"                             
            { "cbbebi", 3, 5 }, // "cbbeb"
            { "abc", 0, 0 }, // No characters allowed
            { "", 2, 0 }, // Empty string
            
            // k >= distinct characters: whole string is valid
            { "abc", 5, 3 }, // k bigger than distinct count => whole string
            
            // All same character
            { "aaaaaa", 1, 6 }, // entire string (1 distinct)
            { "aaaaaa", 0, 0 }, // k=0 => 0 regardless of input
            
            // All unique characters
            { "abcdef", 1, 1 }, // only single-char windows
            { "abcdef", 2, 2 }, // best window size is 2
            { "abcdef", 6, 6 }, // whole string
            
            // Best window is in the middle (common sliding window pitfall)
            { "abaccc", 2, 4 }, // "accc" (a,c) length 4
            
            // Best window at the end
            { "aaabbbcc", 2, 6 }, // "aaabbb" or "bbbcc" => 6
            
            // Requires shrinking multiple times correctly
            { "eceba", 2, 3 }, // "ece" length 3
            
            // Duplicates + switching chars: verifies correct count tracking
            { "aabacbebebe", 3, 7 }, // "cbebebe" length 7 (classic)
            
            { "a", 1, 1 },
            { "abaccc", 2, 4 },
            { "eceba", 2, 3 },
            { "aabacbebebe", 3, 7 },
            { "aaabbbcc", 1, 3 } // "aaa" or "bbb" or "cc" => max 3
        };

    [Theory]
    [MemberData(nameof(LongestSubstringTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(string s, int k, int expected)
    {
        // Arrange
        var sut = new LongestSubstringWithAtMostKDistinct();

        // Act
        var result = sut.Implementation(s, k);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThrowsArgumentNullException_WhenStringIsNull()
    {
        var sut = new LongestSubstringWithAtMostKDistinct();
        Assert.Throws<ArgumentNullException>(() => sut.Implementation(null!, 2));
    }

    [Fact]
    public void ThrowsArgumentOutOfRangeException_WhenKIsNegative()
    {
        var sut = new LongestSubstringWithAtMostKDistinct();
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Implementation("abc", -1));
    }
}