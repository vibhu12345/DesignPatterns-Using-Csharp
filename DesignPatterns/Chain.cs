

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
    public void HandleLikeMiddleWares()
    {        
        Use((requestNo, next) =>
        {
            if (requestNo == 1) Console.WriteLine($"Handler {requestNo} Handled the request");
            next();
        });
        Use((requestNo, next) =>
        {
            if (requestNo == 2) Console.WriteLine($"Handler {requestNo} Handled the request");
            next();
        });
        Run(requestNo =>
        {
            if (requestNo == 3) Console.WriteLine($"Handler {requestNo} Handled the request");
            else Console.WriteLine($"No Handler handled the request {requestNo}");
        });
    }
    private void Run(Action<int> action)
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

    private void Use(Action<int, Action> action)
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