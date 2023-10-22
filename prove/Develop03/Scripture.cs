using System.Reflection.Metadata.Ecma335;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference r, string w)
    {
        _reference = r;
        string[] splt = w.Split(" ");
        List<Word> myList = new List<Word>();
        foreach (string wrd in splt)
        {
            Word newWord = new Word(wrd);
            myList.Add(newWord);
        }
        _words = myList;
    }

    public void HideWords()
    {
        //randomly select word and hide it
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, _words.Count());
        _words[number].Hide();
    }

    public void GetRenderedText()
    {
        Console.WriteLine(_reference.GetRef());
        foreach (Word w in _words)
        {
            Console.Write($"{w.GetText()} "); 
        }
        Console.WriteLine("");
        Console.WriteLine("Press ENTER to continue or quit to finish.");
        return;
    }

    public bool IsTotallyHidden()
    {
        foreach (Word wd in _words)
        {
            if (wd.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}