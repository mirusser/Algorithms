using TestConsole.Sorting_Scan;

namespace AlgorithmsTests.Sorting_Scan;

public class MergeIntervalsTests
{
    public static TheoryData<int[][], int[][]> MergeIntervalsTestCases
        => new()
        {
            // Classic overlap: [1,3] overlaps [2,6]
            { [[1, 3], [2, 6], [8, 10], [15, 18]], [[1, 6], [8, 10], [15, 18]] },

            // Touching endpoints should merge (if your rule is "overlap or touch")
            { [[1, 4], [4, 5]], [[1, 5]] },

            // Already merged / no overlaps (still should return sorted by start)
            { [[1, 2], [3, 4], [6, 7]], [[1, 2], [3, 4], [6, 7]] },

            // Unsorted input should still work after sorting
            { [[5, 7], [1, 2], [3, 4]], [[1, 2], [3, 4], [5, 7]] },

            // Nested interval: inner fully contained in outer
            { [[1, 10], [2, 3], [4, 8]], [[1, 10]] },
            //
            // Duplicate intervals
            { [[1, 3], [1, 3], [1, 3]], [[1, 3]] },

            // Multiple merges into one chain
            { [[1, 4], [2, 5], [7, 9], [8, 10]], [[1, 5], [7, 10]] },

            // Negative values and overlap
            { [[-10, -5], [-7, -3], [0, 2]], [[-10, -3], [0, 2]] },

            // Single interval
            { [[2, 3]], [[2, 3]] },

            // Empty input
            { [], [] },

            // Point intervals and merging
            { [[2, 2], [2, 3]], [[2, 3]] },

            // Same start, different ends: tests sort tie-breaker correctness
            { [[1, 4], [1, 5], [1, 3]], [[1, 5]] },
        };

    [Theory]
    [MemberData(nameof(MergeIntervalsTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[][] intervals, int[][] expected)
    {
        // Arrange
        var sut = new MergeIntervals();

        // Act
        var result = sut.Implementation(intervals);

        // Assert
        AssertIntervalsEqual(expected, result);
    }

    private static void AssertIntervalsEqual(int[][] expected, int[][] actual)
    {
        Assert.Equal(expected.Length, actual.Length);

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i].Length, actual[i].Length);
            Assert.Equal(expected[i][0], actual[i][0]);
            Assert.Equal(expected[i][1], actual[i][1]);
        }
    }

    // Optional: contract tests (recommended if you plan to throw)
    //[Fact]
    //public void ThrowsArgumentNullException_WhenIntervalsIsNull()
    //{
    //    var sut = new MergeIntervals();
    //    Assert.Throws<ArgumentNullException>(() => sut.Implementation(null!));
    //}

    // Optional: invalid interval where start > end (only if you choose to validate)
    //[Fact]
    //public void ThrowsArgumentException_WhenAnIntervalIsInvalid()
    //{
    //    var sut = new MergeIntervals();
    //    Assert.Throws<ArgumentException>(() => sut.Implementation([[5, 3]]));
    //}
}