using System;
//To go above and beyond, I made sure that none of the question prompts in the reflecting activity
//repeat, and if the user picks a long duration, it scales the time between each question prompt accordingly.
class Program
{
    static void Main(string[] args)
    {
        
        int choice = 1;
        while (choice != 4)
        {
            Console.WriteLine("Welcome to the Mindfulness Application!");
            Console.WriteLine("   1. Breathing Activity");
            Console.WriteLine("   2. Reflecting Activity");
            Console.WriteLine("   3. Listing Activity");
            Console.WriteLine("   4. Quit");
            Console.Write("Select a number to continue:");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Breathing b = new Breathing();
                b.RunBreathingActivity();
            }
            else if (choice == 2)
            {
                Reflecting r = new Reflecting();
                r.RunReflectingActivity();
            }
            else if (choice == 3)
            {
                Listing l = new Listing();
                l.RunListingActivity();
            }
            else if (choice == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please select a valid number to continue.");
            }
        }

        Console.WriteLine("Goodbye!");


    }
}