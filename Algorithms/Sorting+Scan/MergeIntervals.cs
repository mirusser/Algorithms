namespace TestConsole.Sorting_Scan;

public class MergeIntervals
{
    public int[][] Implementation(int[][] intervals)
    {
        ArgumentNullException.ThrowIfNull(intervals);
        
        var sortedIntervals = intervals
            .OrderBy(x => x[0])
            .ThenBy(x => x[1])
            .ToArray();
        List<int[]> mergedIntervals = [];

        foreach (var t in sortedIntervals)
        {
            var start = t[0];
            var end = t[1];

            if (mergedIntervals.Count == 0)
            {
                mergedIntervals.Add([start, end]);
                continue;
            }

            if (mergedIntervals[^1][1] >= start)
            {
                mergedIntervals[^1][1] = Math.Max(mergedIntervals[^1][1], end);
            }
            else
            {
                mergedIntervals.Add([start, end]);
            }
        }

        return mergedIntervals.ToArray();
    }
}