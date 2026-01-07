using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class TwoSumTests
{
    public static TheoryData<int[], int, bool> TwoSumTestCases
        => new()
        {
            { [2, 7, 11, 15], 9, true }, // basic positive case (2 + 7)
            { [3, 2, 4], 6, true }, // pair appears later (2 + 4)
            { [3, 3], 6, true }, // same value used twice (distinct indices)
            { [1, 2, 3], 7, false }, // no valid pair
            { [0, 4, 3, 0], 0, true }, // zeros with target zero
            { [-1, -2, -3, -4, -5], -8, true }, // negatives (-3 + -5)
            { [-1, 1], 0, true }, // negative + positive
            { [1], 2, false }, // single element
            { [], 5, false }, // empty array
            { [int.MaxValue, int.MinValue], -1, true }, // extremes, no overflow match
        };


    [Theory]
    [MemberData(nameof(TwoSumTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] nums, int target, bool expected)
    {
        // Arrange
        var sut = new TwoSum();

        // Act
        var result = sut.Implementation(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}