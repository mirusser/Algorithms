using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class FirstNonRepeatingCharacterTests
{
    public static TheoryData<string, int> FirstNonRepeatingCharacterTestCases
        => new()
        {
            { "leetcode", 0 },        // first unique character at start ('l')
            { "loveleetcode", 2 },    // first unique character in middle ('v')
            { "aabb", -1 },           // no unique characters
            { "z", 0 },               // single character
            { "", -1 },               // empty string
            { "aabbccd", 6 },         // unique character at the end
            { "aA", 0 },              // case-sensitive: 'a' != 'A'
            { "swiss", 1 },           // first unique character ('w')
            { "!!@@#", 4 },           // symbols: '#' is unique
        };

    [Theory]
    [MemberData(nameof(FirstNonRepeatingCharacterTestCases))]
    public void ReturnsIndexOfFirstUniqueCharacterTest(string nums, int expected)
    {
        // Arrange
        var sut = new FirstNonRepeatingCharacter();

        // Act
        var result = sut.FirstUniqueCharIndex(nums);

        // Arrange
        Assert.Equal(expected, result);
    }
}