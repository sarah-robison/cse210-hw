using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment test = new Assignment("Sarah Hansen", "Test");
        WritingAssignment essay = new WritingAssignment("Sarah Hansen","Ethics","To Lie Or Not To Lie");
        MathAssignment calc = new MathAssignment("Sarah Hansen","Divergence","13.4","13-20");
        
        Console.WriteLine(test.GetSummary());
        Console.WriteLine(calc.GetSummary());
        Console.WriteLine(calc.GetHomeworkList());
        Console.WriteLine(essay.GetSummary());
        Console.WriteLine(essay.GetWritingInformation());
        
    }
}