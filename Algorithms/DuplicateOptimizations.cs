using BenchmarkDotNet.Attributes;

namespace TestConsole;

//Run using:
//BenchmarkRunner.Run<DuplicateBenchmarks>();

public enum DupScenario
{
    NoDuplicates,
    DuplicateEarly,
    DuplicateLate
}

[MemoryDiagnoser]
public class DuplicateBenchmarks
{
    [Params(100, 1_000, 10_000)]
    public int N;

    [Params(DupScenario.NoDuplicates, DupScenario.DuplicateEarly, DupScenario.DuplicateLate)]
    public DupScenario Scenario;

    private int[] _numbers = Array.Empty<int>();

    [GlobalSetup]
    public void Setup()
    {
        // Base array: strictly increasing => no duplicates
        _numbers = Enumerable.Range(0, N).ToArray();

        if (N < 2)
            return;

        switch (Scenario)
        {
            case DupScenario.NoDuplicates:
                // leave as-is
                break;

            case DupScenario.DuplicateEarly:
                // Make a duplicate appear very early during scanning:
                // e.g. [0, 0, 2, 3, ...]
                _numbers[1] = _numbers[0];
                break;

            case DupScenario.DuplicateLate:
                // Make a duplicate appear at the end:
                // e.g. [..., N-2, 0]
                _numbers[N - 1] = _numbers[0];
                break;
        }
    }

    // 1) Naive O(n^2) - the method to refactor
    [Benchmark(Baseline = true)]
    public bool Naive_N2()
    {
        var numbers = _numbers;

        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                    return true;
            }
        }
        return false;
    }

    // 2) HashSet with early exit (the one I provided)
    [Benchmark]
    public bool HashSet_EarlyExit()
    {
        var numbers = _numbers;
        var seen = new HashSet<int>(_numbers.Length);

        foreach (var n in numbers)
        {
            if (!seen.Add(n))
                return true;
        }

        return false;
    }
    
    [Benchmark]
    public bool HashSet_EarlyExit_Hybrid()
    {
        var numbers = _numbers;
        var seen = new HashSet<int>();

        // If you expect *usually no duplicates*, pre-size.
        // If you expect *often duplicates early*, don't.
        if (numbers.Length >= 1024 && Scenario != DupScenario.DuplicateEarly)
            seen.EnsureCapacity(numbers.Length);

        foreach (var n in numbers)
            if (!seen.Add(n))
                return true;

        return false;
    }

    // 3) ToHashSet + Count compare
    [Benchmark]
    public bool ToHashSet_CountCompare()
    {
        var numbers = _numbers;
        var hashSetNumbers = numbers.ToHashSet();
        return hashSetNumbers.Count != numbers.Length;
    }
}