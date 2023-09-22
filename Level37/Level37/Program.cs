Ship ship = new();
SoundEffectManager sem = new(ship);
Random rng = new();

while (!ship.IsDestroyed)
    ship.TakeDamage(rng.Next(3, 12));

/***** Type Definitions *****/

public class Ship
{
    private int _health = 42;

    public event Action? HasExploded;

    public bool IsDestroyed => _health <= 0;

    public void TakeDamage(int amount)
    {
        _health -= amount;

        Console.WriteLine($"Ship took {amount} points of damage (Health: {_health})");

        if (IsDestroyed)
            HasExploded?.Invoke();
    }
}

public class SoundEffectManager
{
    public SoundEffectManager(Ship ship)
    {
        ship.HasExploded += OnShipExploded;
    }

    public void OnShipExploded()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("KABOOOOOOOM!!!");
        Console.ResetColor();
    }
}