// Chain of Responsibility with delegates, the way Microsoft built ASP.NET Core middleware.
// Each handler is a lambda that receives the request and a next function and decides whether to call it.
public class Chain
{
    private readonly List<Func<int, Func<Task>, Task>> handlers = [];

    // Register only. Nothing runs yet.
    public Chain Use(Func<int, Func<Task>, Task> handler)
    {
        handlers.Add(handler);
        return this;
    }

    // Terminal handler: it is never given a next, so the chain ends here
    public Chain Run(Func<int, Task> handler) => Use((requestNo, _) => handler(requestNo));

    // Run the whole chain for one request. Call it as many times as you like.
    public Task Handle(int requestNo) => Invoke(0, requestNo);

    // next() is simply "invoke the handler after me"
    private Task Invoke(int index, int requestNo) =>
        index < handlers.Count
            ? handlers[index](requestNo, () => Invoke(index + 1, requestNo))
            : Task.CompletedTask;
}
