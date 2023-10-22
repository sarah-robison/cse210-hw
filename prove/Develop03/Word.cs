public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string w)
    {
        _word = w;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public void Show()
    {
        _hidden = false;
    }

    public string GetText()
    {
        if (IsHidden() == true)
        {
            string hid = "";
            foreach (char c in _word)
            {
                hid = hid + "_";
            }
            return hid;
        }
        else
        {
            return _word;
        }
    }

    public bool IsHidden()
    {
        return _hidden;
    }

}