internal class Factory1 : IFactory
{

    public IProduct CreateProduct(string productType)
    {
        if (productType == "Product1") return new Factory1Product1();
        else return new Factory1Product2();
    }
}

public interface IFactory
{
    IProduct CreateProduct(string productType);
    IProduct CreateProduct<T>() where T : IProduct, new()
    {
        return new T() { Factory = this };
    }
}