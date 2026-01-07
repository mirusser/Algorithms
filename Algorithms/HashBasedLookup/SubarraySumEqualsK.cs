namespace TestConsole.HashBasedLookup;

public class SubarraySumEqualsK
{
    public int ImplementationNaive(int[] nums, int k)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var tempResult = 0;

            for (var j = i; j < nums.Length; j++)
            {
                tempResult += nums[j];
                if (tempResult == k)
                {
                    result++;
                }
            }
        }

        return result;
    }

    public int SubarraySum_PrefixSums_On2(int[] nums, int k)
    {
        if (nums.Length == 0)
            return 0;

        int n = nums.Length;

        // prefix[i] = sum of nums[0..i-1]
        // prefix[0] = 0
        int[] prefix = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + nums[i];
        }

        int count = 0;

        // check every subarray [start..end]
        // sum(start..end) = prefix[end+1] - prefix[start]
        for (int start = 0; start < n; start++)
        {
            for (int end = start; end < n; end++)
            {
                var prefixEnd = prefix[end + 1];
                var prefixStart = prefix[start];

                int sum = prefixEnd - prefixStart;

                if (sum == k)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public int Implementation(int[] nums, int k)
    {
        var count = 0;
        var prefixSum = 0;

        Dictionary<int, int> prefixSums = [];

        // Base case: prefix sum 0 occurs once before we process any elements,
        // allowing subarrays that start at index 0 to be counted.
        prefixSums[0] = 1;

        foreach (var num in nums)
        {
            prefixSum += num;

            // subarraySum(start..end) = prefixSum[end + 1] - prefixSum[start]
            // Let current prefix sum be S. Any earlier prefix sum equal to (S - k)
            // indicates a subarray ending at this index with sum k.
            var needed = prefixSum - k;

            if (prefixSums.TryGetValue(needed, out var freq))
            {
                count += freq;
            }

            if (!prefixSums.TryAdd(prefixSum, 1))
            {
                prefixSums[prefixSum]++;
            }
        }

        return count;
    }
}