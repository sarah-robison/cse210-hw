using System.Security.Cryptography.X509Certificates;

//describe assumptions

public class Rocket : Item
{
    private double _fuelMass;
    private double _exhaustVel;

    public Rocket(double mass, double ang, double hi, double fm, double ex) : base(mass,ang,hi)
    {
        _exhaustVel = ex;
        _fuelMass = fm;
    }
    public override void SetTrajectory()//account for change in air density and gravity?
    {
        
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