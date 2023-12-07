using System;
using System.Runtime.InteropServices;

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
        if (choice == 1)
        {//testing
            Cannonball test = new Cannonball(0.1,0,100,0,0.02,new Wind(0,0),0.25);
            test.SetTrajectory();
            Console.WriteLine(test.GetXFinal());
            Console.WriteLine(test.GetLandTime());
        }
        if (choice == 2)
        {
            Parachuter testP = new Parachuter(73,39000,1500);
            testP.SetTrajectory();
            Console.WriteLine(testP.GetLandTime());
        }
        if (choice == 3)
        {
            Rocket testR = new Rocket(180,90,0.001,0.2,130,2.5,1500);
            testR.SetTrajectory();
            Console.WriteLine(testR.GetLandTime());
        }
        if (choice == 4)
        {
            AimingAid RunAimAid = new AimingAid();
            Console.WriteLine($"The launch angle you need is {RunAimAid.GetLaunchAngle()} degrees.");
            Console.WriteLine($"You also need to aim {RunAimAid.GetWindAdjustAngle()} degrees to the left of the target.");
        }
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