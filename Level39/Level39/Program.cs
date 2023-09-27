void Test1()
{
    if (!File.Exists("Scores.csv"))
    {
        List<Score> scores = new()
    {
        new Score("Mirko", 19482, 17),
        new Score("R2-D2", 12420, 15),
        new Score("C3P0", 8543, 9),
        new Score("GONK", -1, 1)
    };

        SaveScores(scores);
    }
    else
    {
        List<Score> scores = LoadScores();

        DisplayScores(scores);
    }
}

void SaveScores(List<Score> scores)
{
    // Start with an empty file every time
    File.Delete("Scores.csv");

    StreamWriter writer = File.AppendText("Scores.csv");

    foreach (Score s in scores)
        writer.WriteLine(s.CsvString);

    writer.Close();
}

List<Score> LoadScores()
{
    List<Score> scores = new();

    if (!File.Exists("Scores.csv")) 
        return scores;

    string[] lines = File.ReadAllLines("Scores.csv");

    foreach (string line in lines)
    {
        string[] tokens = line.Split(',');

        scores.Add(new Score(
            tokens[0],
            Convert.ToInt32(tokens[1]),
            Convert.ToInt32(tokens[2])
        ));
    }

    return scores;
}

void DisplayScores(List<Score> scores)
{
    foreach (Score s in scores)
        Console.WriteLine($"{s.Name, -8} {s.Points, 6} {s.Level, 3}");
}

void Test2()
{
    try
    {
        Directory.CreateDirectory("Testdata");
    }
    catch (UnauthorizedAccessException)
    {
        WriteColored("ERROR ", ConsoleColor.Red);
        Console.WriteLine("No permission to create the directory.");
    }

    try
    {
        File.Create(@"Testdata\Test1.txt");
        File.Create(@"Testdata\Test2.txt");
        File.Create(@"Testdata\AwesomePicture.png");
    }
    catch (UnauthorizedAccessException)
    {
        WriteColored("ERROR ", ConsoleColor.Red);
        Console.WriteLine("No permission to create the files.");
    }

    var dirInfo = new DirectoryInfo("Testdata");

    if (dirInfo.Exists)
    {
        Console.Write("Files in the ");
        WriteColored(dirInfo.Name, ConsoleColor.DarkCyan);
        Console.WriteLine(" folder");

        foreach (string filePath in Directory.EnumerateFiles("Testdata"))
        {
            var fileInfo = new FileInfo(filePath);
            Console.WriteLine(fileInfo.Name);
        }
    }
    else
    {
        WriteColored("ERROR ", ConsoleColor.Red);
        Console.WriteLine("The directory doesn't exist!");
    }

    void WriteColored(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
}

Test2();

/***** Type Definitions *****/

public class Score
{
    public string Name { get; }
    public int Points { get; }
    public int Level { get; }

    public Score(string name, int points, int level)
    {
        Name = name;
        Points = points;
        Level = level;
    }

    public string CsvString => $"{Name},{Points},{Level}";
}