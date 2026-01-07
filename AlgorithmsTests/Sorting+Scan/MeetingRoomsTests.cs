using TestConsole.Sorting_Scan;

namespace AlgorithmsTests.Sorting_Scan;

public class MeetingRoomsTests
{
    public static TheoryData<int[][], bool> MeetingRoomsTestCases
        => new()
        {
            { [[0, 30], [5, 10], [15, 20]], false }, // overlap: [0,30] overlaps [5,10]
            { [[5, 8], [9, 15]], true }, // no overlap
            { [[1, 3], [3, 6]], true }, // touching boundary allowed
            { [], true }, // no meetings => no conflicts
            { [[2, 2], [2, 3]], true }, // point meeting touches next start => allowed

            { [[1, 4], [2, 3]], false }, // nested overlap: [1,4] contains [2,3]
            { [[1, 2], [2, 3], [3, 4]], true }, // consecutive touching chain
            { [[1, 5], [5, 5], [5, 6]], true }, // zero-length meeting at boundary, still ok

            { [[10, 12], [1, 3], [4, 9]], true }, // unsorted input, still non-overlapping after sort
            { [[10, 12], [1, 3], [3, 11]], false }, // unsorted input, overlap after sort: [3,11] overlaps [10,12]

            { [[-5, -1], [-10, -6]], true }, // negatives, disjoint after sort
            { [[-5, 0], [-3, 2]], false }, // negatives with overlap
        };

    [Theory]
    [MemberData(nameof(MeetingRoomsTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(int[][] intervals, bool expected)
    {
        // Arrange
        var sut = new MeetingRooms();

        // Act
        var result = sut.Implementation(intervals);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThrowsArgumentNullException_WhenIntervalsIsNull()
    {
        var sut = new MeetingRooms();
        Assert.Throws<ArgumentNullException>(() => sut.Implementation(null!));
    }
}