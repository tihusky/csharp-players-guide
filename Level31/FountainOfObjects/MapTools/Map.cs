using FountainOfObjects.MapTools.Obstacles;
using FountainOfObjects.MapTools.Obstacles.Monsters;

namespace FountainOfObjects.MapTools;

internal class Map
{
    public int Rows { get; }
    public int Columns { get; }
    public Entrance Entrance { get; }
    public Fountain Fountain { get; }

    private readonly List<Pit> _pits = new();
    private readonly List<Monster> _monsters = new();
    
    public Map(int rows, int columns, Entrance entrance, Fountain fountain)
    {
        Rows = rows;
        Columns = columns;
        Entrance = entrance;
        Fountain = fountain;
    }

    public bool IsOnMap(Position position)
        => (position.Row >= 0 && position.Row < Rows) && (position.Column >= 0 && position.Column < Columns);

    public bool IsEmpty(Position position)
    {
        if (Entrance.Position == position) return false;
        if (Fountain.Position == position) return false;

        return GetObstacleAt(position) == null;
    }

    public Position Clamp(Position position)
    {
        int row = Math.Clamp(position.Row, 0, Rows - 1);
        int column = Math.Clamp(position.Column, 0, Columns - 1);

        return new Position(row, column);
    }

    public void AddPit(Position position)
    {
        if (IsOnMap(position))
        {
            _pits.Add(new Pit(position));
        }
    }

    public void AddMonster(Monster monster)
    {
        if (IsOnMap(monster.Position))
        {
            _monsters.Add(monster);
        }
    }

    public Pit? GetPitAt(Position position)
    {
        return _pits.Find(pit => pit.Position == position);
    }

    public Monster? GetMonsterAt(Position position)
    {
        return _monsters.Find(monster => monster.Position == position && monster.IsAlive);
    }

    public Obstacle? GetObstacleAt(Position position)
    {
        Pit? pit = GetPitAt(position);

        if (pit != null)
        {
            return pit;
        }

        return GetMonsterAt(position);
    }
    
    public List<GameObject> GetSensables(Position playerPosition)
    {
        var sensables = new List<GameObject>();

        if (Entrance.IsSensable(playerPosition)) sensables.Add(Entrance);
        if (Fountain.IsSensable(playerPosition)) sensables.Add(Fountain);

        foreach (Pit pit in _pits)
        {
            if (pit.IsSensable(playerPosition))
            {
                sensables.Add(pit);
            }
        }

        foreach (Monster monster in _monsters)
        {
            if (monster.IsSensable(playerPosition))
            {
                sensables.Add(monster);
            }
        }

        return sensables;
    }
}