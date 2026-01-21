namespace TestConsole.HashBasedLookup;

public class LongestConsecutiveSequence
{
    // Use a HashSet for O(1) lookups and to eliminate duplicates.
    // For each number, start a sequence only if its predecessor (number - 1) does not exist.
    // This guarantees each consecutive sequence is counted exactly once.
    // From a valid start, extend the sequence by checking successive numbers.
    // This avoids sorting and runs in O(n) time.
    
    public int Implementation(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        HashSet<int> set = new(nums);

        var maxlength = 0;
        foreach (var number in set)
        {
            // no predecessor, start counting
            if (!set.Contains(number - 1))
            {
                var length = 1;
                var current = number;

                while (current < int.MaxValue && set.Contains(current + 1))
                {
                    length++;
                    current++;
                }

                maxlength = Math.Max(maxlength, length);
            }
        }

        return maxlength;
    }
}