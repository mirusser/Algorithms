namespace TestConsole.Recursion_DFS;

public class Factorial
{
    // Problem overview:
    // Given a non-negative integer n, compute n! (factorial),
    // defined as the product of all positive integers from 1 to n.

    // By definition:
    // 0! = 1


    public long Implementation(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        if (n == 0)
        {
            return 1;
        }

        return n * Implementation(n - 1);
    }

    public long ImplementationIteration(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        long result = 1;

        for (var i = n; i > 0; i--)
        {
            result *= i;
        }


        return result;
    }
}