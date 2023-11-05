public class Reflecting : Activity
{
    private string[] _initialPrompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you did what was right even though it was hard.",
        "Think of a time when you did the right thing when no one was watching."
    };
    private string[] _questionPrompts = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you weren't as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experiene in mind in the future?"
    };

    public Reflecting()
    {
        _name = "Reflecting Activity";
        _duration = 30;
        _summary = "This activity will help you reflect on times in your life when you have shown strength and resilience. \nThis will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    private string GetRandPrompt()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, 6);

        return _initialPrompts[number];
    }
    private string[] RandomizePromptQuestion()
    {
        //I had to look this up online
        Random rand = new Random();
        string[] qPrompts = _questionPrompts;
        for (int i = 0; i < 8; i++)
        {
            int j = rand.Next(i,9);
            string temp = qPrompts[i];
            qPrompts[i] = qPrompts[j];
            qPrompts[j] = temp;
        }
        return qPrompts;
    }
    public void RunReflectingActivity()
    {
        base.DisplayStart();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" ---{GetRandPrompt()}--- \n");
        Console.Write("When you have something in mind, press enter.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions as they relate to your experience.");
        Console.Write("Begin in...");
        CountDown(5);
        Console.Clear();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);
        DateTime current = DateTime.Now;
        string[] questions = RandomizePromptQuestion();
        int pause = 5;
        int i = 0;
        if (_duration > 45)
            {
                pause = (_duration / 9) + 1;
            }
        while (current < end)
        {

            Console.Write(questions[i]);
            base.Spinner(pause);
            Console.WriteLine("");
            i ++;
            current = DateTime.Now;
        }
        base.DisplayEnd();
    }
}