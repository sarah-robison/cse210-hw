using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter number: ");
        string num = Console.ReadLine();
        int number = int.Parse(num);

        List<int> numbers = new List<int>();
        numbers.Add(number);

        while (number != 0)
        {
            Console.Write("Enter number: ");
            string newnum = Console.ReadLine();
            number = int.Parse(newnum);
            if (number != 0)
                numbers.Add(number);
        }
        int length = numbers.Count;

        int sum = 0;

        foreach (int i in numbers)
        {
            sum += i;
        }

        Console.WriteLine($"The sum is: {sum}");

        float avg = (float)sum / length;
        Console.WriteLine($"The average is: {avg}");
        numbers.Sort();
        Console.WriteLine($"The largest number is: {numbers[length-1]}");

    }
}