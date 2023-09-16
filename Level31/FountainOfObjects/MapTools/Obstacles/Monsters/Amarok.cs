namespace FountainOfObjects.MapTools.Obstacles.Monsters;

internal class Amarok : Monster
{
    public Amarok(Position position) : base(position) {}

    public override void ApplyEffects(Map map, Player player)
    {
        player.Die("You were mauled to death by an amarok.");
    }
    
    public override ColoredMessage Description =>
        new(ConsoleColor.DarkMagenta, "You can smell the rotten stench of an amarok in a nearby room.");
}