namespace FountainOfObjects.MapTools;

internal class Entrance : GameObject
{
    public Entrance(Position position) : base(position) {}

    public override ColoredMessage Description =>
        new(
            ConsoleColor.Yellow,
            "You see light in this room coming from outside the cavern. This is the entrance."
        );
}