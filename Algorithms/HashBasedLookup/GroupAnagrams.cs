namespace TestConsole.HashBasedLookup;

public class GroupAnagrams
{
    public List<List<string>> Implementation(string[] strs)
    {
        Dictionary<string, List<string>> groupedAnagrams = new();

        foreach (var s in strs)
        {
            var key = new string(s.OrderBy(c => c).ToArray());

            if (!groupedAnagrams.TryGetValue(key, out var bucket))
            {
                bucket = [];
                groupedAnagrams[key] = bucket;
            }

            bucket.Add(s);
        }

        return groupedAnagrams.Values.ToList();
    }
}