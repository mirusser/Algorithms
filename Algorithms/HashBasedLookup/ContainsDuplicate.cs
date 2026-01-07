namespace TestConsole.HashBasedLookup;

public class ContainsDuplicate
{
    // Q: Why use HashSet
    // A: Because I only care whether I've seen a value before, or not
    // HashSet gives O(1) average lookup and insertion, 
    // and Add method immediately tells if the value already exists
    // which let me exit early
    
    // Complexity
    // Time: O(n) (How long does it take to run)
    // Space: O(n) (How much extra memory does it use)
    
    
    public bool Implementation(int[] nums)
    {
        HashSet<int> frequency = [];

        foreach (var n in nums)
        {
            if (!frequency.Add(n))
            {
                return true;
            }
        }

        return false;
    }
}