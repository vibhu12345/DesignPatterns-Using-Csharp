internal class DecoratedOriginal:IOriginal
{
    private IOriginal original;

    public DecoratedOriginal(IOriginal original)
    {
        this.original = original;
    }

    public string DoWork()
    {
        return "Decorated " + original.DoWork();
    }
}