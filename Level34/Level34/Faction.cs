// Example of adding extension methods to an enum

namespace Level34;

internal enum Faction
{
    Federation,
    Romulans,
    Klingons
}

internal static class FactionExtensions
{
    public static ConsoleColor GetColor(this Faction faction)
    {
        return faction switch
        {
            Faction.Federation => ConsoleColor.Green,
            Faction.Romulans => ConsoleColor.DarkMagenta,
            Faction.Klingons => ConsoleColor.DarkRed,
            _ => ConsoleColor.White
        };
    }
}