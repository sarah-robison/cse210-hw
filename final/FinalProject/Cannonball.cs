public class Cannonball : Projectile
{
    private double _radius;
    
    public Cannonball()
    {
        Console.WriteLine("What is the mass in kilograms of the cannonball?");
        Console.Write(">");
        _mass = double.Parse(Console.ReadLine());
        Console.WriteLine("What is the radius of the cannonball in meters?");
        Console.Write(">");
        _radius = double.Parse(Console.ReadLine());
        _area = _radius * _radius * Math.PI;
        _areaY = _area;
        _dragCoeff = 0.47;
        _dragCoeffY = _dragCoeff;
    }
    public override void DisplaySummary()
    {
        Console.WriteLine("Projectile Summary:\n");
        Console.WriteLine("Type: Cannonball");
        Console.WriteLine($"Land time: {GetLandTime()} seconds");
        Console.WriteLine($"Maximum height: {GetMaxHeight()} m");
        Console.WriteLine($"Distance covered: {GetRange()} m");
        Console.WriteLine($"Landing location: {GetXFinal()} m in front, {GetYFinal()} m to the left\n");
        Console.WriteLine("Press ENTER to return to the menu");
        Console.ReadLine();
    }
}