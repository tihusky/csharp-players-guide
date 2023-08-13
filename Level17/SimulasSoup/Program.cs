using SimulasSoup;

int GetIntegerBetween(int min, int max, string prompt = ">") {
    while (true) {
        Console.Write(prompt + " ");
        bool isParseable = int.TryParse(Console.ReadLine(), out int number);

        if (isParseable && number >= min && number <= max)
            return number;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input.");
        Console.ResetColor();
    }
}

(RecipeType RecipeType, MainIngredient MainIngredient, Seasoning Seasoning) recipe;

int userSelection = GetIntegerBetween(1, 3, @"Pick the recipe type:
1) Soup
2) Stew
3) Gumbo
>");

recipe.RecipeType = userSelection switch {
    1 => RecipeType.Soup,
    2 => RecipeType.Stew,
    _ => RecipeType.Gumbo
};

Console.Clear();

userSelection = GetIntegerBetween(1, 4, @"Pick the main ingredient:
1) Mushroom
2) Chicken
3) Carrot
4) Potato
>");

recipe.MainIngredient = userSelection switch {
    1 => MainIngredient.Mushroom,
    2 => MainIngredient.Chicken,
    3 => MainIngredient.Carrot,
    _ => MainIngredient.Potato
};

Console.Clear();

userSelection = GetIntegerBetween(1, 3, @"Pick the seasoning:
1) Spicy
2) Salty
3) Sweet
>");

recipe.Seasoning = userSelection switch {
    1 => Seasoning.Spicy,
    2 => Seasoning.Salty,
    _ => Seasoning.Sweet
};

Console.WriteLine($"{recipe.Seasoning} {recipe.MainIngredient} {recipe.RecipeType}");

/********** Type Definitions **********/

namespace SimulasSoup {
    public enum RecipeType {
        Soup,
        Stew,
        Gumbo
    }

    public enum MainIngredient {
        Mushroom,
        Chicken,
        Carrot,
        Potato
    }

    public enum Seasoning {
        Spicy,
        Salty,
        Sweet
    }
}