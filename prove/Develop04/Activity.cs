public class Activity{
    protected string _name;
    protected int _duration;
    protected string _summary;

    protected void DisplayStart()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine("");
        Console.WriteLine(_summary);
        Console.WriteLine("");
        Console.WriteLine("For how many seconds would you like to do this activity?");
        Console.Write(">");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("We will begin soon.");
        Spinner(3);
    }
    protected void DisplayEnd()
    {
        Console.WriteLine("\nWell done!");
        Spinner(3);
        Console.WriteLine($"\nYou have completed the {_name}. Your activity took {_duration} seconds.");
        Spinner(5);
        Console.Clear();
    }
    protected void Spinner(int t)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(t);
        DateTime currentTime = DateTime.Now;

        while (currentTime < futureTime)
        {
            Console.Write('<');
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write('=');
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write('>');
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write('x');
            Thread.Sleep(250);
            Console.Write("\b \b");
            currentTime = DateTime.Now;
        }
    }
    protected void CountDown(int time)
    {
        while (time > -1)
        {
            Console.Write($"{time}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            time --;
        }
    }
}