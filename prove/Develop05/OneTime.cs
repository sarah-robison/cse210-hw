public class OneTime : Goal
{
    public OneTime(string n, string d, int p) : base (n,d,p)
    {
        _completion = false; //this feels redundant
    }
    public override void RecordEvent()
    {
        _completion = true;
        Console.WriteLine($"You earned {_points} points!");
        return;
    }
    public override void DisplayGoal()
    {
        if (_completion == false)
        {
            Console.WriteLine($"[ ] {_name} ({_description})");
        }
        else
            Console.WriteLine($"[X] {_name} ({_description})");
        return;
    }
    public override int GetTotalPointValue()
    {
        return _points;
    }

}
