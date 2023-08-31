Point p1 = new Point(4, 2);
Point p2 = new Point(); // Compiler still generates a parameterless constructor
Point p3 = p2;

p3.X = 2;
p3.Y = 4;

Console.WriteLine($"p1: ({p1.X}, {p1.Y})");
Console.WriteLine($"p2: ({p2.X}, {p2.Y})");
Console.WriteLine($"p3: ({p3.X}, {p3.Y})");

/***** Type Definitions *****/

public struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}