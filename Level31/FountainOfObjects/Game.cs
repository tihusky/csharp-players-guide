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

    private IPlayerAction NumberToAction(int number)
    {
        return number switch
        {
            1 => new MoveAction(_player, _map, Direction.North),
            2 => new MoveAction(_player, _map, Direction.East),
            3 => new MoveAction(_player, _map, Direction.South),
            4 => new MoveAction(_player, _map, Direction.West),
            5 => new ShootAction(_player, _map, Direction.North),
            6 => new ShootAction(_player, _map, Direction.East),
            7 => new ShootAction(_player, _map, Direction.South),
            8 => new ShootAction(_player, _map, Direction.West),
            9 => new EnableAction(_player, _map),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void PrintActionResult(ActionResult result)
    {
        Console.Clear();
        Helpers.WriteColoredMessage(
            new ColoredMessage(result.Success ? ConsoleColor.Green : ConsoleColor.Red, result.Message));
        Console.WriteLine("\nPress any key to continue...");
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
            Helpers.WriteColoredMessage(new ColoredMessage(
                ConsoleColor.DarkGray, "You don't sense anything special in your immediate surroundings.")
            );

            return;
        }
        
        foreach (GameObject gameObject in sensables)
        {
            Helpers.WriteColoredMessage(gameObject.Description);
        }
    }
    
    private void PrintHelp()
    {
        Console.Clear();
        Console.WriteLine("""
                          [!] Look out for pits. You will feel a breeze if a pit is in an adjacent room.
                              If you enter a room with a pit, you will die.
                          """
        );
        Console.WriteLine("""
                          [!] Amaroks roam the caverns. Encountering one is certain death, but you can
                              smell their rotten stench in nearby rooms.
                          """
        );
        Console.WriteLine("""
                          [!] You carry with you a bow and a quiver of arrows. You can use them to shoot
                              monsters in the caverns but be warned: you have a limited supply.
                          """
        );
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("""
                          You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in
                          search of the Fountain of Objects.
                          Light is only visible in the entrance, and no other light is seen anywhere in
                          the caverns.
                          You must navigate the Caverns with your other senses.
                          Find the Fountain of Objects, activate it, and return to the entrance.
                          """
        );
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            PrintPlayerStatus();
            Console.Write('\n');
            PrintSurroundings();
            Console.Write('\n');
            Console.WriteLine("""
                              0) Show Help
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

            int userSelection = Helpers.GetIntBetween(0, 9, ">");

            if (userSelection == 0)
            {
                PrintHelp();
            }
            else
            {
                ActionResult result = NumberToAction(userSelection).Perform();
                
                if (result.HasMessage)
                {
                    PrintActionResult(result);
                }
            }
            
            isRunning = _player.IsAlive &&
                        (!_map.Fountain.IsActivated || _player.Position != _map.Entrance.Position);
        }

        Console.Clear();

        if (_player.IsAlive)
        {
            Helpers.WriteColoredMessage(
                new ColoredMessage(
                    ConsoleColor.Green,
                    "The Fountain of Objects has been reactivated, and you have escaped with your life! You win!"
                )
            );
        }
        else
        {
            Helpers.WriteColoredMessage(
                new ColoredMessage(ConsoleColor.Red, "You died! The Uncoded One's forces were victorious.")
            );
        }
    }
}