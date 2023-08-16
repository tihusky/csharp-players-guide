namespace TheColor; 

public class RgbColor {
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    
    public RgbColor(byte r, byte g, byte b) {
        R = r;
        G = g;
        B = b;
    }

    public static RgbColor Black => new RgbColor(0, 0, 0);
    public static RgbColor White => new RgbColor(255, 255, 255);
    public static RgbColor Red => new RgbColor(255, 0, 0);
    public static RgbColor Orange => new RgbColor(255, 165, 0);
    public static RgbColor Yellow => new RgbColor(255, 255, 0);
    public static RgbColor Green => new RgbColor(0, 255, 0);
    public static RgbColor Blue => new RgbColor(0, 0, 255);
    public static RgbColor Purple => new RgbColor(128, 0, 128);
}