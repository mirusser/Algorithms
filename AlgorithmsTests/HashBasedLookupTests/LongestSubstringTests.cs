using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class LongestSubstringTests
{
    public static TheoryData<string, int> LongestSubstringTestCases
        => new()
        {
            { "abcabcbb", 3 }, // repeated pattern, "abc"
            { "bbbbb", 1 }, // all characters the same
            { "pwwkew", 3 }, // window jump forward, "wke"
            { "", 0 }, // empty string
            { " ", 1 }, // single whitespace character
            { "a", 1 }, // single character
            { "abba", 2 }, // left pointer must not move backward
            { "dvdf", 3 }, // overlapping repeats, "vdf"
            { "aA", 2 }, // case-sensitive characters
            { "abcdef", 6 }, // all characters unique
            { "tmmzuxt", 5 }, // non-trivial jump, "mzuxt"
        };

    [Theory]
    [MemberData(nameof(LongestSubstringTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(string s, int expected)
    {
        // Arrange
        var sut = new LongestSubstring();

        // Act
        var result = sut.LengthOfLongestSubstring(s);

        // Assert
        Assert.Equal(expected, result);
    }
}