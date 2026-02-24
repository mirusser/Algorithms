namespace TestConsole.HashBasedLookup;

public class SubarraySumsDivisibleByK
{
    // Problem overview:
    // Given an array of integers: nums and an integer: k,
    // return the number of non-empty subarrays whose sum is divisible by k.

    public int Implementation(int[] nums, int k)
    {
        var count = 0;
        var prefixSum = 0;

        var remainderFreq = new Dictionary<int, int>
        {
            [0] = 1
        };

        foreach (var num in nums)
        {
            prefixSum += num;

            var reminder = prefixSum % k;
            if (reminder < 0)
            {
                reminder += k; // normalize for negatives
            }

            if (remainderFreq.TryGetValue(reminder, out var freq))
            {
                count += freq;
            }

            if (!remainderFreq.TryAdd(reminder, 1))
            {
                remainderFreq[reminder]++;
            }
        }

        return count;
    }
}