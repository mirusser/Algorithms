namespace TestConsole.SlidingWindow;

public class MaxSumSubarrayOfK
{
    /// <summary>
    /// Computes the maximum sum of any contiguous subarray of size exactly <paramref name="k"/>.
    /// Uses a sliding window approach to achieve linear time complexity.
    /// </summary>
    /// <param name="nums">
    /// The input array of integers. Must not be <c>null</c> and must contain at least
    /// <paramref name="k"/> elements.
    /// </param>
    /// <param name="k">
    /// The exact size of the subarray window. Must be greater than zero and less than or
    /// equal to the length of <paramref name="nums"/>.
    /// </param>
    /// <returns>
    /// The maximum sum among all contiguous subarrays of size <paramref name="k"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="nums"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="k"/> is less than or equal to zero, or when
    /// <paramref name="k"/> is greater than the length of <paramref name="nums"/>.
    /// </exception>

    public int Implementation(int[] nums, int k)
    {
        ArgumentNullException.ThrowIfNull(nums);

        if (nums.Length == 0 || nums.Length < k || k <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nums));
        }

        int leftIndex = 0, maxSum = int.MinValue, subarraySum = 0;

        for (var rightIndex = 0; rightIndex < nums.Length; rightIndex++)
        {
            subarraySum += nums[rightIndex];

            if (rightIndex - leftIndex + 1 == k)
            {
                maxSum = Math.Max(maxSum, subarraySum);
                subarraySum -= nums[leftIndex];
                leftIndex++;
            }
        }

        return maxSum;
    }

    public int TextbookImplementation(int[] nums, int k)
    {
        if (k < 1 || k > nums.Length)
            return 0;

        int windowSum = 0;
        for (int i = 0; i < k; i++)
            windowSum += nums[i];

        int maxSum = windowSum;

        for (int right = k; right < nums.Length; right++)
        {
            windowSum += nums[right];
            windowSum -= nums[right - k];
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum;
    }
}