using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace TestConsole;

public class FirstNonRepeatingCharacter
{
    public void Run()
    {
        Console.WriteLine(CalculateOptimized("leetcode")); // l
        Console.WriteLine(CalculateOptimized("loveleetcode")); //v
        Console.WriteLine(CalculateOptimized("aabb")); // nothing
        Console.WriteLine(CalculateOptimized("x")); // x
        Console.WriteLine(CalculateOptimized("")); //nothing
    }
    public string CalculateNaiveSolution(string input)
    {
        foreach (var character in input)
        {
            if (input.Count(i => i == character) == 1)
            {
                return character.ToString();
            }
        }

        return "";
    }

    public string CalculateOptimized(string input)
    {
        OrderedDictionary<char, int> occurrences = [];

        if (input.Length == 0)
        {
            return "";
        }

        foreach (var character in input)
        {
            if (occurrences.TryGetValue(character, out int occurencesCount))
            {
                occurrences[character] = ++occurencesCount;
            }
            else
            {
                occurrences.Add(character, 1);
            }
        }

        var result = occurrences.FirstOrDefault(o => o.Value == 1);

        return result.Key.ToString();
    }
    
    public string CalculateTextbookSolution(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        var counts = new Dictionary<char, int>();

        // First pass: count occurrences
        foreach (char c in input)
        {
            if (counts.TryGetValue(c, out int count))
            {
                counts[c] = count + 1;
            }
            else
            {
                counts[c] = 1;
            }
        }

        // Second pass: find first non-repeating character
        foreach (char c in input)
        {
            if (counts[c] == 1)
            {
                return c.ToString();
            }
        }

        return "";
    }
    
    public string CalculateOnePass(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "";

        // chars currently seen exactly once, in arrival order
        var once = new LinkedList<char>();

        // where each "once" char sits in the linked list (so we can remove in O(1))
        var nodeByChar = new Dictionary<char, LinkedListNode<char>>();

        // chars we've seen 2+ times (so we can ignore future repeats quickly)
        var repeated = new HashSet<char>();

        foreach (char c in input)
        {
            // Already known repeated -> nothing to do
            if (repeated.Contains(c))
                continue;

            // First time seen -> add to "once"
            if (!nodeByChar.ContainsKey(c))
            {
                nodeByChar[c] = once.AddLast(c);
            }
            else
            {
                // Second time seen -> remove from "once" and mark repeated
                once.Remove(nodeByChar[c]);
                nodeByChar.Remove(c);
                repeated.Add(c);
            }
        }

        return once.First?.Value.ToString() ?? "";
    }
}

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HideColumns(Column.Error, Column.StdDev)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class FirstNonRepeatingBenchmarks
{
    private readonly FirstNonRepeatingCharacter sut = new();

    // Vary size; naive O(n^2) will explode at huge n, so keep a sane range.
    [Params(32, 256, 2048, 8192)]
    public int N;

    // Different shapes stress different behaviors:
    // - UniqueEarly: first char is unique (best-case early return)
    // - UniqueLate: only last char is unique (forces full scan)
    // - NoneUnique: no non-repeating character (forces full scan + no return)
    [Params(InputShape.UniqueEarly, InputShape.UniqueLate, InputShape.NoneUnique)]
    public InputShape Shape;

    private string input = "";

    [GlobalSetup]
    public void Setup()
    {
        input = Shape switch
        {
            InputShape.UniqueEarly => MakeUniqueEarly(N),
            InputShape.UniqueLate  => MakeUniqueLate(N),
            InputShape.NoneUnique  => MakeNoneUnique(N),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    [Benchmark(Baseline = true)]
    public string Naive() => sut.CalculateNaiveSolution(input);

    [Benchmark]
    public string OrderedDictionaryVariant() => sut.CalculateOptimized(input);

    [Benchmark]
    public string TextbookTwoPass() => sut.CalculateTextbookSolution(input);
    
    [Benchmark]
    public string OnePass() => sut.CalculateOnePass(input);
    

    // ---------- input generators ----------
    private static string MakeUniqueEarly(int n)
    {
        // First char unique, rest are pairs.
        // Example: "x a a b b c c ..."
        var sb = new StringBuilder(n);
        sb.Append('x'); // unique
        char c = 'a';
        while (sb.Length < n)
        {
            sb.Append(c);
            if (sb.Length < n) sb.Append(c);
            c = NextChar(c);
        }
        return sb.ToString(0, n);
    }

    private static string MakeUniqueLate(int n)
    {
        // All pairs, then add a unique char at the end.
        // Forces full scan to find unique at last position.
        if (n == 0) return "";
        var sb = new StringBuilder(n);
        char c = 'a';
        while (sb.Length < n - 1)
        {
            sb.Append(c);
            if (sb.Length < n - 1) sb.Append(c);
            c = NextChar(c);
        }
        sb.Append('z'); // unique at the end
        return sb.ToString(0, n);
    }

    private static string MakeNoneUnique(int n)
    {
        // Entire string is pairs only: "a a b b c c ..."
        var sb = new StringBuilder(n);
        char c = 'a';
        while (sb.Length < n)
        {
            sb.Append(c);
            if (sb.Length < n) sb.Append(c);
            c = NextChar(c);
        }
        return sb.ToString(0, n);
    }

    private static char NextChar(char c) => c == 'y' ? 'a' : (char)(c + 1);
}

public enum InputShape
{
    UniqueEarly,
    UniqueLate,
    NoneUnique
}