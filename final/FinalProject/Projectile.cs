using System.Net;

public abstract class Projectile : Item
{
    protected List<double> _yPos = new List<double>();
    protected List<double> _yVel = new List<double>();
    protected Wind _wind;
    
    public Projectile()
    {
        Console.WriteLine("What is the launch angle in degrees above the horizontal?");
        Console.Write(">");
        _launchAngle = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the initial height in meters to be launched from?");
        Console.Write(">");
        _hInitial = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the launch velocity in meters per second?");
        Console.Write(">");
        _vInitial = double.Parse(Console.ReadLine());
        Console.WriteLine("How fast is the wind moving in meters per second?");
        Console.Write(">");
        double w_v = double.Parse(Console.ReadLine());
        Console.WriteLine("What direction (in degrees) is the wind blowing in (positive angle measured to the left of the line connecting the launcher and target)?");
        Console.Write(">");
        double w_a = double.Parse(Console.ReadLine());
        _wind = new Wind(w_v,w_a);

        _xPos.Add(0);
        _zPos.Add(_hInitial);
        _xVel.Add(_vInitial * Math.Cos(_launchAngle * Math.PI/180) + _wind.GetXVel());
        _zVel.Add(_vInitial * Math.Sin(_launchAngle * Math.PI/180));
        _yPos.Add(0);
        _yVel.Add(_wind.GetYVel());
    }
    public override void SetTrajectory()
    {
        double g = 9.81;
        double rho = 1.29;
        double dt = 0.01;
        double az;
        double ax;
        double ay;

        while (_zPos[^1] > -0.00001)
        {
            var v = Math.Sqrt(_xVel[^1]*_xVel[^1] + _yVel[^1]*_yVel[^1] + _zVel[^1]*_zVel[^1]);
            az = -0.5*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(v)/_mass - g;
            ax = -0.5*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            ay = -0.5*rho*_area*_dragCoeff*_yVel[^1]*Math.Abs(v)/_mass; //do i need a different area for arrows from this POV

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