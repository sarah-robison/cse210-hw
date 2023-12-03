using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Launch Pad!");
        Console.WriteLine("Here you can simulate projectile motion, the descent of a parachuter, or rocket trajectory.");
        Console.WriteLine("Or if you'd like, you can calculate the necessary angle to launch a projectile to hit a known target with the Aiming Aid.");
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Projectile Simulator");
        Console.WriteLine("2. Parachuter Descent");
        Console.WriteLine("3. Rocket Trajectory");
        Console.WriteLine("4. Aiming Aid");
        Console.WriteLine("5. Quit Program");
        Console.Write("Select a number to continue: ");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 5)
        {
            Console.WriteLine("Goodbye!");
        }
        else
        {
            Console.WriteLine("This feature has not been added yet.");
        }
    }
}