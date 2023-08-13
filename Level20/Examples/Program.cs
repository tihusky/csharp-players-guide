var rect = new Rectangle(3, 5);

Console.WriteLine(
    $"A rectangle with a width of {rect.Width} and a height of {rect.Height} has an area of {rect.Area}."
);

// Can't be changed after creation of the Rectangle object because the auto properties don't have a setter
// rect.Width = 6;
// rect.Height = 8;

// Console.WriteLine(
//     $"A rectangle with a width of {rect.Width} and a height of {rect.Height} has an area of {rect.Area}."
// );

var circle1 = new Circle();

Console.WriteLine($"Created Circle with X: {circle1.X} Y: {circle1.Y} Radius: {circle1.Radius}");

// Object initializer overwrites values set in the constructor
var circle2 = new Circle { X = -2.5f, Y = 10.0f, Radius = 7.5f };

Console.WriteLine($"Created Circle with X: {circle2.X} Y: {circle2.Y} Radius: {circle2.Radius}");

public class Rectangle {
    public float Width { get; init; }
    public float Height { get; init;  }
    public float Area { get; }

    public Rectangle(float width, float height) {
        Width = width;
        Height = height;
        
        Area = Width * Height;
    }
}

public class Circle {
    public float X { get; init; }
    public float Y { get; init; }
    public float Radius { get; init; }
    
    public Circle(): this(0.0f, 0.0f, 0.0f) {}

    public Circle(float x, float y, float radius) {
        // These values are set BEFORE any possible new values are assigned through the object initializer!
        X = x;
        Y = y;
        Radius = radius;
    }
}