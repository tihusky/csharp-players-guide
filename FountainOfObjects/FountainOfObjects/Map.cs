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

    public Map(int rows, int columns, Entrance entrance, Fountain fountain)
    {
        Rows = rows;
        Columns = columns;
        Entrance = entrance;
        Fountain = fountain;
    }

    public bool IsOnMap(Position position)
        => (position.Row >= 0 && position.Row < Rows) && (position.Column >= 0 && position.Column < Columns);

    public List<GameObject> GetSensables(Position playerPosition)
    {
        var sensables = new List<GameObject>();

        if (Entrance.IsSensable(playerPosition)) sensables.Add(Entrance);
        if (Fountain.IsSensable(playerPosition)) sensables.Add(Fountain);

        return sensables;
    }
}