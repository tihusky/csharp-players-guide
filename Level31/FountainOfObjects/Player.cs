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
    public int Arrows { get; set; } = 5;
    public string? DeathReason { get; private set; }

    public Player(Position position)
    {
        IsAlive = true;
        Position = position;
    }

    public void Die(string deathReason)
    {
        IsAlive = false;
        DeathReason = deathReason;
    }
}