using FountainOfObjects;

Console.WriteLine("""
                  Pick the map size:
                  1) Small
                  2) Medium
                  3) Large
                  """
);

int userChoice = Helpers.GetIntBetween(1, 3, ">");

Map map = userChoice switch
{
    1 => MapBuilder.GenerateSmallMap(),
    2 => MapBuilder.GenerateMediumMap(),
    _ => MapBuilder.GenerateLargeMap()
};

new Game(map).Run();