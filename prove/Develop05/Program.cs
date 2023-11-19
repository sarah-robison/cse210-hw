using System;

class Program
{
    static void Main(string[] args)
    {
        int selection = 0;
        
        Log myLog = new Log();

        while (selection != 5)
        {
            Console.WriteLine($"You have {myLog.GetTotalPoints()} points.\n");

            Console.WriteLine("Welcome to your goal tracker menu!");
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
                Console.WriteLine("Which kind of goal would you like to make?");
                Console.WriteLine("1. Checklist");
                Console.WriteLine("2. Eternal");
                Console.WriteLine("3. One Time");
                Console.Write(">");
                int pick = int.Parse(Console.ReadLine());
                //and if statement for if they put in an invalid input?
                Console.Clear();
                myLog.AddGoal(pick);
            }

            else if (selection == 2)
            {
                myLog.DisplayGoals();  
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
                Console.WriteLine("Which goal would you like to record an event for?");
                myLog.DisplayGoals();
                Console.Write(">");
                int goalNum = int.Parse(Console.ReadLine());
                myLog.GetGoalList()[goalNum].RecordEvent();
            }
            else if (selection == 6)
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