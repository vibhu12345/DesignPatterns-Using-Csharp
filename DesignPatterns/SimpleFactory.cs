internal class SimpleFactory
{
    public SimpleFactory()
    {
            
    }
    public T CreateProduct<T>() where T: IProduct, new ()
    {
        return new T();
    }
}