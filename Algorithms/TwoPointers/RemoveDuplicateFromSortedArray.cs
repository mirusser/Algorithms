namespace TestConsole.TwoPointers;

public class RemoveDuplicateFromSortedArray
{
    // Problem Overview: Remove Duplicates from Sorted Array
    // Given a sorted integer array nums, remove duplicates in-place so that each unique element appears only once.

    //Return the number of unique elements (k),
    //and ensure the first k positions of the array contain the unique values in their original sorted order.
    
    
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