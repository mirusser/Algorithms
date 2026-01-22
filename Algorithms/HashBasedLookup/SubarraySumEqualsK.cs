namespace TestConsole.HashBasedLookup;

public class SubarraySumEqualsK
{
    // General Description of the problem.
    // You are given:
    // - An integer array nums
    // - An integer k
    //
    // Your task is to count how many contiguous subarrays have a sum equal to k.
    //
    // Key points:
    // - A subarray must be contiguous
    // - Elements can be positive, negative, or zero
    // - You are counting all possible subarrays, not just one
    //
    // Example
    // For:
    // nums = [3, 4, 7, 2, -3, 1, 4, 2]
    // k = 7
    // There are 4 subarrays whose sum is exactly 7.

    /// <summary>
    /// <para> Uses prefix sums and a hash map (dictionary)</para>
    ///
    /// <para>
    /// prefixSum[i] = sum of elements from index 0 to i,
    /// then: sum(start..end) = prefixSum[end] - prefixSum[start - 1],
    /// rearranged: prefixSum[start - 1] = prefixSum[end] - k
    ///</para>
    /// 
    ///<para>
    /// So:
    /// If current running prefix sum is S at index end,
    /// then subarray sum (start..end) = S - prefixSumBeforeStart.
    /// So we look for prefixSumBeforeStart = S - k.
    ///</para>
    ///
    /// <para>
    /// We use a dictionary to remember how many times each prefix sum has appeared.
    /// The dictionary counts prefix sums, and each matching S - k represents a valid subarray ending now.
    /// </para>
    /// <remarks>
    /// Prefix sums are points on a number line.
    /// Subarrays are distances between two points.
    /// For an array: <para>[3, 4, 7, 2, -3, 1, 4, 2]</para>
    /// We get:
    /// <para>0 ── 3 ── 7 ── 14 ── 16 ── 13 ── 14 ── 18 ── 20</para>
    /// So: Count how many pairs of points are exactly distance k apart.
    /// </remarks>
    /// </summary>
    /// <param name="nums">Array of integers</param>
    /// <param name="k">Target sum for contiguous subarrays.</param>
    /// <returns>The number of contiguous subarrays whose sum equals k.</returns>
    public int Implementation(int[] nums, int k)
    {
        var count = 0;
        var prefixSum = 0;

        Dictionary<int, int> prefixSums = [];

        // Base case: prefix sum 0 occurs once before processing any elements,
        // allowing subarrays that start at index 0 to be counted.
        prefixSums[0] = 1;

        foreach (var num in nums)
        {
            prefixSum += num;

            // If current running prefix sum is S at index end,
            // then a subarray (start..end) sums to k when a previous prefix sum equals S - k.
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
    
    // In general:
    // Subarray problems are prefix-sum geometry problems.
    // Hash maps count how many ways you can draw a segment of the right length.
    
    // Other implementations:
    
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
}