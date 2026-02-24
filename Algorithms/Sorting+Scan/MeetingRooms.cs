namespace TestConsole.Sorting_Scan;

public class MeetingRooms
{
    // Problem Overview: Meeting Rooms
    // Given an array of meeting time intervals, determine whether a person can attend all meetings.
    // Each interval is represented as [start, end].
    // Return:
        // true if no meetings overlap
        // false if any two meetings overlap
        
        
    public bool Implementation(int[][] intervals)
    {
        ArgumentNullException.ThrowIfNull(intervals);

        var sortedIntervals = intervals
            .OrderBy(interval => interval[0])
            .ThenBy(interval => interval[1])
            .ToArray();

        for (var i = 0; i < sortedIntervals.Length - 1; i++)
        {
            if (sortedIntervals[i][1] > sortedIntervals[i + 1][0])
            {
                return false;
            }
        }

        return true;
    }
}