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
        return Factory + base.ToString();
    }

    public IFactory Factory { get; set ; }
}