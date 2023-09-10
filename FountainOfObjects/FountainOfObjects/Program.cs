using FountainOfObjects;

int GetIntBetween(int min, int max, string prompt)
{
    while (true)
    {
        Console.Write($"{prompt} ");
        bool isNumber = int.TryParse(Console.ReadLine(), out int number);

        if (isNumber && number >= min && number <= max)
        {
            return number;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input.");
        Console.ResetColor();
    }
}

Console.WriteLine("""
                  Pick the map size:
                  1) Small
                  2) Medium
                  3) Large
                  """
);

int userChoice = GetIntBetween(1, 3, ">");

Map map = userChoice switch
{
    1 => MapBuilder.GenerateSmallMap(),
    2 => MapBuilder.GenerateMediumMap(),
    _ => MapBuilder.GenerateLargeMap()
};

new Game(map).Run();