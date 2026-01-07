namespace TestConsole.HashBasedLookup;

public class LongestConsecutiveSequence
{
    public int Implementation(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

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