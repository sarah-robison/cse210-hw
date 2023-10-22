using System;
//To go above and beyond, I set up code to let the user input the scripture they want to memorize.
//Unfortunately to get it to work I had to violate encapsulation. 

class Program
{
    static void Main(string[] args)
    {
        Reference myRef = new Reference();
        myRef = myRef.SetRef();
        Console.WriteLine("Enter scripture text:");
        Console.Write(">");
        string text = Console.ReadLine();
        Scripture newScrip = new Scripture(myRef,text);

        Console.WriteLine("Press ENTER to continue or type quit to finish.");

        string cont = Console.ReadLine();

        while (cont != "quit")
        {
            if (newScrip.IsTotallyHidden() != true)
            {
                Console.Clear();
                newScrip.HideWords();
                newScrip.HideWords();
                newScrip.GetRenderedText();
            }
            else
            {
                break;
            }
            cont = Console.ReadLine();
        }
        
        Console.WriteLine("Goodbye!");
    }
}