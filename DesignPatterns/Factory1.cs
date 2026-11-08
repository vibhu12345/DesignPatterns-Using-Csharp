internal class Factory1 : IFactory
{

    public IProduct CreateProduct(string productType)
    {
        if (productType == "Product1") return new Factory1Product1();
        else return new Factory1Product2();
    }

    public string CreatePart() => "Factory1 part";
}

public interface IFactory
{
    IProduct CreateProduct(string productType);

    // What makes each factory's family different. Products ask their factory for it (composition).
    string CreatePart();

    // Shared by every factory: inject this factory into the product
    IProduct CreateProduct<T>() where T : IProduct, new()
    {
        return new T() { Factory = this };
    }
}