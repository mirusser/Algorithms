using TestConsole.Recursion_DFS;

namespace AlgorithmsTests.Recursion_DFS;

public class FactorialTests
{
    public static TheoryData<int, long> FactorialTestCases
        => new()
        {
            { 0, 1 }, // Base case: 0! = 1
            { 1, 1 }, // 1! = 1
            { 2, 2 }, // 2! = 2
            { 3, 6 }, // 3! = 6
            { 5, 120 }, // 5! = 120
            { 10, 3_628_800 }, // Common checkpoint value
            { 20, 2_432_902_008_176_640_000 }, // Largest n where n! fits in long
        };

    [Theory]
    [MemberData(nameof(FactorialTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int n, long expected)
    {
        // Arrange
        var sut = new Factorial();

        // Act
        var result = sut.Implementation(n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThrowsArgumentOutOfRangeException_WhenInputIsNegative()
    {
        // Arrange
        var sut = new Factorial();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Implementation(-1));
    }
}