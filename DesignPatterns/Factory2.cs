internal class Factory2 : IFactory
{
    public IProduct CreateProduct(string productType)
    {
        if (productType == "Product1") return new Factory2Product1();
        else return new Factory2Product2();
    }

}