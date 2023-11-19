using System.Security.Cryptography.X509Certificates;

public class Log
{
    private string _fileName;
    private List<Goal> _goalList = new List<Goal>();

    public Log()
    {
        _fileName = "default.txt";
    }
    public Log(string file) //do i need this constructor?
    {
        _fileName = file;
    }
    public List<Goal> GetGoalList()
    {
        return _goalList;
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
        int count = 1;
        foreach (Goal g in _goalList)
        {
            Console.Write($"{count}. ");
            g.DisplayGoal();
            count ++;
        }
        return;
    }
    public void AddGoal(int choice)
    {
        //conditionals for each type of goal
        //or make three separate ones??
        if (choice == 1)
        {
            _goalList.Add(AddChecklist());
        }
        else if (choice == 2)
        {
            _goalList.Add(AddEternal());
        }
        else if (choice == 3)
        {
            _goalList.Add(AddOneTime());
        }
        else
        {
            Console.WriteLine("Error.");
        }
        Console.Clear();
    }
    private Checklist AddChecklist()
    {
        Console.WriteLine("What is the name of your goal?");
        Console.Write(">");
        string name = Console.ReadLine();
        Console.WriteLine("What is the description of your goal?");
        Console.Write(">");
        string descrip = Console.ReadLine();
        Console.WriteLine("How many points is this goal worth?");
        Console.Write(">");
        int point = int.Parse(Console.ReadLine());
        Console.WriteLine("How many times do you want to do this goal?");
        Console.Write(">");
        int total = int.Parse(Console.ReadLine());
        Console.WriteLine($"How many bonus points should you get for completing this all {total} times?");
        Console.Write(">");
        int bp = int.Parse(Console.ReadLine());
        Checklist newCheck = new Checklist(name,descrip,point,total,bp);
        return newCheck;
    }
    private Eternal AddEternal()
    {
        Console.WriteLine("What is the name of your goal?");
        Console.Write(">");
        string name = Console.ReadLine();
        Console.WriteLine("What is the description of your goal?");
        Console.Write(">");
        string descrip = Console.ReadLine();
        Console.WriteLine("How many points is this goal worth?");
        Console.Write(">");
        int point = int.Parse(Console.ReadLine());
        Eternal newEternal = new Eternal(name,descrip,point);
        return newEternal;
    }
    private OneTime AddOneTime()
    {
        Console.WriteLine("What is the name of your goal?");
        Console.Write(">");
        string name = Console.ReadLine();
        Console.WriteLine("What is the description of your goal?");
        Console.Write(">");
        string descrip = Console.ReadLine();
        Console.WriteLine("How many points is this goal worth?");
        Console.Write(">");
        int point = int.Parse(Console.ReadLine());
        OneTime newOneTime = new OneTime(name,descrip,point);
        return newOneTime;
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
        Console.WriteLine("Press Enter to return to the menu");
        Console.ReadLine();
    }
    public void LoadFile()
    {
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
        _goalList = goals;
        Console.WriteLine("File successfully loaded!");
        Thread.Sleep(1000);
        return;
    }
    public void DisplayCurrentLevel()
    {
        int level = (GetTotalPoints() / 1500) + 1;
        Console.WriteLine($"Level {level}");
        Console.WriteLine($"{GetTotalPoints()}/{(level + 1) * 1500}");
        Console.WriteLine($"{(level+1)*1500 - GetTotalPoints()} points til next level up!");
        return;
    }
}