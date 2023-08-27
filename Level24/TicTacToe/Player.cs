namespace TicTacToe;

public class Player
{
    public string Name { get; }
    public TicTacToeSymbol Symbol { get; }

    public Player(string name, TicTacToeSymbol symbol)
    {
        Name = name;
        Symbol = symbol;
    }
}