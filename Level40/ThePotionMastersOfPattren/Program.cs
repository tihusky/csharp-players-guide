while (true)
{
    PotionType potion = PotionType.Water;

    while (potion is not PotionType.Ruined)
    {
        Console.Clear();
        Console.WriteLine("You currently have: " + potion);
        Console.WriteLine("""
            Do you want to add another ingredient?
            1) Yes
            2) No
            """);

        int userChoice = GetIntBetween(1, 2, ">");

        if (userChoice == 2)
            break;

        Console.Clear();
        Console.WriteLine("""
            Pick the ingredient you want to add:
            1) Stardust
            2) Snake Venom
            3) Dragon Breath
            4) Shadow Glass
            5) Eyeshine Gem
            """);

        userChoice = GetIntBetween(1, 5, ">");

        Ingredient ingredient = userChoice switch
        {
            1 => Ingredient.Stardust,
            2 => Ingredient.SnakeVenom,
            3 => Ingredient.DragonBreath,
            4 => Ingredient.ShadowGlass,
            _ => Ingredient.EyeshineGem
        };

        potion = (potion, ingredient) switch
        {
            (PotionType.Water, Ingredient.Stardust)                 => PotionType.Elixir,
            (PotionType.Elixir, Ingredient.SnakeVenom)              => PotionType.PoisonPotion,
            (PotionType.Elixir, Ingredient.DragonBreath)            => PotionType.FlyingPotion,
            (PotionType.Elixir, Ingredient.ShadowGlass)             => PotionType.InvisibilityPotion,
            (PotionType.Elixir, Ingredient.EyeshineGem)             => PotionType.NightSightPotion,
            (PotionType.NightSightPotion, Ingredient.ShadowGlass)   => PotionType.CloudyBrew,
            (PotionType.InvisibilityPotion, Ingredient.EyeshineGem) => PotionType.CloudyBrew,
            (PotionType.CloudyBrew, Ingredient.Stardust)            => PotionType.WraithPotion,
            _                                                       => PotionType.Ruined,
        };
    }

    Console.Clear();

    if (potion is PotionType.Ruined)
    {
        Console.WriteLine("You ruined the potion!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("You created the following potion: " + potion);
        break;
    }
}

int GetIntBetween(int min, int max, string prompt)
{
    while (true)
    {
        Console.Write(prompt + " ");
        bool isNumber = int.TryParse(Console.ReadLine(), out int number);

        if (isNumber && number >= min && number <= max)
            return number;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input.");
        Console.ResetColor();
    }
}

/***** Type Definitions *****/

public enum PotionType
{
    Water,
    Elixir,
    PoisonPotion,
    FlyingPotion,
    InvisibilityPotion,
    NightSightPotion,
    CloudyBrew,
    WraithPotion,
    Ruined
}

public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem
}