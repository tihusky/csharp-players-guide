namespace FountainOfObjects;

internal class Pit : Obstacle
{
    public Pit(Position position) : base(position) {}

    public override void ApplyEffects(Player player)
    {
        player.IsAlive = false;
    }

    public override ColoredMessage Description =>
        new(ConsoleColor.DarkMagenta, "You feel a draft. There is a pit in a nearby room.");
}