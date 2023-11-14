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
    public void DisplayGoals()
    {
        foreach (Goal g in _goalList)
        {
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
                outputFile.WriteLine();//make another method for each type for file writing
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

            Goal goal1 = new Goal();
            //update this to be appropriate for the goals not entries
            //entry1._date = parts[0];
            //entry1._prompt = parts[1];
            //entry1._entry = parts[2];
            goals.Add(goal1);
        }
        return goals;
    }
}