using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Map
{
    public int Rows { get; }
    public int Columns { get; }
    public Entrance Entrance { get; }
    public Fountain Fountain { get; }

    private readonly List<Pit> _pits = new();
    
    public Map(int rows, int columns, Entrance entrance, Fountain fountain)
    {
        Rows = rows;
        Columns = columns;
        Entrance = entrance;
        Fountain = fountain;
    }

    public bool IsOnMap(Position position)
        => (position.Row >= 0 && position.Row < Rows) && (position.Column >= 0 && position.Column < Columns);

    public void AddPit(Position position)
    {
        if (IsOnMap(position))
        {
            _pits.Add(new Pit(position));
        }
    }

    public Obstacle? GetObstacleAt(Position position)
    {
        foreach (Pit pit in _pits)
        {
            if (pit.Position == position)
            {
                return pit;
            }
        }

        return null;
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

        return sensables;
    }
}