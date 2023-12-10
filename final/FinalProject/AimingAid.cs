using System.ComponentModel;
//Assumptions: this model relies on no air resistance and a crosswind that is constant in both direction and magnitude
public class AimingAid
{
    private double _hInit;
    private double _xFinal;
    private double _hFinal;
    private double _launchVel;
    private Wind _crossWind;

    public AimingAid()
    {
        Console.WriteLine("How far away is the target in meters?");
        Console.Write(">");
        _xFinal = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the height of the target in meters?");
        Console.Write(">");
        _hFinal = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the height you are launching from in meters?");
        Console.Write(">");
        _hInit = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the launch velocity in meters per second?");
        Console.Write(">");
        _launchVel = double.Parse(Console.ReadLine());
        Console.WriteLine("How fast is the wind moving in meters per second?");
        Console.Write(">");
        double wv = double.Parse(Console.ReadLine());
        Console.WriteLine("What direction (in degrees) is the wind blowing in (positive angle measured to the left of the line connecting the launcher and target)?");
        Console.Write(">");
        double wa = double.Parse(Console.ReadLine());
        _crossWind = new Wind(wv,wa);
    }

    private double GetWindAdjustAngle()
    {
        //this was derived from the kinematic equations of physics, and requires that you first calculate the crosswind adjust angle
        double angle_rad = Math.Asin(-_crossWind.GetYVel()/_launchVel/Math.Cos(GetLaunchAngle() * Math.PI/180));

        return angle_rad * 180 / Math.PI; //This converts the angle from radians to degrees
    }
    private double GetLaunchAngle() //Bisection method of root finding
    {
        double end1 = 0;
        double end2 = Math.PI/2;
        double mid = (end1 + end2)/2;

        double guess = mid;

        while (Math.Abs(guess) > 0.0000001)
        {
            mid = (end1 + end2)/2;
            guess = GetGuess(mid);

            if (GetGuess(end1) > 0 && guess > 0 || GetGuess(end1)<0 && guess<0)
            {
                end1 = mid;
            }
            else
            {
                end2 = mid;
            }
        }
        double deflectAng = mid * 180 / Math.PI; //convert from radians to degrees
        return deflectAng;
    }
    private double GetGuess(double g)//The function we are trying to find the root of. Made this separate so it doesn't have to be typed in many times in GetWindAdjustAngle()
    {
        //obtainted this function using the kinematic equations of physics
        double cosAlpha = Math.Sqrt(_launchVel*_launchVel*Math.Cos(g)*Math.Cos(g) - _crossWind.GetYVel()*_crossWind.GetYVel());
        double num1 = _xFinal * _launchVel * Math.Sin(g);
        double den1 = _launchVel*Math.Cos(g)*cosAlpha + _crossWind.GetXVel();
        double den2 = _launchVel*_launchVel*Math.Cos(g)*Math.Cos(g)*cosAlpha*cosAlpha + 2*_launchVel*Math.Cos(g)*cosAlpha*_crossWind.GetXVel() + _crossWind.GetXVel()*_crossWind.GetXVel();
        return _hInit - _hFinal + num1/den1 - 0.5*9.81*_xFinal*_xFinal/den2;
    }
    public void DisplayResults()
    {
        Console.WriteLine($"The launch angle you need is {GetLaunchAngle()} degrees above the horizontal.");
        Console.WriteLine($"You also need to aim {GetWindAdjustAngle()} degrees to the left of the target.\n");
        Console.WriteLine("Press ENTER to return to the menu");
        Console.ReadLine();
        return;
    }
}