namespace FountainOfObjects.MapTools.Obstacles;

internal class Pit : Obstacle
{
    public Pit(Position position) : base(position) {}

    public override void ApplyEffects(Map map, Player player)
    {
        player.Die("You fell into a deep pit and broke your neck.");
    }

    public override ColoredMessage Description =>
        new(ConsoleColor.DarkMagenta, "You feel a draft. There is a pit in a nearby room.");
}