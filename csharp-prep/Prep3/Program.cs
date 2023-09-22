using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        
        Console.Write("What is your guess? ");
        string guess = Console.ReadLine();
        int guess_number = int.Parse(guess);

        while (guess_number != number)
        {

        if (guess_number > number)
            Console.WriteLine("Lower");
        
        else if (guess_number < number)
            Console.WriteLine("Higher");
        
        Console.Write("What is you new guess? ");
        guess = Console.ReadLine();
        guess_number = int.Parse(guess);

        }

        Console.WriteLine("You guessed correct!");
    }
}