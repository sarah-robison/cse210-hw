public class PromptGenerator
{
    public string[] _prompts = {
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I see the hand of the Lord in my life today?",
        "What was the best part of my day?",
        "Who was the most interesting person I interacted with today?"
    };
    
    public string Generate()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, 4);

        return _prompts[number];
    }
}