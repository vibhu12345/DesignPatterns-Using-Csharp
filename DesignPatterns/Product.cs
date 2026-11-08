public interface IProduct
{
    IFactory Factory { get; set; }
}

public class Product2: IProduct
{
    public Product2()
    {

    }

    public override string? ToString()
    {
        // The product uses what its injected factory gives it (null when made by SimpleFactory)
        return Factory is null ? base.ToString() : $"{base.ToString()} with {Factory.CreatePart()}";
    }

    public IFactory Factory { get; set ; }
}