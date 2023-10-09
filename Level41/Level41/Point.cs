namespace Level41;

public class Point2
{
    public double X { get; }
    public double Y { get; }

    public Point2(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Going from Point3 to Point2 loses the Z component, so the cast must be done explicitly
    public static explicit operator Point2(Point3 p) => new Point2(p.X, p.Y);
}

public class Point3
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Point3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Going from Point2 to Point3 doesn't lose any data, so the cast can be done implicitly
    public static implicit operator Point3(Point2 p) => new Point3(p.X, p.Y, 0.0);
}