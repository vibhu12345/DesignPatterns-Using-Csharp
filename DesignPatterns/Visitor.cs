internal interface IVisitor<T>
{
    T Visit(Circle circle);
    T Visit(Rectangle rectangle);
}

internal abstract record Shape
{
    public abstract T Accept<T>(IVisitor<T> visitor);
}

internal record Circle(double Radius) : Shape
{
    public override T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
}

internal record Rectangle(double Width, double Height) : Shape
{
    public override T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
}

internal class AreaVisitor : IVisitor<double>
{
    public double Visit(Circle circle) => Math.PI * circle.Radius * circle.Radius;
    public double Visit(Rectangle rectangle) => rectangle.Width * rectangle.Height;
}
