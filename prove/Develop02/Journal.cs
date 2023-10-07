using System.Xml;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _fileName;

    public void DisplayJournal()
    {
        foreach (Entry en in _entries)
        {
            en.DisplayEntry();
        }
    }

    public Entry WriteEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Entry entry1 = new Entry();
        entry1._date = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        entry1._prompt = promptGenerator.Generate();
        Console.WriteLine(entry1._prompt);
        Console.Write(">");
        entry1._entry = Console.ReadLine();
        return entry1;
    }

    public void WriteToFile()
    {
        Console.WriteLine("Please input file name with .txt extension: ");
        Console.Write(">");
        _fileName = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(_fileName))
            {
                foreach (Entry en in _entries)
                {
                outputFile.WriteLine($"{en._date}~{en._prompt}~{en._entry}");
                }
            }
        Console.WriteLine($"Saved successfully as {_fileName}");
    }

    public List<Entry> LoadFromFile()
    {
        Console.WriteLine("File name with extension: ");
        Console.Write(">");
        string loadfile = Console.ReadLine();
        string[] entries = System.IO.File.ReadAllLines(loadfile);
        List<Entry> journal_entries = new List<Entry>();

        foreach (string ent in entries)
        {
            string[] parts = ent.Split("~");

            Entry entry1 = new Entry();
            entry1._date = parts[0];
            entry1._prompt = parts[1];
            entry1._entry = parts[2];
            journal_entries.Add(entry1);
        }
        return journal_entries;
    }
}