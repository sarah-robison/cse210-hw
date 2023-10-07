using System.Diagnostics;

public class Entry
{
    public string _prompt;
    public string _date;
    public string _entry;

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine(_entry);
        Console.WriteLine();
    }
}