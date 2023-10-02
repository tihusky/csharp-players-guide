Point p1 = new(2, 8);
Point p2 = new(1, 3);
Point p3 = p1 + p2;

Console.WriteLine($"{p1} + {p2} = {p3}");

p1 = new Point(4, 2);
p2 = p1 * 3;
p3 = 5 * p1;

Console.WriteLine($"{p1} * 3 = {p2}");
Console.WriteLine($"5 * {p1} = {p3}");

/***** Type Definitions *****/

public record Point(double X, double Y)
{
    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator *(Point p, double scalar) => new Point(p.X * scalar, p.Y * scalar);
    public static Point operator *(double scalar, Point p) => p * scalar;

    public override string ToString() => $"({X}, {Y})";
}