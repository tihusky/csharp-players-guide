/* The base for elements that have an effect on the player when encountered. */

namespace FountainOfObjects;

internal abstract class Obstacle : GameObject
{
    protected Obstacle(Position position) : base(position) {}
    
    public override bool IsSensable(Position playerPosition)
    {
        // Obstacles can be sensed in all 8 directions.
        int rowDelta = Math.Abs(Position.Row - playerPosition.Row);
        int columnDelta = Math.Abs(Position.Column - playerPosition.Column);

        return rowDelta <= 1 && columnDelta <= 1;
    }
    
    public abstract void ApplyEffects(Player player);
}