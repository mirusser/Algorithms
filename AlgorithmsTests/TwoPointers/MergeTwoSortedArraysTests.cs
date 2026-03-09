using TestConsole.TwoPointers;

namespace AlgorithmsTests.TwoPointers;

public class MergeTwoSortedArraysTests
{
    public static TheoryData<int[], int[], int[]> TestCases
        => new()
        {
            // Base case:
            { [1, 3, 5], [2, 4, 6], [1, 2, 3, 4, 5, 6] },

            // One array empty:
            { [], [1, 2, 3], [1, 2, 3] },
            { [1, 2, 3], [], [1, 2, 3] },

            // Both arrays empty:
            { [], [], [] },

            // Different lengths:
            { [1, 3], [2, 4, 6, 8], [1, 2, 3, 4, 6, 8] },
            { [1, 2, 7, 9], [3], [1, 2, 3, 7, 9] },

            // All elements from A come before all elements from B:
            { [1, 2, 3], [4, 5, 6], [1, 2, 3, 4, 5, 6] },

            // All elements from B come before all elements from A:
            { [4, 5, 6], [1, 2, 3], [1, 2, 3, 4, 5, 6] },

            // Interleaved values:
            { [1, 4, 7], [2, 3, 8], [1, 2, 3, 4, 7, 8] },

            // Duplicate values across both arrays:
            { [1, 3, 5], [1, 3, 5], [1, 1, 3, 3, 5, 5] },

            // Duplicate values within one or both arrays:
            { [1, 1, 2], [1, 3, 3], [1, 1, 1, 2, 3, 3] },

            // Repeated identical values:
            { [2, 2, 2], [2, 2], [2, 2, 2, 2, 2] },

            // Negative numbers:
            { [-5, -3, -1], [-4, -2, 0], [-5, -4, -3, -2, -1, 0] },

            // Negative and positive mix:
            { [-10, -1, 3], [-5, 0, 4], [-10, -5, -1, 0, 3, 4] },

            // Single-element arrays:
            { [1], [2], [1, 2] },
            { [2], [1], [1, 2] },

            // One single-element array merged into a larger one:
            { [1], [2, 3, 4], [1, 2, 3, 4] },
            { [2, 3, 4], [1], [1, 2, 3, 4] },

            // Boundary-ish integer values:
            { [int.MinValue, 0], [int.MaxValue], [int.MinValue, 0, int.MaxValue] },
            { [int.MinValue], [int.MaxValue], [int.MinValue, int.MaxValue] }
        };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] arrayA, int[] arrayB, int[] expected)
    {
        // Arrange
        var sut = new MergeTwoSortedArrays();

        // Act
        var result = sut.Implementation(arrayA, arrayB);

        // Assert
        Assert.Equal(expected, result);
    }
}