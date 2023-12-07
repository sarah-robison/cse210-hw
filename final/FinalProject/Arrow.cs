using System.Runtime.InteropServices;

public class Arrow : Projectile
{
    public Arrow()
    {
        //googled all of this stuff
        _area = 0.009;
        _dragCoeff = 0.4;
        _mass = 0.05;
    }
    public override void DisplaySummary()
    {
        //specify that its an arrow and give values used to calculate?
    }
}