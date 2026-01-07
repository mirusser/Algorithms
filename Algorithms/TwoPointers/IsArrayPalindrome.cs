namespace TestConsole.TwoPointers;

public class IsArrayPalindrome
{
    public bool Implementation(int[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        
        var leftIndex = 0;
        var rightIndex = array.Length - 1;

        while (leftIndex < rightIndex)
        {
            if (array[leftIndex] != array[rightIndex])
            {
                return false;
            }
            
            leftIndex++;
            rightIndex--;
        }

        return true;
    }

    public static bool ImplementationSpanVersion<T>(
        ReadOnlySpan<T> span, 
        IEqualityComparer<T>? comparer = null)
    {
        comparer ??= EqualityComparer<T>.Default;
        
        var leftIndex = 0;
        var rightIndex = span.Length - 1;

        while (leftIndex < rightIndex)
        {
            if (!comparer.Equals(span[leftIndex], span[rightIndex]))
            {
                return false;
            }
            
            leftIndex++;
            rightIndex--;
        }
        
        return true;
    }
}