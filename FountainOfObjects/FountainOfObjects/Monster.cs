namespace FountainOfObjects;

internal abstract class Monster : Obstacle
{
    public bool IsAlive { get; set; } = true;

    protected Monster(Position position) : base(position) {}
    
    public override bool IsSensable(Position playerPosition)
    {
        if (IsAlive)
        {
            return base.IsSensable(playerPosition);
        }

        return false;
    }
}