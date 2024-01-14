internal class State1:IState
{
    public State1()
    {
    }

    public void DoWork1()
    {
        Console.WriteLine("State1 " + nameof(DoWork1));
    }

    public void DoWork2()
    {
        Console.WriteLine("State1 " + nameof(DoWork2));
    }
}
internal class State2 : IState
{
    public State2()
    {
    }

    public void DoWork1()
    {
        Console.WriteLine("State2 " + nameof(DoWork1));
    }

    public void DoWork2()
    {
        Console.WriteLine("State2 " + nameof(DoWork2));
    }
}

internal interface IState
{
    void DoWork1();
    void DoWork2();
}