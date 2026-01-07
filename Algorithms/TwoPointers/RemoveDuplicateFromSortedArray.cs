namespace TestConsole.TwoPointers;

public class RemoveDuplicateFromSortedArray
{
    public int Implementation(int[] nums)
    {
        if (nums is null)
        {
            throw new ArgumentNullException(nameof(nums));
        }

        if (nums.Length == 0)
        {
            return 0;
        }

        int write = 1; // index where next unique value goes

        for (int read = 1; read < nums.Length; read++)
        {
            if (nums[read] != nums[write - 1])
            {
                nums[write] = nums[read];
                write++;
            }
        }

        return write;
    }
}