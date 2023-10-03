namespace Level41;

public class ShoppingCart
{
    private readonly List<string> _items = new();

    public int ItemCount => _items.Count;

    // Example of an indexer
    public string this[Index index]
    {
        get
        {
            if (index.Value >= ItemCount) 
                throw new IndexOutOfRangeException();

            return _items[index];
        }
        set
        {
            if (index.Value >= ItemCount)
                throw new IndexOutOfRangeException();

            _items[index] = value;
        }
    }

    public void Add(string item)
    {
        _items.Add(item);
    }
}
