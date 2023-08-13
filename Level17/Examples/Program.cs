void DisplayScore((string Name, int Points, int Level) score) {
    Console.WriteLine($"Name: {score.Name} Points: {score.Points} Level: {score.Level}");
}

void TupleCreation() {
    var score1 = (Name: "R2-D2", Points: 14250, Level: 15);
    var score2 = ("C-3PO", 8543, 9);

    // Item names in this tuple are Item1, P and L - not Name, Points and Level!
    (string, int P, int L) score3 = (Name: "GONK", Points: -1, Level: 1);

    DisplayScore(score1);
    DisplayScore(score2);
    DisplayScore(score3);

    // Nesting a tuple inside another tuple
    var score4 = (Name: "Dex", (Points: 13100, Level: 13));

    Console.WriteLine($"Name: {score4.Name}, Points: {score4.Item2.Points}, Level: {score4.Item2.Level}");
}

void TupleDeconstruction() {
    var coords1 = (21.75, -13.5);
    
    // Declaring variables and deconstructing tuple on separate lines
    double x1;
    double y1;

    (x1, y1) = coords1;
    
    Console.WriteLine($"x1: {x1} y1: {y1}");

    var coords2 = (15.45, 9.25);
    
    // Declaring variables and deconstructing tuple on one line
    (double x2, double y2) = coords2;
    
    Console.WriteLine($"x2: {x2}, y2: {y2}");
    
    var name = (First: "Mirko", Middle: "Empty", Last: "Förster");
    
    // Discarding one element of the tuple while deconstructing
    (string firstName, _, string lastName) = name;
    
    Console.WriteLine($"{firstName} {lastName}");
}

TupleDeconstruction();