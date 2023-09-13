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
        
        map.AddPit(new Position(1, 2));
        map.AddMonster(new Amarok(new Position(3, 1)));
        map.AddMonster(new Maelstrom(new Position(2, 0)));
        
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
        
        map.AddPit(new Position(2, 2));
        map.AddPit(new Position(4, 3));
        map.AddMonster(new Amarok(new Position(1, 1)));
        map.AddMonster(new Amarok(new Position(3, 4)));

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
        
        map.AddPit(new Position(1, 3));
        map.AddPit(new Position(3, 1));
        map.AddPit(new Position(4, 5));
        map.AddPit(new Position(5, 2));
        map.AddMonster(new Amarok(new Position(4, 3)));
        map.AddMonster(new Amarok(new Position(5, 0)));
        map.AddMonster(new Amarok(new Position(6, 6)));

        return map;
    }
}