using System.ComponentModel;

public class Checklist : Goal
{
    private int _total;
    private int _current;
    private int _bonusPoints;

    public Checklist(string n, string d, int p, int t, int b) : base(n,d,p)
    {
        _total = t;
        _current = 0;
        _bonusPoints = b;
    }
    public Checklist(string n, string d, int p, bool comp, int t, int c, int b) : base(n,d,p)
    {
        _completion = comp;
        _total = t;
        _current = c;
        _bonusPoints = b;
    }
    public override void RecordEvent()
    {
        if (_completion == true)
        {
            Console.WriteLine("This goal was already complete.");
        }
        else
        {
            _current += 1;
            Console.WriteLine($"You earned {_points} points!");
            if (_current == _total)
            {
                Console.WriteLine($"You completed this goal, so you earned an extra {_bonusPoints} points!");
                _completion = true;
            }
        }
        return;
    }
    public override void DisplayGoal()
    {
        if (_completion == false)
        {
            Console.WriteLine($"[ ] {_name} ({_description}) {_current}/{_total}");
        }
        else
        {
            Console.WriteLine($"[X] {_name} ({_description}) {_current}/{_total}");
        }
    }
    public override int GetTotalPointValue()
    {
        if (_completion == false)
        {
            return _points * _current;
        }
        else
        {
            return (_points * _current) + _bonusPoints;
        }
    }
    public override string FileDisplay()
    {
        return $"Checklist~{_name}~{_description}~{_points}~{_completion}~{_total}~{_current}~{_bonusPoints}";
    }
}