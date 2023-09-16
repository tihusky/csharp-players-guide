namespace FountainOfObjects.MapTools.Obstacles.Monsters;

internal class Maelstrom : Monster
{
    public Maelstrom(Position position) : base(position) {}

    public override ColoredMessage Description =>
        new(ConsoleColor.DarkMagenta, "You hear the growling and groaning of a nearby maelstrom.");

    public override void ApplyEffects(Map map, Player player)
    {
        // Player is moved one step north, two steps east if possible.
        player.Position = map.Clamp(new Position(player.Position.Row - 1, player.Position.Column + 2));

        Console.Clear();
        Helpers.WriteColoredMessage(
            new ColoredMessage(ConsoleColor.DarkMagenta, $"A maelstrom pushed you to position {player.Position}!")
        );
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();

        map.GetObstacleAt(player.Position)?.ApplyEffects(map, player);

        // The maelstrom tries to move one step south, two steps west.
        Position newPosition = map.Clamp(new Position(Position.Row + 1, Position.Column - 2));

        if (map.IsEmpty(newPosition))
        {
            Position = newPosition;
        }
        else
        {
            // If the move is not possible, it tries to only move two steps west.
            newPosition = map.Clamp(new Position(Position.Row, Position.Column - 2));

            if (map.IsEmpty(newPosition))
            {
                Position = newPosition;
            }
        }
    }
}
