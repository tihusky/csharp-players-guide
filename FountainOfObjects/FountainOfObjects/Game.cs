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

    public Game()
    {
        Map = new Map(
            new Entrance(new Position(0, 0)),
            new Fountain(new Position(0, 2))
        );

        Player = new Player(Map.Entrance.Position);
    }

    private void PrintSurroundings()
    {
        var sensables = Map.GetSensables(Player.Position);

        if (sensables.Count < 1) return;

        foreach (var sensable in sensables)
        {
            Console.WriteLine(sensable.GetDescription());
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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid selection.");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't do that.");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            isRunning = !Map.Fountain.IsActivated || (Map.Fountain.IsActivated && Player.Position != Map.Entrance.Position);
        }

        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.WriteLine("You win!");
    }
}