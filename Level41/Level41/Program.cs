using Level41;

Test5();

void Test1()
{
    Point p1 = new(2, 8);
    Point p2 = new(1, 3);
    Point p3 = p1 + p2;

    Console.WriteLine($"{p1} + {p2} = {p3}");

    p1 = new Point(4, 2);
    p2 = p1 * 3;
    p3 = 5 * p1;

    Console.WriteLine($"{p1} * 3 = {p2}");
    Console.WriteLine($"5 * {p1} = {p3}");
}

void Test2()
{
    var cart = new ShoppingCart();

    cart.Add("Grapes");
    cart.Add("Blueberries");
    cart.Add("Milk");
    cart.Add("Bread");
    cart.Add("Chocolate");

    for (int i = 0; i < cart.ItemCount; i++)
        Console.WriteLine($"[{i + 1}] {cart[i]}");

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();

    cart[^1] = "Cheese";

    for (int i = 0; i < cart.ItemCount; i++)
        Console.WriteLine($"[{i + 1}] {cart[i]}");
}

void Test3()
{
    var map = new Map2D();

    Console.WriteLine($"The tile at (x: 1, y: 0) is {map[1, 0]}");
    Console.WriteLine($"The tile at (x: 3, y: 2) is {map[3, 2]}");
}

void Test4()
{
    var map = new Map2D(4, 4)
    {
        [1, 0] = TileType.Grass,
        [1, 1] = TileType.Grass,
        [1, 2] = TileType.Forest,
        [1, 3] = TileType.Grass
    };

    Console.WriteLine($"The tile at (x: 1, y: 2) is {map[1, 2]}");
}

void Test5()
{
    Point2 a = new Point2(4, 2);
    Point3 b = a;

    Console.WriteLine($"a.X: {a.X}, a.Y: {a.Y}");
    Console.WriteLine($"b.X: {b.X}, b.Y: {b.Y}, b.Z: {b.Z}");

    Point3 c = new Point3(1, 3, 5);
    Point2 d = (Point2)c;
}

/***** Type Definitions *****/

public record Point(double X, double Y)
{
    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator *(Point p, double scalar) => new Point(p.X * scalar, p.Y * scalar);
    public static Point operator *(double scalar, Point p) => p * scalar;

    public override string ToString() => $"({X}, {Y})";
}