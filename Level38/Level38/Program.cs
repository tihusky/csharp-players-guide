var cart = new ShoppingCart();

cart.AddItem(new Item("Grapes", 500));
cart.AddItem(new Item("Peaches", 1000));
cart.AddItem(new Item("Chocolate", 100));
cart.AddItem(new Item("Gummibears", 250));

// Use a lambda expression that returns true if the item starts with g or G
var filteredItems = cart.Filter(item => item.Name.StartsWith('g') || item.Name.StartsWith('G'));

Console.WriteLine("Items that start with 'g' or 'G'");
Console.WriteLine("==========================================");

foreach (Item item in filteredItems)
    Console.WriteLine($"- {item.Name}");

// Use a lambda expression that returns true if an item weighs 500 or more grams
filteredItems = cart.Filter(item => item.Weight >= 500);

Console.WriteLine();
Console.WriteLine("Items that weigh 500 grams or more");
Console.WriteLine("==========================================");

foreach (Item item in filteredItems)
    Console.WriteLine($"- {item.Name}");

/***** Type Definitions *****/

public class ShoppingCart
{
    private List<Item> _items = new();

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    // Predicate<Item> accepts an Item and returns a bool
    public List<Item> Filter(Predicate<Item> filterFn)
    {
        List<Item> filtered = new();

        foreach (Item item in _items)
            if (filterFn(item)) filtered.Add(item);

        return filtered;
    }
}

public class Item
{
    public string Name { get; }
    public int Weight { get; }

    public Item(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }
}