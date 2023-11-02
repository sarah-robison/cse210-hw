public class Reflecting : Activity
{
    private List<string> _initialPrompts;
    private List<string> _questionPrompts;

    public Reflecting(int d)
    {
        _name = "Reflecting Activity";
        _duration = d;
        _summary = "In this activity you will...";
        //do i put the lists here or can i initialize them above?
    }

    private string GetRandPrompt()
    {
        //get a random initial prompt
        //return the prompt
    }
    private string GetPromptQuestion()
    {
        //get a random follow up question
        //return the question
    }
    public void RunReflectingActivity()
    {
        //display start
        //display prompt
        //display follow up question
        //display end
    }
}