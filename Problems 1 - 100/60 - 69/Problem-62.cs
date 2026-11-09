// Problem 62:
// Find the smallest cube for which exactly five permutations of its digits are cube.

var groups = new Dictionary<string, List<long>>();
int digits = 0;

for (long n = 1; ; n++)
{
    long cube = n * n * n;
    string s = cube.ToString();

    if (s.Length != digits)
    {
        // Finished all cubes of the previous length: check for a group of exactly 5
        var hits = groups.Values.Where(g => g.Count == 5).ToList();
        if (hits.Count > 0)
        {
            long smallest = hits.Min(g => g[0]);   // g[0] is the smallest cube in each group
            Console.WriteLine(smallest);
            break;
        }
        groups.Clear();
        digits = s.Length;
    }

    char[] chars = s.ToCharArray();
    Array.Sort(chars);
    string key = new string(chars);

    if (!groups.TryGetValue(key, out var list))
        groups[key] = list = new List<long>();
    list.Add(cube);
}
