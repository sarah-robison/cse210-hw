using System.Runtime.InteropServices;

public class Arrow : Projectile
{
    public Arrow()
    {
        //googled all of this stuff
        _area = 0.00003;//approximate cross sectional area of arrow viewed point-on
        _dragCoeff = 0.4;//approximate drag coefficient of arrow moving point-forward
        _mass = 0.024;//approximate weight of an arrow
        _areaY = .0099;//approximate cross sectional area of the arrow shaft and fletching
        _dragCoeffY = 1.08;//approximate drag coefficient for the shaft
    }
    public override void DisplaySummary()
    {
        Console.WriteLine("Projectile Summary:\n");
        Console.WriteLine("Type: Arrow");
        Console.WriteLine($"Land time: {GetLandTime()} seconds");
        Console.WriteLine($"Maximum height: {GetMaxHeight()} m");
        Console.WriteLine($"Distance covered: {GetRange()} m");
        Console.WriteLine($"Landing location: {GetXFinal()} m in front, {GetYFinal()} m to the left\n");
        Console.WriteLine("Press ENTER to return to the menu");
        Console.ReadLine();
    }
}