internal class Adapter : IAdapter
{
    private IAdaptee adaptee;

    public Adapter(IAdaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public bool AdaptedMethoad()
    {
        return adaptee.AdapteeMethod() > 0;
    }
}

internal interface IAdapter
{
    bool AdaptedMethoad();
}