namespace RockPaperScissors;

public class Game
{
    private readonly HistoricalRecord _scores = new ();

    public void Run()
    {
        bool isRunning;

        do
        {
            Console.Clear();
            RoundResult result = new Round().Run();

            if (result == RoundResult.PlayerOneWon)
            {
                _scores.PlayerOneScore++;
                Console.WriteLine("Player One won!");
            }
            else if (result == RoundResult.PlayerTwoWon)
            {
                _scores.PlayerTwoScore++;
                Console.WriteLine("Player Two won!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            
            Console.Write("\nPlay again? (y/n) ");
            string userInput = Console.ReadLine()?.Trim().ToLower() ?? "n";
            isRunning = userInput == "y";
        } while (isRunning);
        
        Console.Clear();
        Console.WriteLine($"Player One Score: {_scores.PlayerOneScore}");
        Console.WriteLine($"Player Two Score: {_scores.PlayerTwoScore}");
    }
}