public interface IRepository<T> where T : class
{
    T? Get(int id);
    IEnumerable<T> Find(Func<T, bool> predicate);
    void Add(T item);
    void Remove(int id);
}

// One generic class serves every entity. A database version implements the same interface.
internal class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly Dictionary<int, T> items = [];
    private readonly Func<T, int> getId;

    public InMemoryRepository(Func<T, int> getId) => this.getId = getId;

    public T? Get(int id) => items.GetValueOrDefault(id);
    public IEnumerable<T> Find(Func<T, bool> predicate) => items.Values.Where(predicate);
    public void Add(T item) => items[getId(item)] = item;
    public void Remove(int id) => items.Remove(id);
}

internal record Vehicle(int Id, string Plate, string Type);
