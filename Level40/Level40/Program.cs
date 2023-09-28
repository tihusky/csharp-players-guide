using System.ComponentModel.DataAnnotations;

int ScoreFor(Monster monster)
{
    return monster switch
    {
        Snake s when s.Length < 1.0                                    => 1,                       // Type pattern with additional case guard
        Snake { Length: >= 4.0 } s                                     => (int)(s.Length * 2.0),   // Property pattern which matches longer snakes
        Snake                                                          => 7,                       // Matches all snakes where 1.0 <= Length < 4.0
        Dragon { Type: DragonType.Gold, LifePhase: LifePhase.Ancient } => 150,                     // Property pattern with multiple properties
        Dragon { LifePhase: LifePhase.Ancient }                        => 100,                     // Property pattern without variable 
        Dragon                                                         => 50,                      // Matches all non-ancient dragons
        _                                                              => 5                        // Discard pattern 
    };
}

Skeleton skeleton = new();
Snake snake = new(0.75);
Dragon dragon = new(DragonType.Gold, LifePhase.Ancient);

Console.WriteLine($"This monster is worth {ScoreFor(dragon)} points.");

/***** Type Definitions *****/

public abstract record Monster;
public record Skeleton : Monster;
public record Snake(double Length) : Monster;
public record Dragon(DragonType Type, LifePhase LifePhase) : Monster;
public record Orc(Sword sword) : Monster;

public record Sword(SwordType Type);

public enum DragonType { Black, Green, Red, Blue, Gold }
public enum LifePhase { Wyrmling, Young, Adult, Ancient }
public enum SwordType { WoodenStick, ArmingSword, Longsword }