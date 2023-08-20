namespace FifteenPuzzle;

public class BoardGenerator
{
    private readonly Random _rng = new();
    private readonly int _numRows;
    private readonly int _numColumns;

    public BoardGenerator(int numRows, int numColumns)
    {
        _numRows = numRows;
        _numColumns = numColumns;
    }

    public Board GenerateBoard()
    {
        var slots = new Slot[_numRows * _numColumns];

        // Fill all slots except for the last one
        for (var idx = 0; idx < slots.Length - 1; idx++)
        {
            slots[idx] = new Slot
            {
                Tile = new Tile { Number = idx + 1 }
            };
        }
        
        // Fill the last item with a slot instance that doesn't have a tile
        slots[^1] = new Slot { Tile = null };

        Shuffle(slots);
        
        return new Board(_numRows, _numColumns, slots);
    }

    /* Shuffles the slots (i.e. the tiles) in place. */
    private void Shuffle(Slot[] slots)
    {
        for (int currentIndex = slots.Length - 1; currentIndex >= 1; currentIndex--)
        {
            int randomIndex = _rng.Next(currentIndex);
            
            // Swaps the current rightmost element with the randomly selected one
            (slots[currentIndex], slots[randomIndex]) = (slots[randomIndex], slots[currentIndex]);
        }
    }
}