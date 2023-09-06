using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    public interface ISensable
    {
        bool CanBeSensed(Position playerPosition);
        string GetDescription();
    }
}
