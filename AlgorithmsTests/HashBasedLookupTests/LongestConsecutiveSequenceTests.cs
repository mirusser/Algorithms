using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class LongestConsecutiveSequenceTests
{
    public static TheoryData<int[], int> LongestConsecutiveSequenceTestCases
        => new()
        {
            { [100, 4, 200, 1, 3, 2], 4 }, // Sequence: 1..4
            { [0, 3, 7, 2, 5, 8, 4, 6, 0, 1], 9 }, // Sequence: 0..8
            { [1, 2, 0, 1], 3 }, // Sequence: 0..2
            { [9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 2], 7 }, // Sequence: -1..5
            { [], 0 }, // Sequence: Empty array
            { [5], 1 }, // Sequence: 5 (single number)
            { [int.MaxValue - 1, int.MaxValue], 2 }, // overflow sanity check
        };

    [Theory]
    [MemberData(nameof(LongestConsecutiveSequenceTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] nums, int expected)
    {
        // Arrange
        var sut = new LongestConsecutiveSequence();

        // Act
        var result = sut.Implementation(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}