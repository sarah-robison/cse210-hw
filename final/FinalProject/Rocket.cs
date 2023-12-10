using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

//Assumptions: the force of thrust, burn rate, and exhaust velocity are all constant. 
//The direction of thrust is always the initial launch angle.

public class Rocket : Item
{
    private double _fuelMass;
    private double _exhaustVel;
    private double _burnRate;

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
        _xVel.Add(_vInitial * Math.Cos(_launchAngle * Math.PI/180));
        _zVel.Add(_vInitial * Math.Sin(_launchAngle * Math.PI/180));
    }
    public override void SetTrajectory()
    {
        double g;
        double rho;
        double dt = 0.01;
        double az;
        double ax;
        double radiusEarth = 6370000.0;

        while (_zPos[^1] > -0.00001)
        {
            g = 9.81/(1+_zPos[^1]/radiusEarth)/(1+_zPos[^1]/radiusEarth);
            rho = Math.Pow(1.09 - (0.0065 * _zPos[^1] / 300),2.5);
            double v = Math.Sqrt(_xVel[^1]*_xVel[^1] + _zVel[^1]*_zVel[^1]);
            //double theta = Math.PI/2 - Math.Atan(_xVel[^1]/_zVel[^1]);//current angle of velocity
            if (_fuelMass > 0.0)
            {
                _fuelMass -= _burnRate * dt;
                _mass -= _burnRate * dt;
                az = _burnRate * _exhaustVel/_mass * Math.Sin(_launchAngle*Math.PI/180) - 0.5*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(v)/_mass - g;
                ax = _burnRate * _exhaustVel/_mass * Math.Cos(_launchAngle*Math.PI/180) - 0.5*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            }
            else
            {
                az = -0.5*rho*_area*_dragCoeff*_zVel[^1]*Math.Abs(v)/_mass - g;
                ax = -0.5*rho*_area*_dragCoeff*_xVel[^1]*Math.Abs(v)/_mass;
            }
            _xVel.Add(_xVel[^1] + ax*dt);
            _zVel.Add(_zVel[^1] + az*dt);

            _xPos.Add(_xPos[^1] + _xVel[^1]*dt);
            _zPos.Add(_zPos[^1] + _zVel[^1]*dt);
            _time.Add(_time[^1] + dt);

            if (v >= 11200.0)//if the rocket passes the escape velocity, it theoretically will never come back down
            {
                break;
            }

        }
        
    }
    public override void DisplaySummary()
    {
        Console.WriteLine("Rocket Summary:\n");
        if (EscapeEarth() == true)
        {
            Console.WriteLine("Your rocket surpassed the escape velocity of earth! (11,200 m/s)\n");
        }
        else
        {
            Console.WriteLine($"Land time: {GetLandTime()} seconds");
            Console.WriteLine($"Maximum height: {GetMaxHeight()} m");
            Console.WriteLine($"Distance covered: {GetRange()} m\n");
        }
        Console.WriteLine("Press ENTER to return to the menu");
        Console.ReadLine();
    }
    private bool EscapeEarth()
    {
        if (_zVel.Max() >= 11200.0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}