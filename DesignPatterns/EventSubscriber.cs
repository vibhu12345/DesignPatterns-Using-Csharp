internal class EventPublisher: IPublisher
{
    private event EventHandler<string> OnEvent = delegate { };

    public void AddObserver(Observer observer)
    {
        OnEvent += observer.Update;
    }
    public void RemoveObserver(Observer observer) {
        OnEvent -= observer.Update;
    }

    public void NotifyObservers()
    {
        OnEvent(this, "Hello Subscribers");
    }   
}