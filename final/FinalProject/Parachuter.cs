//Assumptions: The parachuter starts with no velocity in any direction and falls straight down
public class Parachuter : Item
{
    private double _parachuteArea;
    private double _skydiverDragCoeff;
    private double _deployHeight;

    public Parachuter()
    {
        _dragCoeff = 1.75;//military parachute drag coefficient
        _parachuteArea = 5.5 * 5.5 * Math.PI; //looked up military parachute sizes
        _skydiverDragCoeff = 0.58; //looked this up as well
        _area = 1.04; //same comment as line above

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

        while (_zPos[^1] > -0.0001)
        {
            rho = 1.2 * Math.Exp(-1 * _zPos[^1] / 10000);//a model for the change in air density as a function of altitude
            if (_zPos[^1] > _deployHeight)//before the parachute is deployed
            {
                az = -0.5 * rho * _area * _skydiverDragCoeff * _zVel[^1] * Math.Abs(_zVel[^1]) / _mass - g;
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
    private double GetLandVelocity()
    {
        return -_zVel[^1]; //Assuming no x or y velocity
    }
    private double GetParaTerminalVelocity()//terminal velocity with parachute
    {
        return Math.Sqrt(_mass*9.81*2 / (1.29*_parachuteArea*_dragCoeff)); 
    }
    private double GetTerminalVelocity()//terminal velocity without parachute
    {
        return Math.Sqrt(_mass*9.81*2 / (1.29*_area*_skydiverDragCoeff)); 
    }
    public override void DisplaySummary()
    {
        Console.WriteLine("Parachuter Summary:\n");
        Console.WriteLine($"Land time: {GetLandTime()} seconds");
        Console.WriteLine($"Landing velocity: {GetLandVelocity()} m/s");
        Console.WriteLine($"Terminal velocity without parachute: {GetTerminalVelocity()} m/s");
        Console.WriteLine($"Terminal velocity with parachute: {GetParaTerminalVelocity()} m/s\n");
        Console.WriteLine("Press ENTER to return to the menu");
        Console.ReadLine();
    }
}