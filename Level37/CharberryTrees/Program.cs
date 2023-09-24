var trees = new CharberryTree[] { new CharberryTree(), new CharberryTree() }; 
var notifier = new Notifier(trees);
var harvester = new Harvester(trees);

while (true)
{
    foreach (CharberryTree tree in trees)
        tree.MaybeGrow();
}

/***** Type Definitions *****/

public class CharberryTree
{
    private static int NextId = 1;

    private readonly Random _rng = new();

    public int ID { get; }
    public bool Ripe { get; set; } = false;

    public event EventHandler? Ripened;

    public CharberryTree()
    {
        ID = NextId++;
    }

    public void MaybeGrow()
    {
        if (_rng.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke(this, EventArgs.Empty);
        }
    }
}

public class Notifier
{
    public Notifier(params CharberryTree[] trees)
    {
        foreach (CharberryTree tree in trees)
            tree.Ripened += OnRipened;
    }

    private void OnRipened(object? sender, EventArgs e)
    {
        if (sender is CharberryTree tree)
        {
            Console.Write($"[Tree #{tree.ID}] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A charberry fruit has ripened!");
            Console.ResetColor();
        }
    }
}

public class Harvester
{
    public Harvester(params CharberryTree[] trees)
    {
        foreach (CharberryTree tree in trees)
            tree.Ripened += OnRipened;
    }

    public void OnRipened(object? sender, EventArgs e)
    {
        if (sender is CharberryTree tree)
        {
            tree.Ripe = false;

            Console.Write($"[Tree #{tree.ID}] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A charberry fruit was harvested!");
            Console.ResetColor();
        }
    }
}