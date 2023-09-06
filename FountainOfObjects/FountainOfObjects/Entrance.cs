using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class Entrance : ISensable
    {
        public Position Position { get; }

        public Entrance(Position position)
        {
            Position = position;
        }

        public bool CanBeSensed(Position playerPosition) =>
            Position.Row == playerPosition.Row && Position.Column == playerPosition.Column;

        public string GetDescription() => 
            "You see light in this room coming from outside the cavern. This is the entrance.";
    }
}
