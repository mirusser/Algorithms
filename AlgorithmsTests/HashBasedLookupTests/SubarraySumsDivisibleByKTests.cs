using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class SubarraySumsDivisibleByKTests
{
    public static TheoryData<int[], int, int> SubarraySumsDivisibleByKTestCases
        => new()
        {
            { [4, 5, 0, -2, -3, 1], 5, 7 }, // sample / mixed values

            { [5], 5, 1 }, // single element divisible
            { [3], 5, 0 }, // single element not divisible

            { [0], 5, 1 }, // single zero always divisible
            { [0, 0, 0], 3, 6 }, // all zeros: 3*4/2 = 6

            { [-5], 5, 1 }, // negative single element divisible
            { [-1, 2, 9], 2, 2 }, // negatives + modulo handling

            { [1, 2, 3], 7, 0 }, // no subarray sum divisible by k
            { [1, 2, 3], 1, 6 }, // k = 1 => all subarrays divisible (n*(n+1)/2)

            { [2, 2, 2, 2], 2, 10 }, // all subarrays divisible: 4*5/2 = 10
            { [5, -5, 5, -5], 5, 10 }, // many divisible due to cancellations

            { [], 5, 0 }, // empty input 
        };

    [Theory]
    [MemberData(nameof(SubarraySumsDivisibleByKTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] nums, int k, int expected)
    {
        // Arrange
        var sut = new SubarraySumsDivisibleByK();

        // Act
        var result = sut.Implementation(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
}