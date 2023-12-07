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
        _dragCoeff = 0.02;//check to see if this value is right
    }
    public override void DisplaySummary()
    {
        //specify that its a cannonball and give the specs
    }
}