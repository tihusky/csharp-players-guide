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
                      2) Off
                      3) North
                      4) East
                      5) South
                      6) West  
                      """
    );

    int userSelection = GetIntBetween(1, 6, ">");

    robot.Commands[i] = userSelection switch
    {
        1 => new OnCommand(),
        2 => new OffCommand(),
        3 => new NorthCommand(),
        4 => new EastCommand(),
        5 => new SouthCommand(),
        6 => new WestCommand(),
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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X += 1;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}