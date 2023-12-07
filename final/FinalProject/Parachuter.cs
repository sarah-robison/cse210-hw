public class Parachuter : Item
{
    private double _parachuteArea;
    private double _skydiverDragCoeff;
    private double _deployHeight;
    private double _skydiverArea;

    public Parachuter(double mass, double hi, double deployH) : base(mass,hi)
    {//change these values now that its working?
        _parachuteArea = 5.5 * 5.5 * Math.PI; //looked up military parachute sizes
        _skydiverDragCoeff = 0.58; //looked this up as well
        _skydiverArea = 1.04; //same comment as line above
        _deployHeight = deployH;
    }
    public Parachuter()
    {
        _dragCoeff = 1.75;//military parachute drag coefficient
        _parachuteArea = 5.5 * 5.5 * Math.PI; //looked up military parachute sizes
        _skydiverDragCoeff = 0.58; //looked this up as well
        _skydiverArea = 1.04; //same comment as line above

        Console.WriteLine("What is the mass in kilograms of the parachuter?");
        Console.Write(">");
        _mass = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the starting altitude in meters?");
        Console.Write(">");
        _hInitial = double.Parse(Console.ReadLine());
        Console.WriteLine("At what height above the earth in meters will the parachute be deployed?");
        Console.Write(">");
        _deployHeight = double.Parse(Console.ReadLine());

        _zPos.Add(_hInitial);
        _zVel.Add(0);

    }
    public override void SetTrajectory()
    {
        double g = 9.81;
        double rho;
        double dt = 0.01;
        double az;

        while (_zPos[^1] > 0)
        {
            rho = 1.2 * Math.Exp(-1 * _zPos[^1] / 10000);//a model for the change in air density as a function of altitude
            if (_zPos[^1] > _deployHeight)//before the parachute is deployed
            {
                az = -0.5 * rho * _skydiverArea * _skydiverDragCoeff * _zVel[^1] * Math.Abs(_zVel[^1]) / _mass - g;
            }
            else//after the parachute is deployed
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
    public double GetTerminalVelocity()//terminal velocity with parachute
    {
        return Math.Sqrt(_mass*9.81*2 / (1.29*_parachuteArea*_dragCoeff)); 
    }
    public override void DisplaySummary()
    {
        
    }
}