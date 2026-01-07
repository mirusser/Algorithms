using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class ContainsDuplicateTests
{
    public static TheoryData<int[], bool> ContainsDuplicateTestCases
        => new()
        {
            { [1, 2, 3, 1], true }, // duplicate exists (basic case)
            { [1, 2, 3, 4], false }, // all unique
            { [1, 1], true }, // minimal duplicate
            { [1], false }, // single element
            { [], false }, // empty array
            { [-1, -2, -3, -1], true }, // negatives with duplicate
            { [0, 1, 2, 3, 0], true }, // zero duplicated
            { [int.MaxValue, int.MinValue], false }, // extreme values, no dup
        };

    [Theory]
    [MemberData(nameof(ContainsDuplicateTestCases))]
    public void ContainsDuplicateTest(int[] nums, bool expected)
    {
        // Arrange
        var sut = new ContainsDuplicate();

        // Act
        var result = sut.Implementation(nums);

        // Arrange
        Assert.Equal(expected, result);
    }
}