namespace TestConsole.Recursion_DFS;

public class Fibonacci
{
    public long Implementation(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        long[] cache = new long[n + 1];

        //-1 means “not computed yet”
        Array.Fill(cache, -1);
        
        return FibCache(n, cache);
    }

    private long FibCache(int n, long[] cache)
    {
        if (n <= 1)
        {
            return n;
        }
        
        if (cache[n] != -1)
        {
            return cache[n];
        }

        var result = FibCache(n - 1, cache) + FibCache(n - 2, cache);
        cache[n] = result;

        return result;
    }

    public long IterationImplementation(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        if (n <= 1)
        {
            return n;
        }

        long prev = 0;
        long curr = 1;

        for (var i = 2; i <= n; i++)
        {
            long next = prev + curr;
            prev = curr;
            curr = next;
        }

        return curr;
    }
}