using System;
//To go above and beyond I made improvements to user interface by clearing the console
//periodically and adding pauses for the user to read what is displayed.
//I also added a level tracker.

class Program
{
    static void Main(string[] args)
    {
        int selection = 0;
        
        Log myLog = new Log();

        while (selection != 6)
        {
            myLog.DisplayCurrentLevel();

            Console.WriteLine("\nWelcome to your goal tracker menu!");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Display Goals");
            Console.WriteLine("3. Load File");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit Program");
            Console.Write("Select an option by inputing the number: ");

            selection = int.Parse(Console.ReadLine());

            Console.Clear();

            if (selection == 1)
            {
                int pick = 0;
                while (pick != 1 && pick != 2 && pick != 3)
                {
                    Console.WriteLine("Which kind of goal would you like to make?");
                    Console.WriteLine("1. Checklist");
                    Console.WriteLine("2. Eternal");
                    Console.WriteLine("3. One Time");
                    Console.Write(">");
                    pick = int.Parse(Console.ReadLine());
                    if (pick != 1 && pick != 2 && pick != 3)
                    {
                        Console.WriteLine("Please pick a valid option.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        myLog.AddGoal(pick);
                    }
                }
            }

            else if (selection == 2)
            {
                myLog.DisplayGoals();
                Console.WriteLine("Press Enter to go back to the menu.");
                Console.ReadLine();  
            }

            else if (selection == 3)
            {
                myLog.LoadFile();
            }

            else if (selection == 4)
            {
                myLog.WriteToFile();
            }

            else if (selection == 5)
            {
                int goalNum = -1;
                while (goalNum < 0 || goalNum > myLog.GetGoalList().Count - 1)
                {
                    Console.WriteLine("Which goal would you like to record an event for?");
                    myLog.DisplayGoals();
                    Console.Write(">");
                    goalNum = int.Parse(Console.ReadLine()) - 1;
                    if (goalNum < 0 || goalNum > myLog.GetGoalList().Count - 1)
                    {
                        Console.WriteLine("Please input a valid value.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        myLog.GetGoalList()[goalNum].RecordEvent();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
            else if (selection == 6)
            {
                Console.WriteLine("Goodbye!");
            }

            else
            {
                Console.WriteLine("Please input the number for your desired option.");
                Thread.Sleep(1000);
            }
        }
    }
}