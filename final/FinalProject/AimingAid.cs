using System.ComponentModel;

public class AimingAid
{
    private double _hInit;
    private double _xFinal;
    private double _hFinal;
    private double _launchVel;
    private Wind _crossWind;

    public AimingAid()
    {
        Console.WriteLine("How far away is the target?");
        Console.Write(">");
        _xFinal = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the height of the target?");
        Console.Write(">");
        _hFinal = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the height you are launching from?");
        Console.Write(">");
        _hInit = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the launch velocity?");
        Console.Write(">");
        _launchVel = double.Parse(Console.ReadLine());
        Console.WriteLine("How fast is the wind moving?");
        Console.Write(">");
        double wv = double.Parse(Console.ReadLine());
        Console.WriteLine("What direction is the wind blowing in with a positive angle measured to the left of the line between the launcher and target?");
        Console.Write(">");
        double wa = double.Parse(Console.ReadLine());
        _crossWind = new Wind(wv,wa);
    }

    public double GetLaunchAngle()
    {
        double angle_rad = Math.Acos(-_crossWind.GetYVel()/_launchVel/Math.Sin(GetWindAdjustAngle()*Math.PI/180));

        return angle_rad * 180 / Math.PI; //This converts the angle from radians to degrees
    }
    public double GetWindAdjustAngle() //Bisection method of root finding
    {
        double end1 = Math.PI/2;
        double end2 = 0;
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
    private double GetGuess(double g)
    {
        double num1 = _xFinal * Math.Sqrt(_launchVel*_launchVel*Math.Sin(g)*Math.Sin(g) - _crossWind.GetYVel());
        double den1 = -_crossWind.GetYVel()*Math.Cos(g) + _crossWind.GetXVel()*Math.Sin(g);
        double den2 = _crossWind.GetYVel()*_crossWind.GetYVel()*Math.Cos(g)*Math.Cos(g)/Math.Sin(g)/Math.Sin(g) - 2*_crossWind.GetYVel()*_crossWind.GetXVel()*Math.Cos(g)/Math.Sin(g) + _crossWind.GetXVel()*_crossWind.GetXVel();
        return _hInit - _hFinal + num1/den1 - 0.5*(9.81)*_xFinal*_xFinal/den2;
    }
}