using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int selection = 0;

        
        Journal myJournal = new Journal();

        while (selection != 5)
        {

        Console.WriteLine("Welcome to your journal!");
        Console.WriteLine("Select an option by inputing the number.");
        Console.WriteLine("1. Write New Entry");
        Console.WriteLine("2. Display Journal");
        Console.WriteLine("3. Load File");
        Console.WriteLine("4. Save Progress");
        Console.WriteLine("5. Quit Program");

        selection = int.Parse(Console.ReadLine());

        if (selection == 1)
        {
            myJournal._entries.Add(myJournal.WriteEntry());
        }

        else if (selection == 2)
        {
            myJournal.DisplayJournal();  
        }

        else if (selection == 3)
        {
            myJournal._entries = myJournal.LoadFromFile();
        }

        else if (selection == 4)
        {
            myJournal.WriteToFile();
        }

        else if (selection == 5)
        {
            Console.WriteLine("Goodbye!");
        }

        else
        {
            Console.WriteLine("Please input the number for your desired option.");
        }
        }

    }
}