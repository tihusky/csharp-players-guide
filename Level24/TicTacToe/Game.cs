namespace TicTacToe;

public enum TicTacToeSymbol
{
    Empty,
    X,
    O
}

public class Game
{
    private readonly Board _board = new ();
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private Player _activePlayer;

    public Game()
    {
        _playerOne = new Player("Player One", TicTacToeSymbol.X);
        _playerTwo = new Player("Player Two", TicTacToeSymbol.O);
        _activePlayer = _playerOne;
    }
    
    public void Run()
    {
        bool isWon = false;
        bool isDrawn = false;

        while (!isWon && !isDrawn)
        {
            DisplayBoard();

            int chosenCell = AskForPlayerChoice();
            _board.FillCell(chosenCell, _activePlayer.Symbol);
            
            isWon = _board.IsWon();
            isDrawn = _board.IsDrawn();

            if (!isWon && !isDrawn)
                _activePlayer = (_activePlayer == _playerOne) ? _playerTwo : _playerOne;
        }

        DisplayBoard();

        if (isWon)
        {
            IoHelper.WriteLineColored($"{_activePlayer.Name} won!", ConsoleColor.Green);
        }
        else
        {
            IoHelper.WriteLineColored("It's a draw!", ConsoleColor.Yellow);
        }
    }

    private void DisplayBoard()
    {
        Console.Clear();
        
        for (int row = 0; row < _board.Cells.GetLength(0); row++)
        {
            if (row != 0)
                Console.WriteLine("---+---+---");

            for (int column = 0; column < _board.Cells.GetLength(1); column++)
            {
                if (column != 0)
                    Console.Write('|');

                char symbol = _board.Cells[row, column].Symbol switch
                {
                    TicTacToeSymbol.X => 'X',
                    TicTacToeSymbol.O => 'O',
                    _ => ' '
                };
                
                Console.Write($" {symbol} ");
            }
            
            Console.WriteLine();
        }
        
        // Additional empty line after the board for styling
        Console.WriteLine();
    }

    private int AskForPlayerChoice()
    {
        while (true)
        {
            Console.Write($"{_activePlayer.Name}, what cell do you want to play in? ");
            bool isParseable = int.TryParse(Console.ReadLine(), out int number);

            if (isParseable && _board.IsValidCell(number))
                return number;

            IoHelper.WriteLineColored("Invalid cell.", ConsoleColor.Red);
        }
    }
}