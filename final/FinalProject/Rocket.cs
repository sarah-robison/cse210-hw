using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

//describe assumptions

public class Rocket : Item
{
    private double _fuelMass;
    private double _exhaustVel;
    private double _burnRate;
    private double _area;

    public Rocket(double mass, double ang, double hi, double a, double fm, double br, double ex) : base(mass,ang,hi)
    {
        _area = a; //change this later to a radius????
        _exhaustVel = ex;
        _burnRate = br;
        _fuelMass = fm;
    }
    public override void SetTrajectory()//account for change in air density and gravity?
    {
        double g = 9.81; //might change this to vary with height
        double rho;
        double dt = 0.01;
        double az;
        double ax;

        while (_zPos[^1] > 0)
        {
            rho = Math.Pow(1.09 - (0.0065 * _zPos[^1] / 300),2.5);
            var v = Math.Sqrt(_xVel[^1]*_xVel[^1] + _zVel[^1]*_zVel[^1]);
            var theta = Math.Atan(_zVel[^1]/_xVel[^1]);
            if (_fuelMass > 0)
            {
                _fuelMass = _fuelMass - _burnRate * dt;
                _mass = _mass - _burnRate * dt;
                az = _burnRate * _exhaustVel/_mass * Math.Sin(theta) - (1/2)*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(v)/_mass - g;
                ax = _burnRate * _exhaustVel/_mass * Math.Cos(theta) - (1/2)*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            }
            else
            {
                az = -(1/2)*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(v)/_mass - g;
                ax = -(1/2)*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            }
            _xVel.Add(_xVel[^1] + ax*dt);
            _zVel.Add(_zVel[^1] + az*dt);

            _xPos.Add(_xPos[^1] + _xVel[^1]*dt);
            _zPos.Add(_zPos[^1] + _zVel[^1]*dt);
            _time.Add(_time[^1] + dt);

        }
        
    }
    public override void DisplaySummary()
    {
        
    }
    public override double GetRange()
    {
        if (EscapeEarth() == true)
        {
            return 0;//better way to handle this?
        }
        else
        {
            return _xPos[-1];
        }
    }
    public bool EscapeEarth()
    {
        if (_zVel.Max() >= 11200)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}