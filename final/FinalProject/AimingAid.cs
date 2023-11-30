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
        //constructor here
    }

    public double GetLaunchAngle()
    {
        double h = _hInit - _hFinal;
        double phi = Math.Atan(_xFinal/h);
        double numerator = 9.81*_xFinal*_xFinal/_launchVel/_launchVel - h;
        double denominator = Math.Sqrt(h*h + _xFinal*_xFinal);
        double angle_rad = (Math.Acos(numerator/denominator) + phi) / 2;

        return angle_rad * 180 / Math.PI; //This converts the angle from radians to degrees
    }
    public double GetWindAdjustAngle()
    {
        return Math.Asin(-_crossWind.GetYVel() / _launchVel / Math.Cos(GetLaunchAngle())); //need to figure out how to adjust this since this doesn't take into account how launch angle is affected by crosswind
    }
}