using System.Net;

public abstract class Projectile : Item
{
    protected List<double> _yPos = new List<double>();
    protected List<double> _yVel = new List<double>();
    protected Wind _wind;
    protected double _area;
    
    public Projectile(double m, double a, double h_i, double v_i, double d, Wind w) : base(m,a,h_i,v_i,d)
    {
        _wind = w;
        _yPos.Add(0);
        _yVel.Add(_wind.GetYVel());
        _xVel[0] = _xVel[0] + _wind.GetXVel(); //not sure if this will work, idk if it will do the Item class constructor first. In fact I don't think it will
    }
    public Projectile(double a, double h_i, double v_i, Wind w) : base(a,h_i,v_i)
    {
        _wind = w;
        _yPos.Add(0);
        _yVel.Add(_wind.GetYVel());
        _xVel[0] = _xVel[0] + _wind.GetXVel(); //not sure if this will work
    }
    public override void SetTrajectory()
    {
        double g = 9.81;
        double rho = 1.29;
        double dt = 0.01;
        double az;
        double ax;
        double ay;

        while (_zPos[^1] > 0)
        {
            var v = Math.Sqrt(_xVel[^1]*_xVel[^1] + _yVel[^1]*_yVel[^1] + _zVel[^1]*_zVel[^1]);
            az = -(1/2)*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(v)/_mass - g;
            ax = -(1/2)*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            ay = -(1/2)*rho*_area*_dragCoeff*_yVel[^1]*Math.Abs(v)/_mass; //do i need a different area for arrows from this POV

            _xVel.Add(_xVel[^1] + ax*dt);
            _yVel.Add(_yVel[^1] + ay*dt);
            _zVel.Add(_zVel[^1] + az*dt);

            _xPos.Add(_xPos[^1] + _xVel[^1]*dt);
            _yPos.Add(_yPos[^1] + _yVel[^1]*dt);
            _zPos.Add(_zPos[^1] + _zVel[^1]*dt);
            _time.Add(_time[^1] + dt);
        }

    }
    public override double GetRange()
    {
        return Math.Sqrt(_xPos[^1]*_xPos[^1] + _yPos[^1]*_yPos[^1]);
    }
    public override abstract void DisplaySummary();
    public double GetXFinal()
    {
        return _xPos[^1];
    }
    public double GetYFinal()
    {
        return _yPos[^1];
    }
}