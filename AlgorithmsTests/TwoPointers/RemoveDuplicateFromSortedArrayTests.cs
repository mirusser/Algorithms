using TestConsole.TwoPointers;

namespace AlgorithmsTests.TwoPointers;

public class RemoveDuplicateFromSortedArrayTests
{
    // We include the expected unique prefix to verify not only k,
    // but also that the first k elements contain the correct values in order.
    public static TheoryData<int[], int, int[]> RemoveDuplicateFromSortedArrayTestCases
        => new()
        {
            // Basic: duplicates in the beginning
            { [1, 1, 2], 2, [1, 2] },

            // Typical mixed blocks of duplicates (classic example)
            { [0, 0, 1, 1, 2, 3, 3], 4, [0, 1, 2, 3] },

            // Already unique: should return full length and keep same order
            { [1, 2, 3], 3, [1, 2, 3] },

            // Empty: should return 0 and not crash
            { [], 0, [] },

            // All duplicates: should compress to a single element
            { [5, 5, 5, 5], 1, [5] },

            // Single element: minimal non-empty input
            { [42], 1, [42] },

            // Duplicates only at the end: catches "stop too early" bugs
            { [1, 2, 3, 3, 3], 3, [1, 2, 3] },

            // Duplicates only at the beginning: catches "initial write index" mistakes
            { [1, 1, 1, 2, 3], 3, [1, 2, 3] },

            // Negative numbers and duplicates: ensures it’s value-based and works across negatives
            { [-3, -3, -1, -1, 0, 2, 2], 4, [-3, -1, 0, 2] },

            // Alternating duplicate blocks: catches subtle pointer increment errors
            { [1, 1, 2, 2, 3, 3, 4, 4], 4, [1, 2, 3, 4] },

            // Large duplicate block in the middle: ensures correct skipping & writing
            { [1, 2, 2, 2, 2, 3], 3, [1, 2, 3] },
        };

    [Theory]
    [MemberData(nameof(RemoveDuplicateFromSortedArrayTestCases))]
    public void ReturnsExpectedResult_AndWritesUniquePrefix(int[] array, int expectedK, int[] expectedPrefix)
    {
        // Arrange
        var sut = new RemoveDuplicateFromSortedArray();

        // Act
        var k = sut.Implementation(array);

        // Assert: correct count
        Assert.Equal(expectedK, k);

        // Assert: first k elements match expected unique values in order
        Assert.Equal(expectedPrefix, array.Take(k));
    }

    // Optional: lock in behavior for null input (recommended in C#)
    [Fact]
    public void ThrowsArgumentNullException_WhenArrayIsNull()
    {
        var sut = new RemoveDuplicateFromSortedArray();
        Assert.Throws<ArgumentNullException>(() => sut.Implementation(null!));
    }
}