using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class Game
{
    private readonly Map _map;
    private readonly Player _player;

    public Game(Map map)
    {
        _map = map;
        _player = new Player(_map.Entrance.Position);
    }

    private void PrintSurroundings()
    {
        var sensableObjects = _map.GetSensables(_player.Position);

        if (sensableObjects.Count < 1) return;

        foreach (GameObject gameObject in sensableObjects)
        {
            ConsoleHelper.WriteColoredMessage(gameObject.Description);
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

        int userChoice = ConsoleHelper.GetIntBetween(1, 5, ">");

        return userChoice switch
        {
            1 => new MoveAction(_player, _map, Direction.North),
            2 => new MoveAction(_player, _map, Direction.East),
            3 => new MoveAction(_player, _map, Direction.South),
            4 => new MoveAction(_player, _map, Direction.West),
            5 => new EnableAction(_player, _map)
        };
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine($"You are at {_player.Position}\n");

            PrintSurroundings();

            bool success = GetPlayerAction().Perform();

            if (!success)
            {
                ConsoleHelper.WriteColoredMessage(new ColoredMessage(ConsoleColor.Red, "You can't do that here."));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            isRunning = _player.IsAlive &&
                        (!_map.Fountain.IsActivated || _player.Position != _map.Entrance.Position);
        }

        Console.Clear();

        if (_player.IsAlive)
        {
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.WriteLine("You win!");
        }
        else
        {
            Console.WriteLine("You died!");
        }
    }
}