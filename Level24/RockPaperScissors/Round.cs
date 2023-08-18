namespace RockPaperScissors;

public enum PlayerChoice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum RoundResult
{
    PlayerOneWon,
    Draw,
    PlayerTwoWon
}

public class Round
{
    private PlayerChoice _playerOneChoice;
    private PlayerChoice _playerTwoChoice;

    /* Starts a new round of the game and returns the round's result. */
    public RoundResult Run()
    {
        // Ask for and store player one's choice
        Console.WriteLine("""
                          Player One, make your choice:
                          1) Rock
                          2) Paper
                          3) Scissors
                          """
        );

        int playerOneInput = ConsoleHelper.GetIntBetween(1, 3, ">");
        _playerOneChoice = (PlayerChoice)playerOneInput;
        Console.Clear();
        
        // Ask for and store player two's choice
        Console.WriteLine("""
                          Player Two, make your choice:
                          1) Rock
                          2) Paper
                          3) Scissors
                          """
        );
        
        int playerTwoInput = ConsoleHelper.GetIntBetween(1, 3, ">");
        _playerTwoChoice = (PlayerChoice)playerTwoInput;
        Console.Clear();

        // Determine who won and return result
        return DetermineWinner();
    }

    /* Figures out who won this round. */
    private RoundResult DetermineWinner()
    {
        // Check for all cases in which player one won
        if ((_playerOneChoice == PlayerChoice.Rock && _playerTwoChoice == PlayerChoice.Scissors) ||
            (_playerOneChoice == PlayerChoice.Paper && _playerTwoChoice == PlayerChoice.Rock) ||
            (_playerOneChoice == PlayerChoice.Scissors && _playerTwoChoice == PlayerChoice.Paper))
        {
            return RoundResult.PlayerOneWon;
        }

        // Check for all cases in which player two won
        if ((_playerOneChoice == PlayerChoice.Rock && _playerTwoChoice == PlayerChoice.Paper) ||
            (_playerOneChoice == PlayerChoice.Paper && _playerTwoChoice == PlayerChoice.Scissors) ||
            (_playerOneChoice == PlayerChoice.Scissors && _playerTwoChoice == PlayerChoice.Rock))
        {
            return RoundResult.PlayerTwoWon;
        }

        return RoundResult.Draw;
    }
}