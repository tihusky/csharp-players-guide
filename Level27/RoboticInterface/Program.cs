int GetIntBetween(int min, int max, string prompt)
{
    while (true)
    {
        Console.Write($"{prompt} ");
        bool isNumber = int.TryParse(Console.ReadLine(), out int number);

        if (isNumber && number >= min && number <= max)
            return number;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input.");
        Console.ResetColor();
    }
}

var robot = new Robot();

for (int i = 0; i < robot.Commands.Length; i++)
{
    Console.Clear();
    Console.WriteLine("""
                      Select the next command...
                      1) On
                      2) North
                      3) East
                      4) South
                      5) West
                      6) Off
                      """
    );

    int userSelection = GetIntBetween(1, 6, ">");

    robot.Commands[i] = userSelection switch
    {
        1 => new OnCommand(),
        2 => new NorthCommand(),
        3 => new EastCommand(),
        4 => new SouthCommand(),
        5 => new WestCommand(),
        6 => new OffCommand(),
        _ => throw new NotImplementedException()
    };
}

Console.Clear();
robot.Run();

/***** Type Definitions *****/

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand[] Commands { get; } = new IRobotCommand[3];

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