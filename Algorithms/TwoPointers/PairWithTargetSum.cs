namespace TestConsole.TwoPointers;

public class PairWithTargetSum
{
    // Problem Overview: Pair With Target Sum (Sorted Array)
    // Given a sorted integer array nums and an integer target,
    // determine whether there exists a pair of two distinct elements whose sum equals target.
    
    public bool Implementation(int[] nums, int target)
    {
        if (nums.Length < 2)
        {
            return false;
        }

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[left] + (long)nums[right];

            if (sum == target)
            {
                return true;
            }

            if (sum < target)
            {
                left++;
            }
            else if (sum > target)
            {
                right--;
            }
        }

        return false;
    }
}