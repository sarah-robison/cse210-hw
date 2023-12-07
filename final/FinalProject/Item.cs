public abstract class Item
{
    protected double _mass;
    protected double _launchAngle;
    protected double _hInitial;//do i need this?
    protected double _vInitial;
    protected double _dragCoeff;
    //add area to this class?
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
    public Item(double mass, double hi) //for the parachuter class
    {
        _mass = mass;
        _dragCoeff = 1.75;
        _zPos.Add(hi);
        _zVel.Add(0);
        _time.Add(0);
    }
    public Item(double mass, double ang, double hi)//for the rocket class
    {
        _mass = mass;
        _launchAngle = ang;
        _dragCoeff = 0.75;
        _xPos.Add(0);
        _zPos.Add(hi);
        _time.Add(0);
        _xVel.Add(_vInitial * Math.Cos(_launchAngle * Math.PI/180));//are these needed?
        _zVel.Add(_vInitial * Math.Sin(_launchAngle * Math.PI/180));//needed?
    }
    public abstract void SetTrajectory();
    public virtual double GetRange()
    {
        return _xPos[^1];
    }
    public double GetMaxHeight()
    {
        return _zPos.Max();
    }
    public double GetLandTime()
    {
        return _time[^1];
    }
    public abstract void DisplaySummary();
}