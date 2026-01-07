namespace TestConsole.TwoPointers;

public class PairWithTargetSum
{
    public bool Implementation(int[] nums, int target)
    {
        if (nums == null || nums.Length < 2)
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