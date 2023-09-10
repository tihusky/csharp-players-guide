using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal record Position(int Row, int Column)
{
    public override string ToString()
    {
        return $"(Row: {Row}, Column: {Column})";
    }
}