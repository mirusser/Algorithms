namespace TestConsole.HashBasedLookup;

public class SubarraySumsDivisibleByK
{
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

            var rem = prefixSum % k;
            if (rem < 0) rem += k; // normalize for negatives

            if (remainderFreq.TryGetValue(rem, out var freq))
            {
                count += freq;
            }

            if (!remainderFreq.TryAdd(rem, 1))
            {
                remainderFreq[rem]++;
            }
        }

        return count;
    }
}