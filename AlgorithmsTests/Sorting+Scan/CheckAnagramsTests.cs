using TestConsole.Sorting_Scan;

namespace AlgorithmsTests.Sorting_Scan;

public class CheckAnagramsTests
{
    public static TheoryData<string, string, bool> CheckAnagramsTestCases
        => new()
        {
            { "anagram", "nagaram", true },  // same letters, different order
            { "listen", "silent", true },    // classic anagram pair
            { "rat", "car", false },         // different letters
            { "aacc", "ccac", false },       // same letters but different frequencies
            { "", "", true },                // two empty strings are anagrams
            { "a", "a", true },              // identical single character
            { "ab", "ba", true },            // minimal non-trivial anagram
            { "abc", "ab", false },          // different lengths => false
            { "a", "", false },              // empty vs non-empty => false

            // Case sensitivity (as implemented)
            { "Listen", "silent", false },   // 'L' != 'l'

            // Whitespace and punctuation treated as normal characters (as implemented)
            { "a b", "ab ", true },          // same chars: 'a','b',' ' (space)
            { "a,b", "b,a", true },          // punctuation included
            { "a b", "abb", false },         // different character sets
        };

    [Theory]
    [MemberData(nameof(CheckAnagramsTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(string s, string t, bool expected)
    {
        // Arrange
        var sut = new CheckAnagrams();

        // Act
        var result = sut.Implementation(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
}