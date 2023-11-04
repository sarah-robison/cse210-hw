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
        Thread.Sleep(1000); //spinner here?
        Console.WriteLine("We will begin soon.");
        Thread.Sleep(3000); //spinner here?
    }
    protected void DisplayEnd()
    {
        Console.WriteLine("Well done!");
        Thread.Sleep(2000); //spinner here?
        Console.WriteLine($"You have completed the {_name}. Your activity took {_duration} seconds.");
        Thread.Sleep(5000); //spinner here?
    }
    protected void Spinner(int t)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(t);
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