void PrintAdjacency(Coordinate a, Coordinate b)
{
    Console.WriteLine(a.AdjacentTo(b) ? $"{a} is adjacent to {b}" : $"{a} is not adjacent to {b}");
}

Coordinate c1 = new Coordinate { Row = 0, Column = 0 };
Coordinate c2 = new Coordinate { Row = 1, Column = 1 };

PrintAdjacency(c1, c2);

Coordinate c3 = new Coordinate { Row = 2, Column = 1 };

PrintAdjacency(c2, c3);

Coordinate c4 = new Coordinate { Row = 0, Column = -1 };

PrintAdjacency(c1, c4);

/***** Type Definitions *****/

public struct Coordinate
{
    public int Row { get; init; }
    public int Column { get; init; }

    public bool AdjacentTo(Coordinate other)
    {
        int rowDelta = Math.Abs(Row - other.Row);
        int columnDelta = Math.Abs(Column - other.Column);

        return (rowDelta + columnDelta) <= 1;
    }

    public override string ToString()
    {
        return $"({Column}, {Row})";
    }
}
