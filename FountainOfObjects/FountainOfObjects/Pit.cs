namespace FountainOfObjects;

internal class Pit : IObstacle
{
    public Position Position { get; }

    public Pit(Position position)
    {
        Position = position;
    }

    public bool CanBeSensed(Position playerPosition)
    {
        // Pits can be sensed in all 8 directions, so as long as the difference
        // in both rows and columns is below 2 the player can sense it.
        int rowDelta = Math.Abs(Position.Row - playerPosition.Row);
        int columnDelta = Math.Abs(Position.Column - playerPosition.Column);

        return (rowDelta <= 1) && (columnDelta <= 1);
    }

    public ColoredMessage GetDescription() =>
        new(
            ConsoleColor.DarkMagenta,
            "You feel a draft. There is a pit in a nearby room."
        );

    public void ApplyEffects(Player player)
    {
        player.IsAlive = false;
    }
}