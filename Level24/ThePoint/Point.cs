namespace ThePoint; 

public class Point {
    public float X { get; }
    public float Y { get; }

    public Point(): this(0.0f, 0.0f) {}
    
    public Point(float x, float y) {
        X = x;
        Y = y;
    }
}