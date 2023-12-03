public class Parachuter : Item
{
    private double _parachuteArea;
    private double _skydiverDragCoeff;
    private double _deployHeight;
    private double _skydiverArea;

    public Parachuter(double mass, double hi, double deployH) : base(mass,hi)
    {
        _parachuteArea = 5.5 * 5.5 * Math.PI; //looked up military parachute sizes
        _skydiverDragCoeff = 0.7; //looked this up as well, assumes falling headfirst
        _skydiverArea = 0.18; //same comment as line above
        _deployHeight = deployH;
    }
    public override void SetTrajectory()
    {
        
    }
    public double GetLandVelocity()
    {
        return _zVel[-1]; //Assuming no x or y velocity
    }
    public double GetTerminalVelocity()
    {
        return Math.Sqrt(_mass*9.81*2 / (1.29*_parachuteArea*_dragCoeff));
    }
    public override void DisplaySummary()
    {
        
    }
}