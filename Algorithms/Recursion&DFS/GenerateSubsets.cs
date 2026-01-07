namespace TestConsole.Recursion_DFS;

public class GenerateSubsets
{
    /// <summary>
    /// Generates all possible subsets (the power set) of the given array of distinct integers.
    /// Uses a recursive depth-first search (DFS) with backtracking to explore all combinations.
    /// </summary>
    /// <param name="nums">
    /// The input array of distinct integers. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// A collection containing all subsets of <paramref name="nums"/>.
    /// Each subset is represented as a separate list, including the empty subset.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="nums"/> is <c>null</c>.
    /// </exception>

    public IList<IList<int>> Implementation(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);
        
        var powerSet = new List<IList<int>>();
        Backtrack(0, nums, [], powerSet);
        
        return powerSet;
    }

    private void Backtrack(
        int index,
        int[] nums,
        List<int> subset,
        List<IList<int>> powerSet)
    {
        // Every state of `current` is a valid subset
        powerSet.Add(new List<int>(subset));

        for (int i = index; i < nums.Length; i++)
        {
            // Choose
            subset.Add(nums[i]);

            // Explore
            Backtrack(i + 1, nums, subset, powerSet);

            // Un-choose (backtrack)
            subset.RemoveAt(subset.Count - 1);
        }
    }
    
    public List<List<int>> IterationImplementation(int[] nums)
    {
        List<List<int>> powerSet = [[]];

        var n = nums.Length;
        long totalMasks = 1L << n;

        for (var mask = 1; mask < totalMasks; mask++)
        {
            List<int> subset = [];

            for (var i = 0; i < nums.Length; i++)
            {
                if (((mask >> i) & 1) == 1)
                {
                    subset.Add(nums[i]);
                }
            }

            powerSet.Add(subset);
        }

        return powerSet;
    }
}