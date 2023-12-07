using System;
using System.Runtime.InteropServices;
//Future improvement ideas: rework it to run using 4th order Runge Kutta instead of Euler's method, 
//allow for complete customization of projectiles, rockets, and parachuters,
//implement an x and y velocity for parachuters and a y velocity for rockets,
//allow for multistage rockets,
//refine the cases for rockets escaping the Earth's gravitational pull
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Launch Pad!");
        Console.WriteLine("Here you can simulate projectile motion, the descent of a parachuter, or rocket trajectory.");
        Console.WriteLine("Or if you'd like, you can calculate the necessary angle to launch a projectile to hit a known target with the Aiming Aid.");
        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Projectile Simulator");
            Console.WriteLine("2. Parachuter Descent");
            Console.WriteLine("3. Rocket Trajectory");
            Console.WriteLine("4. Aiming Aid");
            Console.WriteLine("5. Quit Program");
            Console.Write("Select a number to continue: ");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                int pick = 0;
                while (pick != 1 && pick != 2)
                {
                    Console.WriteLine("What type of projectile would you like to fire?");
                    Console.WriteLine("1. Cannonball");
                    Console.WriteLine("2. Arrow");
                    Console.Write(">");
                    pick = int.Parse(Console.ReadLine());

                    if (pick == 1)
                    {
                        Cannonball testCannonball = new Cannonball();
                        testCannonball.SetTrajectory();
                        Console.WriteLine(testCannonball.GetLandTime());
                    }
                    else if (pick == 2)
                    {
                        Arrow testArrow = new Arrow();
                        testArrow.SetTrajectory();
                        Console.WriteLine(testArrow.GetLandTime());
                    }
                    else
                    {
                    Console.WriteLine("Please input a valid value.");
                    }
                }
            }
            else if (choice == 2)
            {
                Parachuter testPara = new Parachuter();
                testPara.SetTrajectory();
                Console.WriteLine(testPara.GetLandTime());
            }
            else if (choice == 3)
            {
                Rocket testRocket = new Rocket();
                testRocket.SetTrajectory();
                Console.WriteLine(testRocket.GetLandTime());
            }
            else if (choice == 4)
            {
                AimingAid RunAimAid = new AimingAid();
                Console.WriteLine($"The launch angle you need is {RunAimAid.GetLaunchAngle()} degrees above the horizontal.");
                Console.WriteLine($"You also need to aim {RunAimAid.GetWindAdjustAngle()} degrees to the left of the target.");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please select a valid option.");
            }
        }
    }
}