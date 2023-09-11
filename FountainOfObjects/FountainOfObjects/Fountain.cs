using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Fountain : GameObject
{
    public bool IsActivated { get; set; }

    public Fountain(Position position) : base(position) {}

    public override ColoredMessage Description
    {
        get
        {
            string message = IsActivated
                ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
                : "You hear water dripping in this room. The Fountain of Objects is here!";
            
                return new ColoredMessage(ConsoleColor.Blue, message);
        }
    }
}