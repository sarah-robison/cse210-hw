public abstract class Shape
{
    protected string _color;

    public Shape(string col)
    {
        _color = col;
    }

    public string GetColor()
    {
        return _color;
    }
    protected void SetColor(string c)
    {
        _color = c;
    }
    public abstract double GetArea();
}