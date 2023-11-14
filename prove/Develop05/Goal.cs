public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completion;
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completion  = false;
    }
    public abstract void RecordEvent(); //need to check how to make a default not just abstract?
    public abstract void DisplayGoal();
    public abstract int GetTotalPointValue();

}