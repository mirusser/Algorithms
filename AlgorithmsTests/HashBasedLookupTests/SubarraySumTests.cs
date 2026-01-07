using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class SubarraySumTests
{
    public static TheoryData<int[], int, int> SubarraySumTestCases =>
        new()
        {
            // Overlapping subarrays: [1,1] occurs twice
            { [1, 1, 1], 2, 2 },

            // Single element equals k
            { [3], 3, 1 },

            // No matching subarrays
            { [1, 2, 3], 7, 0 },

            // Subarray starting at index 0 ([2,3])
            { [2, 3, 1], 5, 1 },

            // Negatives and zeros (multiple matches)
            { [1, -1, 0], 0, 3 },
            { [3, 4, 7, 2, -3, 1, 4, 2], 7, 4 }
        };

    [Theory]
    [MemberData(nameof(SubarraySumTestCases))]
    public void CountsOverlappingSubarrays_Correctly(int[] nums, int k, int expected)
    {
        // Arrange
        var sut = new SubarraySumEqualsK();

        // Act
        var result = sut.Implementation(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}