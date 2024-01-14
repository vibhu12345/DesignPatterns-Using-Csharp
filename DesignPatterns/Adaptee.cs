internal class Adaptee : IAdaptee
{
    public Adaptee() 
    {
    }

    public int AdapteeMethod()
    {
        return 1;
    }
}

internal interface IAdaptee
{
    int AdapteeMethod();
}