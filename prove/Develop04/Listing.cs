public class Listing : Activity
{
    private string[] _listPrompts = {
        "Who are people that you appreciate?",
        "What are personal strenghts of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are you grateful for today?"
    };
    private List<string> _inputList = new List<string>();

    public Listing()
    {
        _name = "Listing Activity";
        _duration = 30;
        _summary = "This activity will help you reflect on the good things in your life by having you list \nas many things as you can in a certain area.";
    }

    private string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, 6);

        return _listPrompts[number];
    }
    public void RunListingActivity()
    {
        base.DisplayStart();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"---{GetRandomPrompt()}---");
        Console.Write("Begin in...");
        base.CountDown(5);
        Console.WriteLine("\nStart listing:");
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);
        DateTime current = DateTime.Now;
        while (current < end)
        {
            Console.Write(">");
            _inputList.Add(Console.ReadLine());
            current = DateTime.Now;
        }
        Console.WriteLine($"You listed off {GetListLength()} different things!");
        base.DisplayEnd();
    }
    private int GetListLength()
    {
        return _inputList.Count;
    }
}