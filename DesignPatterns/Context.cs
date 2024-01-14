
internal class Context
{
    private  IState state;
    private  IState state2;

    public Context(IState state1, IState state2)
    {
        this.state = state1;
        this.state2 = state2;
    }

    internal void DoWork1()
    {
        state.DoWork1();
        var temp = state;
        state = state2;
        state2 = temp;
    }
    internal void DoWork2()
    {
        state.DoWork2();
        var temp = state;
        state = state2;
        state2 = temp;
    }
}