using TestConsole.SlidingWindow;

namespace AlgorithmsTests.SlidingWindow;

public class MaxSumSubarrayOfKTests
{
    public static TheoryData<int[], int, int> MaxSumSubarrayOfKTestCases
        => new()
        {
            { [2, 1, 5, 1, 3, 2], 3, 9 }, // [5, 1, 3] => 9 (classic example)

            { [2, 3, 4, 1, 5], 2, 7 }, // [3, 4] => 7

            { [1, -1, 5, -2, 3], 2, 4 }, // [5, -1] => 4 (handles negatives)

            { [5], 1, 5 }, // single element, k=1

            { [1, 2, 3], 3, 6 }, // k equals array length => whole sum

            { [1, 2, 3, 4], 1, 4 }, // k=1 => max element

            { [-5, -2, -3, -4], 2, -5 }, // all negatives: max is “least negative” window [-2,-3] => -5

            { [0, 0, 0, 0], 2, 0 }, // all zeros

            { [1, 1, 1, 1, 1], 3, 3 }, // duplicates, any window => 3

            { [10, -1, -1, -1, 10], 2, 9 }, // best window at ends: [10,-1] or [-1,10] => 9
        };


    [Theory]
    [MemberData(nameof(MaxSumSubarrayOfKTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] nums, int k, int expected)
    {
        // Arrange
        var sut = new MaxSumSubarrayOfK();

        // Act
        var result = sut.Implementation(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThrowsArgumentNullException_WhenArrayIsNull()
    {
        // Arrange
        var sut = new MaxSumSubarrayOfK();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => sut.Implementation(null!, 3));
    }

    [Fact]
    public void ThrowsArgumentOutOfRangeException_WhenKIsZero()
    {
        // Arrange
        var sut = new MaxSumSubarrayOfK();
        var nums = new[] { 1, 2, 3 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Implementation(nums, 0));
    }

    [Fact]
    public void ThrowsArgumentOutOfRangeException_WhenKIsNegative()
    {
        // Arrange
        var sut = new MaxSumSubarrayOfK();
        var nums = new[] { 1, 2, 3 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Implementation(nums, -1));
    }

    [Fact]
    public void ThrowsArgumentOutOfRangeException_WhenKIsGreaterThanArrayLength()
    {
        // Arrange
        var sut = new MaxSumSubarrayOfK();
        var nums = new[] { 1, 2, 3 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Implementation(nums, 4));
    }
}