public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;
    public MathAssignment(string n, string t, string tbs, string p) : base(n,t)
    {
        _textbookSection = tbs;
        _problems = p;
    }
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}