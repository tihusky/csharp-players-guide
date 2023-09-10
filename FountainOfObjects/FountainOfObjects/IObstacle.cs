namespace FountainOfObjects;

internal interface IObstacle : ISensable
{
    void ApplyEffects(Player player);
}