using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class SumIndicesTests
{
    public static TheoryData<int[], int, int, int> SumIndicesTestCases
        => new()
        {
            { [2, 7, 11, 15], 9, 0, 1 }, // 2 + 7 = 9
            { [3, 2, 4], 6, 1, 2 }, // 2 + 4 = 6
            { [3, 3], 6, 0, 1 }, // duplicates allowed
            { [-1, -2, -3, -4, -5], -8, 2, 4 }, // -3 + -5 = -8
            { [0, 4, 3, 0], 0, 0, 3 }, // 0 + 0 = 0
            { [1, 2, 3, 4], 8, -1, -1 }, // no solution
            { [1], 1, -1, -1 }, // length < 2
            { [], 5, -1, -1 }, // empty array
        };

    [Theory]
    [MemberData(nameof(SumIndicesTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(
        int[] nums,
        int target,
        int expectedIndex1,
        int expectedIndex2)
    {
        // Arrange
        var sut = new SumIndices();

        // Act
        var (index1, index2) = sut.Implementation(nums, target);

        // Assert
        Assert.Equal(expectedIndex1, index1);
        Assert.Equal(expectedIndex2, index2);
    }
}