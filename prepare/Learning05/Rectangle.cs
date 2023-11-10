public class Rectangle : Shape
{
    private double _side1;
    private double _side2;

    public Rectangle(string c, double l, double w) : base(c)
    {
        _side1 = l;
        _side2 = w;
    }

    public override double GetArea()
    {
        return _side1 * _side2;
    }
}
