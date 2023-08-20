namespace FifteenPuzzle;

public class Slot
{
    public Tile? Tile { get; set; }
    public bool IsEmpty => Tile == null;
}