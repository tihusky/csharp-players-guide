using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

public class Fountain : ISensable
{
    public Position Position { get; }
    public bool IsActivated { get; set; }

    public Fountain(Position position)
    {
        Position = position;
    }

    public bool CanBeSensed(Position playerPosition) =>
        Position.Row == playerPosition.Row && Position.Column == playerPosition.Column;

    public string GetDescription()
    {
        return IsActivated
            ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
            : "You hear water dripping in this room. The Fountain of Objects is here!";
    }
}