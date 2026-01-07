using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class ValidAnagramTests
{
    public static TheoryData<string, string, bool> ValidAnagramTestCases
        => new()
        {
            { "anagram", "nagaram", true }, // normal positive
            { "rat", "car", false }, // normal negative
            { "aacc", "ccac", false }, // mismatched counts
            { "", "", true }, // empty strings
            { "aA", "Aa", true }, // case sensitivity
            { "a", "aaa", false }, // different length
            { "a!aa", "aaa!", true }, // symbols / non-letter characters
        };

    [Theory]
    [MemberData(nameof(ValidAnagramTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(string s, string t, bool expected)
    {
        // Arrange
        var sut = new ValidAnagram();

        // Act
        var result = sut.IsAnagram(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
}