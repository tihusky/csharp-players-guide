﻿try
{
    Play();
}
catch (GameOverException ex)
{
    Console.WriteLine(ex.Message);
}

void Play()
{
    int secretNumber = new Random().Next(10);
    List<int> pickedNumbers = new();
    Player playerOne = new("Player One");
    Player playerTwo = new("Player Two");
    Player currentPlayer = playerOne;

    while (true)
    {
        Console.Write($"{currentPlayer.Name}, pick a number: ");
        bool isNumber = int.TryParse(Console.ReadLine(), out int number);

        if (!isNumber)
        {
            Console.WriteLine("Your input must be numeric.");
            continue;
        }
        else if (number < 0 || number > 9)
        {
            Console.WriteLine("Your number must be between 0 and 9 (inclusive).");
            continue;
        }
        else if (pickedNumbers.Contains(number))
        {
            Console.WriteLine("That number was already picked.");
            continue;
        }

        if (number == secretNumber)
            throw new GameOverException($"Game over! {currentPlayer.Name} ate the oatmeal raisin cookie.");

        pickedNumbers.Add(number);
        currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
    }
}

/***** Type Definitions *****/

internal class GameOverException : Exception
{
    public GameOverException(string message) : base(message) {}
}

internal record Player(string Name);