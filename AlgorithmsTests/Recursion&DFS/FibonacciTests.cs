using TestConsole.Recursion_DFS;

namespace AlgorithmsTests.Recursion_DFS;

public class FibonacciTests
{
    public static TheoryData<int, long> FibonacciTestCases
        => new()
        {
            { 0, 0 },   // Base case: F(0) = 0
            { 1, 1 },   // Base case: F(1) = 1
            { 2, 1 },   // 1 + 0
            { 3, 2 },   // 1 + 1
            { 5, 5 },   // Common checkpoint
            { 10, 55 }, // Common checkpoint
            { 20, 6765 }, // Larger value, still small enough to verify easily
            { 30, 832040 }, // Ensures memoization handles bigger n efficiently
            { 50, 12586269025 }, // Large-but-safe within long
        };

    [Theory]
    [MemberData(nameof(FibonacciTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int n, long expected)
    {
        // Arrange
        var sut = new Fibonacci();

        // Act
        var result = sut.Implementation(n);

        // Assert
        Assert.Equal(expected, result);
    }
}