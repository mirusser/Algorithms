using TestConsole.TwoPointers;

namespace AlgorithmsTests.TwoPointers;

public class IsArrayPalindromeTests
{
    public static TheoryData<int[], bool> IsArrayPalindromeTestCases
        => new()
        {
            // Base cases:
            { [1, 2, 3, 2, 1], true }, // odd length palindrome
            { [4, 5, 6], false }, // non-palindrome
            { [7], true }, // single element
            { [], true }, // empty array (empty input)

            // Even-length palindromes / non-palindromes
            { [1, 2, 2, 1], true },
            { [1, 2, 3, 1], false },

            // Negative and zero values
            { [0, 1, 0], true },
            { [-1, -2, -2, -1], true },
            { [-1, 0, -1], true },
            { [-1, -2, -3], false },

            // “Almost palindrome” / mismatch positions
            { [1, 2, 3, 2, 9], false }, // mismatch at end
            { [9, 2, 3, 2, 1], false }, // mismatch at start
            { [1, 2, 3, 4, 1], false }, // mismatch in middle region

            // Repeated values
            { [5, 5, 5, 5], true },
            { [5, 5, 5, 6], false },
        };

    [Theory]
    [MemberData(nameof(IsArrayPalindromeTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[] array, bool expected)
    {
        // Arrange
        var sut = new IsArrayPalindrome();

        // Act
        var result = sut.Implementation(array);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DoesNotMutateInputArray()
    {
        // Arrange
        var sut = new IsArrayPalindrome();
        int[] array = [1, 2, 3, 2, 1];
        var copy = (int[])array.Clone();

        // Act
        _ = sut.Implementation(array);

        // Assert
        Assert.Equal(copy, array);
    }

    public static TheoryData<int[], int, int, bool> IsPalindromeSpanTestCases
        => new()
        {
            // Whole-array cases
            { [1, 2, 3, 2, 1], 0, 5, true },
            { [4, 5, 6], 0, 3, false },
            { [7], 0, 1, true },
            { [], 0, 0, true },

            // Slice palindromes (span over a subrange)
            // [9, 1, 2, 2, 1, 8] slice(1,4) => [1,2,2,1]
            { [9, 1, 2, 2, 1, 8], 1, 4, true },

            // Slice non-palindromes
            // [9, 1, 2, 3, 1, 8] slice(1,4) => [1,2,3,1]
            { [9, 1, 2, 3, 1, 8], 1, 4, false },

            // Even-length palindrome slice
            { [0, 5, 6, 6, 5, 9], 1, 4, true },

            // Single-element slice
            { [1, 2, 3], 1, 1, true },

            // Two-element slices
            { [1, 1, 2], 0, 2, true }, // [1,1]
            { [1, 2, 2], 0, 2, false }, // [1,2]

            // Negative numbers
            { [-9, -1, -2, -1, -9], 0, 5, true },
        };

    [Theory]
    [MemberData(nameof(IsPalindromeSpanTestCases))]
    public void ReturnsExpectedResult_ForGivenSpanSlice(int[] source, int start, int length, bool expected)
    {
        // Arrange
        var span = source.AsSpan(start, length);

        // Act
        var result = IsArrayPalindrome.ImplementationSpanVersion(span);

        // Assert
        Assert.Equal(expected, result);
    }
}