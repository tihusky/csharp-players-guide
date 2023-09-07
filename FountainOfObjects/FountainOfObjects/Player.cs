using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Player
{
    public bool IsAlive { get; set; }
    public Position Position { get; set; }

    public Player(Position position)
    {
        IsAlive = true;
        Position = position;
    }
}