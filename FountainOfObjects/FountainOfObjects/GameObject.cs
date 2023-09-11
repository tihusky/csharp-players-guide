namespace FountainOfObjects;

internal abstract class GameObject
{
    public Position Position { get; }

    public GameObject(Position position)
    {
        Position = position;
    }
    
    public virtual bool IsSensable(Position playerPosition) =>
        Position == playerPosition;

    public abstract ColoredMessage Description { get; }
}