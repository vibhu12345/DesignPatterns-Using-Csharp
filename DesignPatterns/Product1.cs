internal class Product1: IProduct 
{
    public Product1()
    {
            
    }
    public override string? ToString()
    {
        return Factory + base.ToString();
    }

    public IFactory Factory { get; set; }
}