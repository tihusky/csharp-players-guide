void DisplayScore(Score score) {
    Console.WriteLine($"{score.Name} reached level {score.Level} with {score.Points} points.");
    Console.WriteLine("This means they " + (score.EarnedStar() ?  "have" : "have not") + " earned a star.");
}

var scores = new List<Score>() {
    new Score("R2-D2", 14350, 13),
    new Score("C-3PO", 8543, 9),
    new Score()
};

foreach (var score in scores) {
    DisplayScore(score);
}

class Score {
    public string Name;
    public int Points;
    public int Level;

    public Score(): this("Unknown", 0, 1) {}
    
    public Score(string name, int points, int level) {
        Name = name;
        Points = points;
        Level = level;
    }

    public bool EarnedStar() => (Points / Level) > 1000;
}