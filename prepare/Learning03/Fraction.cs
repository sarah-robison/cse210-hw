using System.Diagnostics;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int t, int b)
    {
        _top = t;
        _bottom = b;
    }

    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int t)
    {
        _top = t;
    }

    public void SetBottom(int b)
    {
        _bottom = b;
    }

    public string GetFractionString()
    {
        string str = _top.ToString() + "/" + _bottom.ToString();
        return str;
    }

    public double GetDecimalValue()
    {
        double divide = (double)_top/_bottom;
        return divide;
    }
}