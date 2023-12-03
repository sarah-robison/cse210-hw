public class Cannonball : Projectile
{
    private double _radius;

    public Cannonball(double m, double a, double h_i, double v_i, double d, Wind w, double r) : base(m,a,h_i,v_i,d,w)
    {
        _radius = r;
        _area = _radius * _radius * Math.PI;
        _dragCoeff = 0.5;
    }
    public override void DisplaySummary()
    {
        //specify that its a cannonball and give the specs
    }
}