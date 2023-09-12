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

    private IPlayerAction GetPlayerAction()
    {
        Console.WriteLine("""
                          1) Move North
                          2) Move East
                          3) Move South
                          4) Move West
                          5) Shoot North
                          6) Shoot East
                          7) Shoot South
                          8) Shoot West
                          9) Enable Fountain
                          """
        );

        int userChoice = ConsoleHelper.GetIntBetween(1, 9, ">");

        return userChoice switch
        {
            1 => new MoveAction(_player, _map, Direction.North),
            2 => new MoveAction(_player, _map, Direction.East),
            3 => new MoveAction(_player, _map, Direction.South),
            4 => new MoveAction(_player, _map, Direction.West),
            5 => new ShootAction(_player, _map, Direction.North),
            6 => new ShootAction(_player, _map, Direction.East),
            7 => new ShootAction(_player, _map, Direction.South),
            8 => new ShootAction(_player, _map, Direction.West),
            9 => new EnableAction(_player, _map)
        };
    }

    private void PrintActionResult(ActionResult result)
    {
        Console.Clear();
        ConsoleHelper.WriteColoredMessage(
            new ColoredMessage(result.Success ? ConsoleColor.Green : ConsoleColor.Red, result.Message));
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
    private void PrintPlayerStatus()
    {
        Console.WriteLine(
            $"Row: {_player.Position.Row}, Column: {_player.Position.Column}, Arrows: {_player.Arrows}"
        );
    }

    private void PrintSurroundings()
    {
        var sensables = _map.GetSensables(_player.Position);

        if (sensables.Count == 0)
        {
            ConsoleHelper.WriteColoredMessage(new ColoredMessage(
                ConsoleColor.DarkGray, "You don't sense anything special in your immediate surroundings.")
            );

            return;
        }
        
        foreach (GameObject gameObject in sensables)
        {
            ConsoleHelper.WriteColoredMessage(gameObject.Description);
        }
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            PrintPlayerStatus();
            Console.Write('\n');
            PrintSurroundings();
            Console.Write('\n');

            ActionResult result = GetPlayerAction().Perform();
            
            PrintActionResult(result);
            
            isRunning = _player.IsAlive &&
                        (!_map.Fountain.IsActivated || _player.Position != _map.Entrance.Position);
        }

        Console.Clear();

        if (_player.IsAlive)
        {
            ConsoleHelper.WriteColoredMessage(
                new ColoredMessage(
                    ConsoleColor.Green,
                    "The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!"
                )
            );
        }
        else
        {
            ConsoleHelper.WriteColoredMessage(
                new ColoredMessage(ConsoleColor.Red, "You died! The Uncoded One's forces were victorious.")
            );
        }
    }
}