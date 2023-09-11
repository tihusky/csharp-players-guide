namespace FountainOfObjects;

internal static class MapBuilder
{
    public static Map GenerateSmallMap()
    {
        var map = new Map(
            4,
            4,
            new Entrance(new Position(0, 0)),
            new Fountain(new Position(0, 2))
        );

        return map;
    }

    public static Map GenerateMediumMap()
    {
        var map = new Map(
            6,
            6,
            new Entrance(new Position(4, 0)),
            new Fountain(new Position(2, 4))
        );

        return map;
    }

    public static Map GenerateLargeMap()
    {
        var map = new Map(
            8,
            8,
            new Entrance(new Position(7, 5)),
            new Fountain(new Position(1, 1))
        );

        return map;
    }
}