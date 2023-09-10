using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Game
{
    public Map Map { get; }
    public Player Player { get; }

    public Game(Map map)
    {
        Map = map;
        Player = new Player(Map.Entrance.Position);
    }

    private void PrintSurroundings()
    {
        var sensables = Map.GetSensables(Player.Position);

        if (sensables.Count < 1) return;

        foreach (var sensable in sensables)
        {
            ConsoleHelper.WriteColoredMessage(sensable.GetDescription());
        }

        Console.WriteLine();
    }

    private IPlayerAction GetPlayerAction()
    {
        Console.WriteLine("""
                          1) Move North
                          2) Move East
                          3) Move South
                          4) Move West
                          5) Enable Fountain
                          """
        );

        while (true)
        {
            Console.Write("> ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int number);

            if (isNumber && number >= 1 && number <= 5)
            {
                return number switch
                {
                    1 => new MoveAction(Player, Map, Direction.North),
                    2 => new MoveAction(Player, Map, Direction.East),
                    3 => new MoveAction(Player, Map, Direction.South),
                    4 => new MoveAction(Player, Map, Direction.West),
                    5 => new EnableAction(Player, Map)
                };
            }

            ConsoleHelper.WriteColoredMessage(new ColoredMessage(ConsoleColor.Red, "Invalid input."));
        }
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine($"You are at {Player.Position}\n");

            PrintSurroundings();

            bool success = GetPlayerAction().Perform();

            if (!success)
            {
                ConsoleHelper.WriteColoredMessage(new ColoredMessage(ConsoleColor.Red, "You can't do that here."));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            isRunning = !Map.Fountain.IsActivated ||
                        (Map.Fountain.IsActivated && Player.Position != Map.Entrance.Position);
        }

        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.WriteLine("You win!");
    }
}