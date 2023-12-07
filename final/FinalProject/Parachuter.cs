public class Parachuter : Item
{
    private double _parachuteArea;
    private double _skydiverDragCoeff;
    private double _deployHeight;
    private double _skydiverArea;

    public Parachuter(double mass, double hi, double deployH) : base(mass,hi)
    {
        _parachuteArea = 5.5 * 5.5 * Math.PI; //looked up military parachute sizes
        _skydiverDragCoeff = 0.58; //looked this up as well, assumes falling headfirst
        _skydiverArea = 1.04; //same comment as line above
        _deployHeight = deployH;
    }
    public override void SetTrajectory()
    {
        double g = 9.81;
        double rho;
        double dt = 0.01;
        double az;

        while (_zPos[^1] > 0)
        {
            rho = 1.2 * Math.Exp(-1 * _zPos[^1] / 10000);
            if (_zPos[^1] > _deployHeight)
            {
                az = -0.5 * rho * _skydiverArea * _skydiverDragCoeff * _zVel[^1] * Math.Abs(_zVel[^1]) / _mass - g;
            }
            else
            {
                az = -0.5 * rho * _parachuteArea * _dragCoeff * _zVel[^1] * Math.Abs(_zVel[^1]) / _mass - g;
            }
            _zVel.Add(_zVel[^1] + az*dt);
            _zPos.Add(_zPos[^1] + _zVel[^1]*dt);
            _time.Add(_time[^1] + dt);
        }
        
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