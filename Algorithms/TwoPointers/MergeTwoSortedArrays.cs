namespace TestConsole.TwoPointers;

public class MergeTwoSortedArrays
{
    // Problem overview
    // Given two sorted int arrays, merge them into one sorted array
    // (either into a new array or in-place if you want extra challenge).

    // Example: [1,3,5] and [2,4,6] → [1,2,3,4,5,6].

    public int[] Implementation(int[] arrayA, int[] arrayB)
    {
        int aIndex = 0, bIndex = 0, mergedIndex = 0;
        var mergedArray = new int[arrayA.Length + arrayB.Length];

        while (aIndex < arrayA.Length && bIndex < arrayB.Length)
        {
            if (arrayA[aIndex] <= arrayB[bIndex])
            {
                mergedArray[mergedIndex] = arrayA[aIndex];
                aIndex++;
            }
            else
            {
                mergedArray[mergedIndex] = arrayB[bIndex];
                bIndex++;
            }

            mergedIndex++;
        }

        while (aIndex < arrayA.Length)
        {
            mergedArray[mergedIndex] = arrayA[aIndex];
            aIndex++;
            mergedIndex++;
        }

        while (bIndex < arrayB.Length)
        {
            mergedArray[mergedIndex] = arrayB[bIndex];
            bIndex++;
            mergedIndex++;
        }

        return mergedArray;
    }
}