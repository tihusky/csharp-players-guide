namespace TicTacToe;

public class Cell
{
    public TicTacToeSymbol Symbol { get; set; } = TicTacToeSymbol.Empty;
    public bool IsEmpty => Symbol == TicTacToeSymbol.Empty;
}