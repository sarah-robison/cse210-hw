public class Breathing : Activity
{
    public Breathing()
    {
        _name = "Breathing Activity";
        _duration = 30;
        _summary = "This activity will help you relax by walking your through breathing in and out slowly. \nClear your mind and focus on your breathing.";
    }

    public void RunBreathingActivity()
    {
        base.DisplayStart();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);
        DateTime current = DateTime.Now;
        while (current < end)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Breath in...");
            base.CountDown(5);
            Console.Write("\nBreath out...");
            base.CountDown(5);
            Console.WriteLine("");
            current = DateTime.Now;
        }
        Console.WriteLine("");
        Console.WriteLine("");
        base.DisplayEnd();
    }
}
