public class OneTime : Goal
{
    public OneTime(string n, string d, int p) : base (n,d,p)
    {
        _completion = false; //this feels redundant
    }
    public OneTime(string n, string d, int p, bool c) : base (n,d,p)
    {
        _completion = c;
    }
    public override void RecordEvent()
    {
        if (_completion == true)
        {
            Console.WriteLine("This goal was already completed.");
        }
        else
        {
            _completion = true;
            Console.WriteLine($"You earned {_points} points!");
        }
        return;
    }

    public override int GetTotalPointValue()
    {
        if (_completion == true)
        {
            return _points;
        }
        else
        {
            return 0;
        }
    }
    public override string FileDisplay()
    {
        return $"OneTime~{_name}~{_description}~{_points}~{_completion}";
    }

}
