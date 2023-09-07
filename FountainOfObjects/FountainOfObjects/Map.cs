using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Map
{
    public int Rows { get; } = 4;
    public int Columns { get; } = 4;
    public Entrance Entrance { get; }
    public Fountain Fountain { get; }

    public Map(Entrance entrance, Fountain fountain)
    {
        Entrance = entrance;
        Fountain = fountain;
    }

    public bool IsPositionValid(Position position)
        => (position.Row >= 0 && position.Row < Rows) && (position.Column >= 0 && position.Column < Columns);

    public List<ISensable> GetSensables(Position playerPosition)
    {
        var sensables = new List<ISensable>();

        if (Entrance.CanBeSensed(playerPosition)) sensables.Add(Entrance);
        if (Fountain.CanBeSensed(playerPosition)) sensables.Add(Fountain);

        return sensables;
    }
}