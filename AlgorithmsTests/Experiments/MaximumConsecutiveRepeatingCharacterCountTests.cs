using TestConsole.Experiments;

namespace AlgorithmsTests.Experiments;

public class MaximumConsecutiveRepeatingCharacterCountTests
{
    public static TheoryData<string, int> ValidTestCases =>
        new()
        {
            { "aaabbcccaab", 3 }, // Longest groups are "aaa" and "ccc".
            { "abcd", 1 }, // No repeated consecutive characters.
            { "aabbbbcd", 4 }, // Longest group is "bbbb".
            { "zzzzzz", 6 }, // Entire string is one group.
            { "", 0 }, // Empty string.
            { "a", 1 }, // Single character.
            { "abccc", 3 }, // Longest run at the end.
            { "aaab", 3 }, // Longest run at the beginning.
            { "aabb", 2 }, // Multiple groups with same max length.
            { "abababab", 1 }, // Alternating characters.
            { "!!???..", 3 }, // Non-letter characters.
            { "aaAA", 2 }, // Case-sensitive: 'a' and 'A' are different.
            { "  aa  ", 2 }, // Whitespace counts as normal characters.
        };

    [Theory]
    [MemberData(nameof(ValidTestCases))]
    public void Implementation_ReturnsExpectedMaxRunLength(string s, int expected)
    {
        // Arrange
        var sut = new MaximumConsecutiveRepeatingCharacterCount();

        // Act
        var result = sut.Implementation(s);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Implementation_WithNullInput_Returns0()
    {
        // Arrange
        var sut = new MaximumConsecutiveRepeatingCharacterCount();

        // Assert
        var result = sut.Implementation(null!);

        // Act 
        Assert.Equal(0, result);
    }

    [Theory]
    [MemberData(nameof(ValidTestCases))]
    public void Implementation_ResultIsNeverNegative(string s, int _)
    {
        // Arrange
        var sut = new MaximumConsecutiveRepeatingCharacterCount();

        // Act
        var result = sut.Implementation(s);

        // Assert
        Assert.True(result >= 0);
    }

    [Theory]
    [MemberData(nameof(ValidTestCases))]
    public void Implementation_ResultDoesNotExceedInputLength(string s, int _)
    {
        // Arrange
        var sut = new MaximumConsecutiveRepeatingCharacterCount();

        // Act
        var result = sut.Implementation(s);

        // Assert
        Assert.True(result <= s.Length);
    }
}