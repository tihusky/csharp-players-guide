void Test1()
{
    object thing = new object();

    Console.WriteLine(thing);

    object a = new object();
    object b = a;
    object c = new object();

    Console.WriteLine(a.Equals(b));
    Console.WriteLine(a.Equals(c));

    Point p1 = new Point(4, 2);
    Point p2 = p1;

    Console.WriteLine(p1.ToString());
    Console.WriteLine(p1.Equals(p2));

    object p3 = new Point(2, 4);

    Console.WriteLine(p3.ToString());

    // Because the compiler only knows p3 holds an object, more specific members from the Point class can't be accessed
    // Console.WriteLine(p3.X);
}

void Test2()
{
    GameObject thing = new Asteroid();
    
    // Even though we can see this code is wrong the compiler allows it. It will lead to a crash!
    var playerShip = (Ship)thing;
}

void Test3()
{
    GameObject thing = new Ship();

    if (thing.GetType() == typeof(Ship))
    {
        ((Ship)thing).Shoot();
    }

    Asteroid? asteroid = thing as Asteroid;

    if (asteroid == null)
    {
        Console.WriteLine("The thing variable doesn't hold an Asteroid object.");
    }

    if (thing is Ship playerShip)
    {
        Console.WriteLine($"The player's health is {playerShip.Health}.");
    }
}

Test3();

/* Type Definitions */

public class Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
}

public class GameObject
{
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }
    
    public GameObject()
    {
        Console.WriteLine("In the GameObject() constructor");
    }

    public GameObject(float positionX, float positionY)
    {
        Console.WriteLine("In the GameObject(float, float) constructor");
        
        PositionX = positionX;
        PositionY = positionY;
    }

    public void Update()
    {
        PositionX += VelocityX;
        PositionY += VelocityY;
    }
}

public class Asteroid : GameObject
{
    public int Size { get; }
    public float RotationAngle { get; }

    public Asteroid()
    {
        Console.WriteLine("In the Asteroid() constructor");
    }

    public Asteroid(int size, float rotationAngle)
    {
        Console.WriteLine("In the Asteroid(int, float) constructor");
        
        Size = size;
        RotationAngle = rotationAngle;
    }
}

public class Ship : GameObject
{
    public int Health { get; set; }

    public Ship() : this(100)
    {
        Console.WriteLine("In the Ship() constructor");
    }
    
    public Ship(int health)
    {
        Console.WriteLine("In the Ship(int) constructor");
        
        Health = health;
    }

    public void Shoot()
    {
        Console.WriteLine("The player has fired a shot.");
    }
}