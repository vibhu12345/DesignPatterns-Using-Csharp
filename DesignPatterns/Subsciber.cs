
public class Publisher : IPublisher
{
    private readonly List<Observer> observers;

    public Publisher()
    {
        observers = [];
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);   
    }

    public void NotifyObservers()
    {
        foreach (Observer o in observers)
        {
            o.Update("Hello Subscriber");
        }
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }
    
}

public interface IPublisher
{
    void AddObserver(Observer observer);
    void NotifyObservers();
    void RemoveObserver(Observer observer);
}