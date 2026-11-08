internal class Product1: IProduct 
{
    public Product1()
    {
            
    }
    public override string? ToString()
    {
        // The product uses what its injected factory gives it (null when made by SimpleFactory)
        return Factory is null ? base.ToString() : $"{base.ToString()} with {Factory.CreatePart()}";
    }

    public IFactory Factory { get; set; }
}