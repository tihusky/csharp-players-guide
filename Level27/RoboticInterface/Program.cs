var robot = new Robot();

string userInput;

do
{
    Console.Write("Enter next command: ");
    userInput = Console.ReadLine()?.Trim().ToLower() ?? "stop";

    if (userInput != "stop")
    {
        IRobotCommand? command = userInput switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "east" => new EastCommand(),
            "south" => new SouthCommand(),
            "west" => new WestCommand(),
            _ => null
        };

        if (command != null)
            robot.Commands.Add(command);
        else
            Console.WriteLine("Invalid command.");
    }
} while (userInput != "stop");

Console.Clear();
robot.Run();

/***** Type Definitions *****/

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new();

    public void Run()
    {
        foreach (IRobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y -= 1;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X += 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X -= 1;
    }
}