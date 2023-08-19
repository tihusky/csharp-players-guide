namespace TheColor;

public class RgbColor
{
    public RgbColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public static RgbColor Black => new(0, 0, 0);
    public static RgbColor White => new(255, 255, 255);
    public static RgbColor Red => new(255, 0, 0);
    public static RgbColor Orange => new(255, 165, 0);
    public static RgbColor Yellow => new(255, 255, 0);
    public static RgbColor Green => new(0, 255, 0);
    public static RgbColor Blue => new(0, 0, 255);
    public static RgbColor Purple => new(128, 0, 128);
}