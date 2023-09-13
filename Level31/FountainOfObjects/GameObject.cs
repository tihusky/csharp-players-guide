/* The base for anything special on the map. */

namespace FountainOfObjects;

internal abstract class GameObject
{
    public Position Position { get; protected set; }

    protected GameObject(Position position)
    {
        Position = position;
    }
    
    public virtual bool IsSensable(Position playerPosition) =>
        Position == playerPosition;

    public abstract ColoredMessage Description { get; }
}