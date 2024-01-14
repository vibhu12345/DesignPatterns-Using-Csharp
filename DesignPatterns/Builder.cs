
internal class Builder
{
    public Builder()
    {
    }

    public override string? ToString()
    {
        return $"{Property1} {Property2} {Property3}";
    }

    public string Property1 { get; private set; }
    public string Property2 { get; private set; }
    public string Property3 { get; private set; }

    internal Builder SetProperty1(string property1)
    {
        Property1 = property1;
        return this;
    }
    internal Builder SetProperty2(string property2)
    {
        Property2 = property2;
        return this;
    }

    internal Builder SetProperty3(string property3)
    {
        Property3 = property3;
        return this;
    }
}