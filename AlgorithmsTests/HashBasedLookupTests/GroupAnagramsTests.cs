using TestConsole.HashBasedLookup;

namespace AlgorithmsTests.HashBasedLookupTests;

public class GroupAnagramsTests
{
    public static TheoryData<string[], List<List<string>>> GroupAnagramsTestCases
        => new()
        {
            {
                ["eat", "tea", "tan", "ate", "nat", "bat"],
                [
                    ["eat", "tea", "ate"],
                    ["tan", "nat"],
                    ["bat"]
                ]
            }, // normal/happy case
            { ["", ""], [["", ""]] }, // empty strings
            { ["a", "b", "c"], [["a"], ["b"], ["c"]] }, // no anagrams
            { ["eat", "eat", "tea"], [["eat", "eat", "tea"]] }, // duplicate strings
            { [], [] }, // empty input
            { ["ab", "a"], [["ab"], ["a"]] } // words of different lengths
        };

    [Theory]
    [MemberData(nameof(GroupAnagramsTestCases))]
    public void ReturnsExpectedResult_ForGivenInputs(string[] strs, List<List<string>> expected)
    {
        // Arrange
        var sut = new GroupAnagrams();

        // Act
        var result = sut.Implementation(strs);

        // Assert 1: same total number of elements (no drops/duplication overall)
        Assert.Equal(
            strs.OrderBy(s => s),
            result.SelectMany(g => g).OrderBy(s => s)
        );

        // Assert 2: same groups, ignoring order of groups and order within groups
        var expectedCanonical = CanonicalizeGroups(expected);
        var resultCanonical = CanonicalizeGroups(result);

        Assert.Equal(expectedCanonical, resultCanonical);
    }
    
    private static List<string> CanonicalizeGroups(List<List<string>> groups)
    {
        // Represent each group deterministically: sort items, then join.
        // Then sort the list of group-representations so group order doesn't matter.
        return groups
            .Select(g => string.Join("|", g.OrderBy(x => x, StringComparer.Ordinal)))
            .OrderBy(x => x, StringComparer.Ordinal)
            .ToList();
    }
}