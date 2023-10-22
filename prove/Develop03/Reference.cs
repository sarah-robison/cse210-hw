public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference()
    {
        _book = "none";
        _chapter = 0;
        _verse = 0;
        _endVerse = 0;
    }

    public Reference(string b, int c, int v)
    {
        _book = b;
        _chapter = c;
        _verse = v;
        _endVerse = 0;
    }

    public Reference(string B, int C, int V, int EV)
    {
        _book = B;
        _chapter = C;
        _verse = V;
        _endVerse = EV;
    }

    public string GetRef()
    {
        string fullRef;
        if (_endVerse != 0)
            fullRef = _book + ' ' + _chapter.ToString() + ":" + _verse.ToString() + "-" + _endVerse.ToString();
        else
            fullRef = _book + ' ' + _chapter.ToString() + ":" + _verse.ToString(); 
        return fullRef;
    }

    public Reference SetRef()
    {
        Console.WriteLine("What is the book of scripture?");
        Console.Write(">");
        string book = Console.ReadLine();
        Console.WriteLine("What chapter?");
        Console.Write(">");
        int chap = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the starting verse?");
        Console.Write(">");
        int ver1 = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the ending verse (type 0 if no ending verse)?");
        Console.Write(">");
        int ver2 = int.Parse(Console.ReadLine());
        if (ver2 == 0)
        {
            Reference newRef = new Reference(book,chap,ver1);
            return newRef;
        }
        else
        {
            Reference newRef = new Reference(book,chap,ver1,ver2);
            return newRef;
        }
    }
}