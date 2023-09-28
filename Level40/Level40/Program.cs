﻿void Test1()
{
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
            Orc { Sword: { Type: SwordType.WoodenStick } }                 => 2,                       // Nested property pattern
            Orc { Sword: { Type: SwordType.ArmingSword } }                 => 8,                       // Nested property pattern
            Orc { Sword.Type: SwordType.Longsword }                        => 15,                      // Short form of a nested property pattern
            _                                                              => 5                        // Discard pattern 
        };
    }

    Skeleton skeleton = new();
    Snake snake = new(0.75);
    Dragon dragon = new(DragonType.Gold, LifePhase.Ancient);
    Orc orc = new(new Sword(SwordType.Longsword));

    Console.WriteLine($"This monster is worth {ScoreFor(orc)} points.");
}

void Test2()
{
    // Example of using relational patterns and the 'and' pattern
    string GetGenerationName(int birthYear)
    {
        return birthYear switch
        {
            >= 1883 and <= 1900 => "The Lost Generation",
            >= 1901 and <= 1924 => "The Greatest Generation",
            >= 1925 and <= 1945 => "The Silent Generation",
            >= 1946 and <= 1964 => "The Baby Boomer Generation",
            >= 1965 and <= 1980 => "Generation X",
            >= 1981 and <= 1996 => "Generation Y",
            >= 1997 and <= 2012 => "Generation Z",
            >= 2013 and <= 2025 => "Generation Alpha",
            _ => "Unknown"
        };
    }

    Console.Write("Enter the year you were born in: ");
    int birthYear = Int32.Parse(Console.ReadLine()!);
    Console.WriteLine($"You're a member of {GetGenerationName(birthYear)}.");
}

Test2();

/***** Type Definitions *****/

public abstract record Monster;
public record Skeleton : Monster;
public record Snake(double Length) : Monster;
public record Dragon(DragonType Type, LifePhase LifePhase) : Monster;
public record Orc(Sword Sword) : Monster;

public record Sword(SwordType Type);

public enum DragonType { Black, Green, Red, Blue, Gold }
public enum LifePhase { Wyrmling, Young, Adult, Ancient }
public enum SwordType { WoodenStick, ArmingSword, Longsword }