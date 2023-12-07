using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

//describe assumptions

public class Rocket : Item
{
    private double _fuelMass;
    private double _exhaustVel;
    private double _burnRate;

    public Rocket(double mass, double ang, double hi, double r, double fm, double br, double ex) : base(mass,ang,hi)
    {
        _area = r * r * Math.PI;
        _exhaustVel = ex;
        _burnRate = br;
        _fuelMass = fm;
    }
    public Rocket()
    {
        _dragCoeff = 0.75;
        Console.WriteLine("What is the mass in kilograms of the whole rocket?");
        Console.Write(">");
        _mass = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the mass in kilograms of the fuel?");
        Console.Write(">");
        _fuelMass = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the burn rate in kilograms per second of the fuel?");
        Console.Write(">");
        _burnRate = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the exhaust velocity of the fuel in meters per second?");
        Console.Write(">");
        _exhaustVel = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the diameter of the rocket in meters?");
        Console.Write(">");
        double diameter = double.Parse(Console.ReadLine());
        _area = diameter * diameter * Math.PI / 4;
        Console.WriteLine("From what altitude in meters is the rocket being launched?");
        Console.Write(">");
        _hInitial = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the launch angle in degrees above the horizontal?");
        Console.Write(">");
        _launchAngle = double.Parse(Console.ReadLine());

        _xPos.Add(0);
        _zPos.Add(_hInitial);
        _xVel.Add(_vInitial * Math.Cos(_launchAngle * Math.PI/180));//are these needed?
        _zVel.Add(_vInitial * Math.Sin(_launchAngle * Math.PI/180));//needed?
    }
    public override void SetTrajectory()//account for change in air density and gravity?
    {
        double g = 9.81; //might change this to vary with height
        double rho;
        double dt = 0.01;
        double az;
        //double ax;

        while (_zPos[^1] > -0.00001)
        {
            rho = Math.Pow(1.09 - (0.0065 * _zPos[^1] / 300),2.5);
            //var v = Math.Sqrt(_xVel[^1]*_xVel[^1] + _zVel[^1]*_zVel[^1]);
            //var theta = Math.Atan(_zVel[^1]/_xVel[^1]);//dividing by zero issue??
            if (_fuelMass > 0)
            {
                _fuelMass -= _burnRate * dt;
                _mass -= _burnRate * dt;
                az = _burnRate * _exhaustVel/_mass - 0.5*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(_zVel[^1])/_mass - g;
                //ax = _burnRate * _exhaustVel/_mass * Math.Cos(theta) - (1/2)*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            }
            else
            {
                az = -0.5*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(_zVel[^1])/_mass - g;
                //ax = -(1/2)*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            }
            //_xVel.Add(_xVel[^1] + ax*dt);
            _zVel.Add(_zVel[^1] + az*dt);

            //_xPos.Add(_xPos[^1] + _xVel[^1]*dt);
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