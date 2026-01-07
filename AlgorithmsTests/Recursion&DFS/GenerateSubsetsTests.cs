using TestConsole.Recursion_DFS;

namespace AlgorithmsTests.Recursion_DFS;

public class GenerateSubsetsTests
{
    public static TheoryData<int[], int[][]> GenerateSubsetsTestCases
        => new()
        {
            { [], [[]] }, // empty input => only empty subset

            { [1], [[], [1]] }, // two subsets

            {
                [1, 2], [
                    [],
                    [1],
                    [2],
                    [1, 2]
                ]
            }, // 2^2 subsets

            {
                [1, 2, 3], [
                    [],
                    [1],
                    [2],
                    [3],
                    [1, 2],
                    [1, 3],
                    [2, 3],
                    [1, 2, 3]
                ]
            }, // 2^3 subsets
        };

    [Theory]
    [MemberData(nameof(GenerateSubsetsTestCases))]
    public void ReturnsExpectedSubsets_ForGivenInputs(int[] nums, int[][] expectedSubsets)
    {
        // Arrange
        var sut = new GenerateSubsets();

        // Act
        var result = sut.Implementation(nums);

        // Assert
        AssertSubsetsEqual(expectedSubsets, result);
    }

    [Fact]
    public void ThrowsArgumentNullException_WhenInputIsNull()
    {
        // Arrange
        var sut = new GenerateSubsets();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => sut.Implementation(null!));
    }

    private static void AssertSubsetsEqual(int[][] expected, IList<IList<int>> actual)
    {
        // same count (2^n) and same elements, ignoring ordering
        Assert.Equal(expected.Length, actual.Count);

        var expectedCanonical = expected
            .Select(sub => string.Join(",", sub.OrderBy(x => x)))
            .OrderBy(x => x)
            .ToArray();

        var actualCanonical = actual
            .Select(sub => string.Join(",", sub.OrderBy(x => x)))
            .OrderBy(x => x)
            .ToArray();

        Assert.Equal(expectedCanonical, actualCanonical);
    }
}
