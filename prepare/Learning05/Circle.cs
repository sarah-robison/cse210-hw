public class Circle : Shape
{
    private double _radius;

    public Circle(string c, double r) : base(c)
    {
        _radius = r;
    }

    public override double GetArea()
    {
        return _radius * _radius * 3.14;
    }
}