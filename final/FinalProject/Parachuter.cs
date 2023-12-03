public class Parachuter : Item
{
    private double _parachuteArea;
    private double _skydiverDragCoeff;
    private double _deployHeight;

    public Parachuter()
    {

    }
    public double GetLandVelocity()
    {
        return _zVel[-1]; //Assuming no x or y velocity
    }
    public double GetTerminalVelocity()
    {
        
    }
    public override void DisplaySummary()
    {
        
    }
}