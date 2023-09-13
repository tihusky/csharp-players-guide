namespace FountainOfObjects;

internal class Amarok : Monster
{
    public Amarok(Position position) : base(position) {}

    public override void ApplyEffects(Player player)
    {
        player.IsAlive = false;
    }
    
    public override ColoredMessage Description =>
        new(ConsoleColor.DarkMagenta, "You can smell the rotten stench of an amarok in a nearby room.");
}