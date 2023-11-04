public class Activity{
    protected string _name;
    protected int _duration;
    protected string _summary;

    protected void DisplayStart()
    {
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine("How long would you like to do this activity?");
        Console.Write(">");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine(_summary);
    }
    protected void DisplayEnd()
    {
        Console.WriteLine($"You have completed the {_name}.");
    }
    protected void Spinner()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(5);
        DateTime currentTime = DateTime.Now;

        while (currentTime < futureTime)
        {
            Console.Write('<');
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write('=');
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write('>');
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write('x');
            Thread.Sleep(500);
            Console.Write("\b \b");
            currentTime = DateTime.Now;
        }
    }
    protected void CountDown(int time)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(time);
        DateTime currentTime = DateTime.Now;

        while (currentTime < futureTime)
        {
            Console.Write($"{time}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            time = time - 1;
            currentTime = DateTime.Now;
        }
    }
}