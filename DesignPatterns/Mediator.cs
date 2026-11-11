internal class Mediator
{
    // The message type is the routing key
    private readonly Dictionary<Type, List<Delegate>> handlers = [];

    public void Register<T>(Action<T> handler)
    {
        if (!handlers.TryGetValue(typeof(T), out var list)) handlers[typeof(T)] = list = [];
        list.Add(handler);
    }

    public void Send<T>(T message)
    {
        if (!handlers.TryGetValue(typeof(T), out var list)) return;
        foreach (var handler in list) ((Action<T>)handler)(message);
    }
}
