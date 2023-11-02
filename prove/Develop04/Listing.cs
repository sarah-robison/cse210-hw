public class Listing : Activity
{
    private List<string> _listPrompts;
    private List<string> _inputList;

    public Listing(int duration)
    {
        _name = "Listing Activity";
        _duration = duration;
        _summary = "In this activity, you will...";
        //do i make my empty list here?
    }

    private string GetRandomPrompt()
    {
        //get a random list prompt
        //return prompt
    }
    public void RunListingActivity()
    {
        //display start
        //display prompt
        //accept input
        //count input
        //display end
    }
    private int GetListLength()
    {
        //return lenght of input list
    }
}