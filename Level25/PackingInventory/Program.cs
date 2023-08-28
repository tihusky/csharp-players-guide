void WriteLineColored(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

int GetIntBetween(int min, int max, string prompt)
{
    while (true)
    {
        Console.Write($"{prompt} ");

        bool isParseable = int.TryParse(Console.ReadLine(), out int number);

        if (isParseable && number >= min && number <= max)
            return number;

        WriteLineColored("Invalid input.", ConsoleColor.Red);
    }
}

Pack pack = new Pack(3, 25.0f, 25.0f);

while (true)
{
    Console.Clear();
    Console.WriteLine($"{pack.Stats}\n");
    Console.WriteLine("""
                      What kind of item do you want to add?
                      1) Arrow
                      2) Bow
                      3) Rope
                      4) Water
                      5) Food Ration
                      6) Sword
                      """);

    int userSelection = GetIntBetween(1, 6, ">");

    InventoryItem item = userSelection switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new FoodRation(),
        6 => new Sword()
    };

    if (pack.Add(item))
    {
        WriteLineColored("The item was added successfully.", ConsoleColor.Green);
    }
    else
    {
        WriteLineColored("The item could not be added.", ConsoleColor.Red);
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

/***** Type Definitions *****/

public class Pack
{
    private readonly InventoryItem[] _items;

    private readonly int _itemLimit;
    private int _itemCount = 0;
    private readonly float _weightLimit;
    private float _currentWeight = 0.0f;
    private readonly float _volumeLimit;
    private float _currentVolume = 0.0f;

    public string CurrentItemCount => $"{_itemCount}/{_itemLimit}";
    public string CurrentWeight => $"{_currentWeight:0.00}/{_weightLimit:0.00}";
    public string CurrentVolume => $"{_currentVolume:0.00}/{_volumeLimit:0.00}";
    public string Stats => $"Items: {CurrentItemCount} Weight: {CurrentWeight} Volume: {CurrentVolume}";

    public Pack(int itemLimit, float weightLimit, float volumeLimit)
    {
        _items = new InventoryItem[itemLimit];

        _itemLimit = itemLimit;
        _weightLimit = weightLimit;
        _volumeLimit = volumeLimit;
    }

    public bool Add(InventoryItem item)
    {
        if ((_itemCount + 1 > _itemLimit) ||
            (_currentWeight + item.Weight > _weightLimit) ||
            (_currentVolume + item.Volume > _volumeLimit)
           )
            return false;

        _items[_itemCount] = item;
        _currentWeight += item.Weight;
        _currentVolume += item.Volume;
        
        _itemCount++;

        return true;
    }
}

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    protected InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f)
    {
    }
}

public class Bow : InventoryItem
{
    public Bow() : base(1.0f, 4.0f)
    {
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(1.0f, 1.5f)
    {
    }
}

public class Water : InventoryItem
{
    public Water() : base(2.0f, 3.0f)
    {
    }
}

public class FoodRation : InventoryItem
{
    public FoodRation() : base(1.0f, 0.5f)
    {
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(5.0f, 3.0f)
    {
    }
}