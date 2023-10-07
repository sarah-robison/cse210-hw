public class PromptGenerator
{
    public string[] _prompts = {
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I see the hand of the Lord in my life today?",
        "What was the best part of my day?",
        "Who was the most interesting person I interacted with today?",
        "What is one thing I learned today?",
        "What is something I did that I'm proud of today?",
        "What are 5 things I'm grateful for today?",
        "What is one song that describes today and why?",
        "How did I represent Jesus Christ today?",
        "What promptings did I get today?"
    };
    
    public string Generate()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, 10);

        return _prompts[number];
    }
}