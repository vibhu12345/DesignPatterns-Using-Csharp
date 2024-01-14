

public class Chain
{
    private readonly Handler handler;
    private readonly int requestNo;
    private bool goNext = true;
    public Chain(int requestNo)
    {
        this.requestNo = requestNo;
        handler = new Handler1();
        var handler2 = new Handler2();
        handler.Next = handler2;
    }    
    public void Run(Action<int> action)
    {
        if (goNext)
        {
            goNext = false;
            action(requestNo);
        }
    }

    private void next()
    {
        goNext = true;
    }

    public void Use(Action<int, Action> action)
    {
        if (goNext)
        {
            goNext = false;
            action(requestNo, next);
        }
    }

    internal void Handle()
    {      
        Console.WriteLine(handler.HandleRequest(requestNo));
    }
}