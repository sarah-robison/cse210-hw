public class Eternal : Goal
{
    private int _timesCompleted;

    public Eternal(string n, string d, int p) : base(n,d,p)
    {
        _timesCompleted = 0;
    }
    public override void RecordEvent()
    {
        _timesCompleted += 1;
        Console.WriteLine($"You earned {_points} points!");
        return;
    }
    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {_name} ({_description})");
    }
    public override int GetTotalPointValue()
    {
        return _timesCompleted * _points;
    }
}