public abstract class Item
{
    protected double _mass;
    protected double _launchAngle;
    protected double _hInitial;
    protected double _vInitial;
    protected double _dragCoeff;
    protected List<double> _xPos = new List<double>();
    protected List<double> _zPos = new List<double>();
    protected List<double> _xVel = new List<double>();
    protected List<double> _zVel = new List<double>();
    protected List<double> _time = new List<double>();

    public Item(double mass, double ang, double hi, double vi, double drag)
    {
        _mass = mass;
        _launchAngle = ang;
        _vInitial  = vi;
        _dragCoeff = drag;
        _xPos.Add(0);
        _zPos.Add(hi);
        _time.Add(0);
        _xVel.Add(_vInitial * Math.Cos(_launchAngle * Math.PI/180));
        _zVel.Add(_vInitial * Math.Sin(_launchAngle * Math.PI/180));

    }
    public virtual double GetRange()
    {
        return _xPos[-1];
    }
    public double GetMaxHeight()
    {
        return _zPos.Max();
    }
    public double GetLandTime()
    {
        return _time[-1];
    }
    public abstract void DisplaySummary();
}