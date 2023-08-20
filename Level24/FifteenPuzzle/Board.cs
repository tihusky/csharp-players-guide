namespace FifteenPuzzle;

public class Board
{
    public int Rows { get; }
    public int Columns { get; }
    public Slot[] Slots { get; }

    public Board(int rows, int columns, Slot[] slots)
    {
        Rows = rows;
        Columns = columns;
        Slots = slots;
    }

    public void MoveTile(int tileNumber)
    {
        throw new NotImplementedException();
    }

    public bool IsSolved => false;
}