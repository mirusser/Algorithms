namespace TestConsole.HashBasedLookup;

public class TwoSum
{
    // I iterate through the array once while keeping a hash set of previously seen numbers.
    // For each number, I compute the value needed to reach the target and check if it already exists in the set.
    // If it does, I return true immediately.
    // Otherwise, I add the current number to the set and continue.
    public bool Implementation(int[] nums, int target)
    {
        HashSet<long> previousValues = [];
        
        foreach (var n in nums)
        {
            long needed = target - n;
            if (previousValues.Contains(needed))
            {
                return true;
            }
            
            previousValues.Add(n);
        }

        return false;
    }
}