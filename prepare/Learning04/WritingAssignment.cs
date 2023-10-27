public class WritingAssignment : Assignment
{
    private string _title;
    public WritingAssignment(string n, string t, string tit) : base(n,t)
    {
        _title = tit;
    }
    public string GetWritingInformation()
    {
        return _title + " by " + _name;
    }
}