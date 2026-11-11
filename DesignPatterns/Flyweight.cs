using System.Collections.Concurrent;

internal record Font(string Name, int Size)
{
    public string Draw(char character, int position) => $"{character} at {position} in {Name} {Size}";
}

internal class Flyweight<TKey, TValue> where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, TValue> cache = new();
    private readonly Func<TKey, TValue> create;

    public Flyweight(Func<TKey, TValue> create) => this.create = create;

    // Create on first request, share on every later one
    public TValue Get(TKey key) => cache.GetOrAdd(key, create);
    public int Count => cache.Count;
}
