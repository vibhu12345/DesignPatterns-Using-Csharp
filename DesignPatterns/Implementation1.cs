internal class Implementation1:IImplementation
{
    public Implementation1()
    {
    }
}
internal class Implementation2 : IImplementation
{
    public Implementation2()
    {
    }
}
internal interface IImplementation
{
    string DoWork()
    {
        return $"{this} Work";
    }
}