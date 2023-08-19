using ThePoint;

var points = new Point[]
{
    new(),
    new(2, 3),
    new(-4, 0)
};

foreach (Point p in points) Console.WriteLine($"({p.X}, {p.Y})");

/*
 * I decided to make the X and Y properties immutable because in my opinion
 * a Point is a fixed position. If we want to move it it's cheap to simply
 * create a new Point instance.
 */