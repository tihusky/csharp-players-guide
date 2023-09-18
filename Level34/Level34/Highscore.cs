namespace Level34;

internal class Highscore
{
    public string Name { get; }
    public int Points { get; }
    public int Level { get; }

    public Highscore(string name, int points, int level)
    {
        Name = name;
        Points = points;
        Level = level;
    }

    public void Deconstruct(out string name, out int points)
    {
        name = Name;
        points = Points;
    }

    public void Deconstruct(out string name, out int points, out int level)
    {
        Deconstruct(out name, out points);
        level = Level;
    }
}
