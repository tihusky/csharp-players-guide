Point p1 = new Point(4, 2);
Point p2 = new Point(4, 2);

Console.WriteLine(p1 == p2);

for (int x = (int)p1.X; x >= 0; x--)
{
    Point p3 = p1 with { X = x };

    Console.WriteLine(p3);
}

/***** Type Definitions *****/

public record Point(float X, float Y);