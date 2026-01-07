namespace TestConsole.HashBasedLookup;

public class SumIndices
{
    /// <summary>
    /// Finds two distinct indices in the input array such that the sum of the
    /// corresponding elements equals the specified target value.
    /// Uses a single-pass hash-based lookup to achieve linear time complexity.
    /// </summary>
    /// <param name="nums">
    /// The input array of integers. Must contain at least two elements.
    /// </param>
    /// <param name="target">
    /// The target sum to be achieved by adding two elements from <paramref name="nums"/>.
    /// </param>
    /// <returns>
    /// A tuple containing the indices of the two elements whose values sum to
    /// <paramref name="target"/>.
    /// If no such pair exists, returns <c>(-1, -1)</c>.
    /// </returns>

    public (int index1, int index2) Implementation(int[] nums, int target)
    {
        if (nums.Length < 2)
            return (-1, -1);

        Dictionary<int, int> dict = [];

        for (var i = 0; i < nums.Length; i++)
        {
            var difference = target - nums[i];

            if (dict.TryGetValue(difference, out var index))
            {
                return (index, i);
            }

            dict.TryAdd(nums[i], i);
        }

        return (-1, -1);
    }
}