

public class Observer: IObserver
{
    private string? message;
    private IPublisher? publisher;


    public void Update(string message)
    {
        this.message = message;
        
    }
    public void Update(object? publisher, string message)
    {
        this.message = message;
        this.publisher = publisher as IPublisher;

    }
    public void ProcessMessage()
    {
        Console.WriteLine("Received: " +(message??"No Message"));
        message = null;
    }

    public void RemoveSubscription(IPublisher publisher)
    {
        publisher.RemoveObserver(this);
    }
    public void RemoveSubscription()
    {
        publisher?.RemoveObserver(this);
    }
}

public interface IObserver
{
    void RemoveSubscription(IPublisher publisher);
    void Update(string message);
}