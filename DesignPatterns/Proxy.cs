using System.Reflection;

public interface IService
{
    string DoWork(string input);
}

internal class Service : IService
{
    public string DoWork(string input) => "Work done for " + input;
}

// One proxy class for every interface: the runtime writes the implementation of T
public class LoggingProxy<T> : DispatchProxy where T : class
{
    private T target = null!;

    public static T Create(T target)
    {
        var proxy = Create<T, LoggingProxy<T>>();
        ((LoggingProxy<T>)(object)proxy).target = target;
        return proxy;
    }

    // Every call on the interface arrives here
    protected override object? Invoke(MethodInfo? method, object?[]? args)
    {
        Console.WriteLine($"Proxy: calling {method!.Name}");
        var result = method.Invoke(target, args);
        Console.WriteLine($"Proxy: {method.Name} returned");
        return result;
    }
}
