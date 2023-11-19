public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completion; //is this necessary?
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completion  = false;
    }
    public abstract void RecordEvent();
    public virtual void DisplayGoal()
    {
        if (_completion == false)
        {
            Console.WriteLine($"[ ] {_name} ({_description})");
        }
        else
            Console.WriteLine($"[X] {_name} ({_description})");
        return;
    }
    public abstract int GetTotalPointValue();
    public abstract string FileDisplay();

}