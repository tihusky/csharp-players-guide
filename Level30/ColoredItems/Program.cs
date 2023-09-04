var sword = new ColoredItem<Sword>(ConsoleColor.Blue, new Sword());
var bow = new ColoredItem<Bow>(ConsoleColor.Red, new Bow());
var axe = new ColoredItem<Axe>(ConsoleColor.Green, new Axe());

sword.Display();
bow.Display();
axe.Display();

/***** Type Definitions *****/

// Not required by the challenge, but I'm doing this to try out generic type constraints!
public abstract class Item {}

public class Sword : Item {}
public class Bow : Item {}
public class Axe : Item {}

public class ColoredItem<T> where T : Item
{
    private ConsoleColor _color;
    private T _item;
    
    public ColoredItem(ConsoleColor color, T item)
    {
        _color = color;
        _item = item;
    }

    public void Display()
    {
        Console.ForegroundColor = _color;
        Console.WriteLine(_item.ToString());
        Console.ResetColor();
    }
}