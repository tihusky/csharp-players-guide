namespace FountainOfObjects;

internal class Amarok : IObstacle
{
    public Position Position { get; }

    public Amarok(Position position)
    {
        Position = position;
    }

    public bool CanBeSensed(Position playerPosition)
    {
        // Amaroks can be sensed in all 8 directions, so as long as the difference
        // in both rows and columns is below 2 the player can sense it.
        int rowDelta = Math.Abs(Position.Row - playerPosition.Row);
        int columnDelta = Math.Abs(Position.Column - playerPosition.Column);

        return (rowDelta <= 1) && (columnDelta <= 1);
    }

    public ColoredMessage GetDescription() =>
        new(ConsoleColor.DarkMagenta, "You can smell the rotten stench of an amarok in a nearby room.");

    public void ApplyEffects(Player player)
    {
        player.IsAlive = false;
    }
}