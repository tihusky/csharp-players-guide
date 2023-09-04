Level30.List<T> Repeat<T>(T value, int times)
{
    var items = new Level30.List<T>();

    for (int i = 0; i < times; i++)
    {
        items.Add(value);
    }

    return items;
}

var numbers = new Level30.List<int>();

numbers.Add(4);
numbers.Add(2);
numbers.Add(13);

for (int index = 0; index < numbers.Length; index++)
{
    Console.WriteLine(numbers.GetItemAt(index));
}

// var strings = Repeat<string>("Hi there!", 5);

// The compiler can infer the concrete type to be used from the argument passed
// in to the generic function, so the generic type argument isn't required.
var strings = Repeat("Hi there!", 5);

for (int index = 0; index < strings.Length; index++)
{
    Console.WriteLine(strings.GetItemAt(index));
}

/***** Type Definitions *****/

namespace Level30
{
    public class List<T>
    {
        private T[] _items = Array.Empty<T>();

        public void SetItemAt(int index, T value)
        {
            if (index < 0 || index >= _items.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            _items[index] = value;
        }
        
        public T GetItemAt(int index)
        {
            if (index < 0 || index >= _items.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _items[index];
        }

        public int Length => _items.Length;

        public void Add(T value)
        {
            T[] newItems = new T[_items.Length + 1];

            for (int index = 0; index < _items.Length; index++)
            {
                newItems[index] = _items[index];
            }

            newItems[^1] = value;

            _items = newItems;
        }
    }
}