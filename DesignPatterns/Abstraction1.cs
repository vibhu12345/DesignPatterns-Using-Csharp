internal class Abstraction1:IAbstraction
{
    private IImplementation implementation;

    public Abstraction1(IImplementation implementation)
    {
        this.implementation = implementation;
    }

    public string DoWork()
    {
        return this+" "+implementation.DoWork();
    }
}
internal class Abstraction2 : IAbstraction
{
    private IImplementation implementation;

    public Abstraction2(IImplementation implementation)
    {
        this.implementation = implementation;
    }

    public string DoWork()
    {
        return this + " " + implementation.DoWork() + " better than others";
    }
}
internal interface IAbstraction
{
    string DoWork();
}