public class Log
{
    private string _fileName;
    private List<Goal> _goalList = new List<Goal>();

    public Log(string file) //do i need this constructor?
    {
        _fileName = file;
    }
    public int GetTotalPoints()
    {
        int tot = 0;
        foreach (Goal g in _goalList)
        {
            tot += g.GetTotalPointValue();
        }
        return tot;
    }
    public void DisplayGoals() //do i need one for incomplete goals for event recording?
    {
        foreach (Goal g in _goalList)
        {
            //display it with a number!
            g.DisplayGoal();
        }
        return;
    }
    public void AddGoal()
    {
        //conditionals for each type of goal
    }
    public void WriteToFile()
    {
        Console.WriteLine("Please input file name with .txt extension: ");
        Console.Write(">");
        _fileName = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(_fileName))
            {
                foreach (Goal goal in _goalList)
                {
                    outputFile.WriteLine(goal.FileDisplay());
                }
            }
        Console.WriteLine($"Saved successfully as {_fileName}");
    }
    public List<Goal> LoadFile()
    {
        //load txt file to a log
        Console.WriteLine("File name with extension: ");
        Console.Write(">");
        _fileName = Console.ReadLine();
        string[] entries = System.IO.File.ReadAllLines(_fileName);
        List<Goal> goals = new List<Goal>();

        foreach (string g in entries)
        {
            string[] parts = g.Split("~");

            if (parts[0] == "Checklist")
            {
                Checklist goal1 = new Checklist(parts[1],parts[2],int.Parse(parts[3]),bool.Parse(parts[4]),int.Parse(parts[5]),int.Parse(parts[6]),int.Parse(parts[7]));
                goals.Add(goal1);
            }
            else if (parts[0] == "Eternal")
            {
                Eternal goal1 = new Eternal(parts[1],parts[2],int.Parse(parts[3]),int.Parse(parts[4]));
                goals.Add(goal1);
            }
            else
            {
                OneTime goal1 = new OneTime(parts[1],parts[2],int.Parse(parts[3]),bool.Parse(parts[4]));
                goals.Add(goal1);
            }
        }
        return goals;
    }
}