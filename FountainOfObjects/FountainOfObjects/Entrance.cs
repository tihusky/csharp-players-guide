using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Entrance : GameObject
{
    public Entrance(Position position) : base(position) {}

    public override ColoredMessage Description =>
        new(
            ConsoleColor.Yellow,
            "You see light in this room coming from outside the cavern. This is the entrance."
        );
}