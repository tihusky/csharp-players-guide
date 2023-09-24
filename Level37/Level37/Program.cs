Test3();

void Test1()
{
    // Showing how to subscribe to events and that listeners exist as long as they're subscribed to an event
    var ship = new Ship();
    var effectManager = new ParticleEffectManager(ship);
    var rng = new Random();

    while (!ship.IsDestroyed)
        ship.TakeDamage(rng.Next(3, 12));

    effectManager = null; // No other references to the ParticleEffectManager instance

    ship.TakeDamage(100);
}

void Test2()
{
    // Showing one possible solution to preventing event leaks
    var ship = new Ship();
    var effectManager = new ParticleEffectManager(ship);

    // ParticleEffectManager still exists at this point and the event handler will be run
    ship.TakeDamage(50);

    // Get rid of the ParticleEffectManager; no listeners are attached to the HasExploded event anymore
    effectManager.Cleanup();
    effectManager = null;

    ship.TakeDamage(50);
}

void Test3()
{
    // Testing the EventHandler delegate type and passing in the sender and arguments to the listener
    var bomb = new Bomb(new Point(100, 250));
    var balloon = new Balloon(new Point(275, 425));
    var effectManager = new SoundEffectManager(bomb, balloon);

    bomb.BlowUp();
    balloon.BlowUp();
}

/***** Type Definitions *****/

public record struct Point(float X, float Y);

public class Ship
{
    private int _health = 42;
    private Point _location = new(24.7f, -193.4f);

    public event Action<Point>? HasExploded;

    public bool IsDestroyed => _health <= 0;

    public void TakeDamage(int amount)
    {
        _health -= amount;

        Console.WriteLine($"Ship took {amount} points of damage (Health: {_health})");

        if (IsDestroyed)
            HasExploded?.Invoke(_location);
    }
}

public class BlowUpEventArgs : EventArgs
{
    public Point Location { get; }

    public BlowUpEventArgs(Point location)
    {
        Location = location;
    }
}

public class Bomb
{
    public Point Location { get; }

    // i.e. void DoStuff(object sender, BlowUpEventArgs args)
    public event EventHandler<BlowUpEventArgs>? IsBlownUp;

    public Bomb(Point location)
    {
        Location = location;
    }

    public void BlowUp()
    {
        IsBlownUp?.Invoke(this, new BlowUpEventArgs(Location));
    }
}

public class Balloon
{
    public Point Location { get; }

    public event EventHandler<BlowUpEventArgs>? IsBlownUp;

    public Balloon(Point location)
    {
        Location = location;
    }

    public void BlowUp()
    {
        IsBlownUp?.Invoke(this, new BlowUpEventArgs(Location));
    }
}

public class ParticleEffectManager
{
    private Ship _ship;

    public ParticleEffectManager(Ship ship)
    {
        _ship = ship;
        _ship.HasExploded += OnShipExploded;
    }

    public void Cleanup()
    {
        _ship.HasExploded -= OnShipExploded;
    }

    private void OnShipExploded(Point location)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Create explosion effect at ({location.X}, {location.Y})");
        Console.ResetColor();
    }
}

public class SoundEffectManager
{
    public SoundEffectManager(Bomb bomb, Balloon balloon)
    {
        bomb.IsBlownUp += OnBlowUp;
        balloon.IsBlownUp += OnBlowUp;
    }

    public void OnBlowUp(object? sender, BlowUpEventArgs args)
    {
        Console.Write($"Sound Effect at ({args.Location.X}, {args.Location.Y}): ");

        if (sender is Bomb)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("KABOOOOOOM!!!!!");
            Console.ResetColor();
        }

        if (sender is Balloon)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("CHRRRRRRPT!!!!!");
            Console.ResetColor();
        }
    }
}