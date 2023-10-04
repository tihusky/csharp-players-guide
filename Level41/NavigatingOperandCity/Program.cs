var start = new BlockCoordinate(3, 5);
var offset = new BlockOffset(4, 2);
var direction = Direction.South;
var destination = start + offset;

Console.WriteLine($"Starting at {start} and moving by {offset} you end up at {destination}");

// Even though the operator overload that adds a BlockCoordinate and a Direction is commented
// out this line still works. The reason is the implicit type conversion from a Direction to a
// BlockOffset defined in the BlockOffset class.
// The compiler can then use the operator overload that adds a BlockCoordinate and a BlockOffset.
// EDIT: Even though there's an implicit type conversion I can still use the syntax for an
// explicit one.
destination = start + (BlockOffset)direction;

Console.WriteLine($"Strating at {start} and moving {direction} you end up at {destination}");

// In this case the indexer doesn't provide any benefits imho; accessing Row and Column would be more readable.
Console.WriteLine($"Row: {destination[0]}, Column: {destination[1]}");

/***** Type Definitions *****/

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate start, BlockOffset offset) =>
        new BlockCoordinate(start.Row + offset.RowOffset, start.Column + offset.ColumnOffset);

    //public static BlockCoordinate operator +(BlockCoordinate start, Direction direction)
    //{
    //    return direction switch
    //    {
    //        Direction.North => new BlockCoordinate(start.Row - 1, start.Column),
    //        Direction.East  => new BlockCoordinate(start.Row, start.Column + 1),
    //        Direction.South => new BlockCoordinate(start.Row + 1, start.Column),
    //        Direction.West  => new BlockCoordinate(start.Row, start.Column - 1)
    //    };
    //}

    public int this[int index]
    {
        get
        {
            return index switch
            {
                0 => Row,
                1 => Column,
                _ => throw new IndexOutOfRangeException("Only indices 0 and 1 are valid for a BlockCoordinate")
            };
        }
    }

    public override string ToString() => $"(Row: {Row}, Column: {Column})";
}

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public override string ToString() => $"(RowOffset: {RowOffset}, ColumnOffset: {ColumnOffset})";

    // While I generally think implicit type conversions can make it more difficult to figure out
    // what's happening, I used an implicit conversion here since technically there's no loss of
    // data.
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.East => new BlockOffset(0, +1),
            Direction.South => new BlockOffset(+1, 0),
            Direction.West => new BlockOffset(0, -1)
        };
    }
}

public enum Direction { North, East, South, West }