Sword basicSword = new Sword(Material.Iron, Gemstone.None, 85.0f, 24.0f);
Sword trainingSword = basicSword with { Material = Material.Wood, Length = 65.0f, CrossguardWidth = 20.0f };
Sword legendarySword = basicSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };

Console.WriteLine(basicSword);
Console.WriteLine(trainingSword);
Console.WriteLine(legendarySword);

/***** Type Definitions *****/

public enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

public enum Gemstone
{
    None,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone
}

public record Sword(Material Material, Gemstone Gemstone, float Length, float CrossguardWidth);