using System.Diagnostics;

public class Entry
{
    public string _prompt;
    public string _date;
    public string _entry;

    public void DisplayEntry()
    {
        Console.WriteLine(_date);
        Console.WriteLine();
        Console.WriteLine(_prompt);
        Console.WriteLine();
        Console.WriteLine(_entry);
        Console.WriteLine();
    }
}