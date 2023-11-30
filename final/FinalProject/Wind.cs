public class Wind
{
    private double _windVelocity;
    private double _windAngle; //with positive measured to the left of the x axis (the line between the shooter and the target)

    public Wind()
    {
        _windVelocity = 0;
        _windAngle = 0;
    }
    public Wind(double wv, double wa)
    {
        _windVelocity = wv;
        _windAngle = wa;
    }
    public double GetYVel()
    {
        return _windVelocity * Math.Sin(_windAngle * Math.PI/180);
    }
    public double GetXVel()
    {
        return _windVelocity * Math.Cos(_windAngle * Math.PI/180);
    }
}