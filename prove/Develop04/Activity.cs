public class Activity{
    protected string _name;
    protected int _duration;
    protected string _summary;

    protected void DisplayStart()
    {
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine(_summary);
    }
    protected void DisplayEnd()
    {
        Console.WriteLine($"You have completed the {_name}.");
    }
    protected void Spinner()
    {
        //make the spinner
    }
    protected void CountDown()
    {
        //make the count down
    }
}