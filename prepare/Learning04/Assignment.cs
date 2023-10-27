using System.Collections.Specialized;

public class Assignment
{
    protected string _name;
    private string _topic;
    public Assignment(string n, string t)
    {
        _name = n;
        _topic = t;
    }
    public string GetSummary()
    {
        return _name + " - " + _topic;
    }
}