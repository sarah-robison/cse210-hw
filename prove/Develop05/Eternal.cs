public class Eternal : Goal
{
    private int _timesCompleted;

    public Eternal(string n, string d, int p) : base(n,d,p)
    {
        _timesCompleted = 0;
    }
    public Eternal(string n, string d, int p, int t) : base(n,d,p)
    {
        _timesCompleted = t;
    }
    public override void RecordEvent()
    {
        _timesCompleted += 1;
        Console.WriteLine($"You earned {_points} points!");
        return;
    }

    public override int GetTotalPointValue()
    {
        return _timesCompleted * _points;
    }
    public override string FileDisplay()
    {
        return $"Eternal~{_name}~{_description}~{_points}~{_timesCompleted}";
    }
}