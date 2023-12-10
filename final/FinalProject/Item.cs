public abstract class Item
{
    protected double _mass;
    protected double _launchAngle;
    protected double _hInitial;
    protected double _vInitial;
    protected double _dragCoeff;
    protected double _area;
    protected List<double> _xPos = new List<double>();
    protected List<double> _zPos = new List<double>();
    protected List<double> _xVel = new List<double>();
    protected List<double> _zVel = new List<double>();
    protected List<double> _time = new List<double>();

    public Item()
    {
        _time.Add(0);
    }
    public abstract void SetTrajectory();
    protected virtual double GetRange()
    {
        return _xPos[^1];
    }
    protected double GetMaxHeight()
    {
        return _zPos.Max();
    }
    protected double GetLandTime()
    {
        return _time[^1];
    }
    public abstract void DisplaySummary();
}