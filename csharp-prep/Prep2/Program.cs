using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);

        string letter;

        if (number >= 90)
        {
            //Console.WriteLine("You have an A in the class.");
            letter = "A";
        }

        else if (number >= 80)
        {
            //Console.WriteLine("You have a B in the class.");
            letter = "B";
        }

        else if (number >= 70)
        {
            //Console.WriteLine("You have a C in the class.");
            letter = "C";
        }

        else if (number >= 60)
        {
            //Console.WriteLine("You have a D in the class.");
            letter = "D";
        }

        else
        {
            //Console.WriteLine("You have an F in the class.");
            letter = "F";
        }

        Console.WriteLine($"You got the letter grade {letter}.");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }

        else
        {
            Console.WriteLine("You do not have a passing grade. Keep working hard for next time!");
        }
    
    }
}