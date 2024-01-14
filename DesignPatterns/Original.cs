internal class Original: IOriginal
{
    public Original()
    {
    }

    public string DoWork()
    {
        return "Original Work";
    }
}

internal interface IOriginal
{
    string DoWork();
}