public class Breathing : Activity
{
    public Breathing()
    {
        _name = "Breathing Activity";
        _duration = 30;
        _summary = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void RunBreathingActivity()
    {
        base.DisplayStart();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);
        DateTime current = DateTime.Now;
        while (current > end)
        {
            Console.WriteLine("Breath in...");
            base.CountDown(8);
            Console.WriteLine("Breath out...");
            base.CountDown(8);
            current = DateTime.Now;
        }
        base.DisplayEnd();
    }
}
