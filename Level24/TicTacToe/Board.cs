namespace TicTacToe;

public class Board
{
    public Cell[,] Cells { get; } = new Cell[3, 3];

    public Board()
    {
        for (int row = 0; row < Cells.GetLength(0); row++)
        {
            for (int column = 0; column < Cells.GetLength(1); column++)
            {
                Cells[row, column] = new Cell { Symbol = TicTacToeSymbol.Empty };
            }
        }
    }

    // Checks if a cell exists and is empty.
    public bool IsValidCell(int cellNumber)
    {
        // If the cell doesn't exist the left side evaluates to null and the default value (false) is returned.
        return GetCellByNumber(cellNumber)?.IsEmpty ?? false;
    }

    public void FillCell(int cellNumber, TicTacToeSymbol symbol)
    {
        Cell? cell = GetCellByNumber(cellNumber);

        if (cell != null)
            cell.Symbol = symbol;
    }

    public bool IsWon()
    {
        // Check for horizontal wins
        if (NotEmptyAndEqual(Cells[0, 0], Cells[0, 1], Cells[0, 2]) ||
            NotEmptyAndEqual(Cells[1, 0], Cells[1, 1], Cells[1, 2]) ||
            NotEmptyAndEqual(Cells[2, 0], Cells[2, 1], Cells[2, 2]))
            return true;
        
        // Check for vertical wins
        if (NotEmptyAndEqual(Cells[0, 0], Cells[1, 0], Cells[2, 0]) ||
            NotEmptyAndEqual(Cells[0, 1], Cells[1, 1], Cells[2, 1]) ||
            NotEmptyAndEqual(Cells[0, 2], Cells[1, 2], Cells[2, 2]))
            return true;
        
        // Check for diagonal wins
        if (NotEmptyAndEqual(Cells[0, 0], Cells[1, 1], Cells[2, 2]) ||
            NotEmptyAndEqual(Cells[0, 2], Cells[1, 1], Cells[2, 0]))
            return true;

        return false;
    }

    public bool IsDrawn()
    {
        return AllCellsFilled() && !IsWon();
    }

    private bool AllCellsFilled()
    {
        for (int row = 0; row < Cells.GetLength(0); row++)
        {
            for (int column = 0; column < Cells.GetLength(1); column++)
            {
                if (Cells[row, column].IsEmpty)
                    return false;
            }
        }

        return true;
    }

    // Returns an element from the two-dimensional Cells array. The numpad is used as
    // reference, e.g. when given the number 7 it will return the element at index [0, 0].
    // If an invalid number is passed in, the value null is returned.
    private Cell? GetCellByNumber(int number)
    {
        return number switch
        {
            7 => Cells[0, 0],
            8 => Cells[0, 1],
            9 => Cells[0, 2],
            4 => Cells[1, 0],
            5 => Cells[1, 1],
            6 => Cells[1, 2],
            1 => Cells[2, 0],
            2 => Cells[2, 1],
            3 => Cells[2, 2],
            _ => null
        };
    }
    
    // Checks if the given cells are not empty and contain the same symbol.
    private static bool NotEmptyAndEqual(params Cell[] cells)
    {
        if (cells.Length < 1)
            return false;

        TicTacToeSymbol symbol = cells[0].Symbol;

        if (symbol == TicTacToeSymbol.Empty)
            return false;
        
        return Array.TrueForAll(cells, cell => cell.Symbol == symbol);
    }
}