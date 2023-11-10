using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> mylist = new List<Shape>();
        mylist.Add(new Square("blue",3));
        mylist.Add(new Rectangle("yellow",4,5));
        mylist.Add(new Circle("red",2));

        foreach (Shape i in mylist)
        {
            Console.WriteLine(i.GetColor());
            Console.WriteLine(i.GetArea());
        }

    }
}