using TestConsole.TwoPointers;

namespace AlgorithmsTests.TwoPointers;

public class PairWithTargetSumTests
{
    public static TheoryData<int[], int, bool> PairWithTargetSumTestCases
        => new()
        {
            { [1, 2, 3, 4, 6], 6, true },
            { [2, 5, 9, 11], 11, true },
            { [-3, -1, 0, 2, 4], 1, true },
            { [1], 2, false },
            { [], 5, false },

            // Basic "false" cases
            { [1, 2, 3, 4, 6], 13, false }, // no pair
            { [2, 5, 9, 11], 10, false }, // no pair

            // Two elements
            { [3, 8], 11, true },
            { [3, 8], 12, false },

            // Duplicates: can use two different indices
            { [1, 1, 2, 3], 2, true }, // 1 + 1
            { [1, 2, 2, 2, 3], 4, true }, // 2 + 2
            { [1, 2, 3, 4], 2, false }, // cannot use same element twice

            // Zero + negatives
            { [-5, -2, 0, 1, 7], -7, true }, // -5 + -2
            { [-5, -2, 0, 1, 7], 0, false }, // needs 0+0 but only one zero
            { [-1, 0, 0, 2], 0, true }, // 0 + 0

            // Larger spread
            { [-10, -3, 1, 2, 9, 15], 12, true }, // -3 + 15
            { [-10, -3, 1, 2, 9, 15], 100, false },

            // Edge / overflow-awareness (depending on your implementation)
            { [int.MinValue, -1, 0, 1, int.MaxValue], 0, true }, // -1 + 1
            { [int.MinValue, 0, int.MaxValue], -1, true }, // Min + Max = -1
            { [int.MaxValue, int.MaxValue], -2, false },
            { [int.MinValue, int.MinValue], 0, false },
            { [1, 2, 3, 4, 10, 20], 6, true },
            { [1, 2, 3, 4, 10, 20], 30, true },
        };

    [Theory]
    [MemberData(nameof(PairWithTargetSumTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] array, int target, bool expected)
    {
        // Arrange
        var sut = new PairWithTargetSum();

        // Act
        var result = sut.Implementation(array, target);

        // Assert
        Assert.Equal(expected, result);
    }
}