Test2();

static void Test1()
{
    DisplayArrayContents<string?>(new [] { null, null, "Hi", "there!", null, null }, DisplayVertically);

    void DisplayArrayContents<T>(T[] arr, DisplayFunction fn)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            DisplayVertically(i, arr[i]);
        }
    }
}

static void Test2()
{
    var displayer = new DataDisplayer<int>(
        new [] { 100, 200, 300, 400, 500, 600, 700, 800, 900 }
    );

    displayer.SetDisplayFunction(DisplayVertically);
    // displayer.SetDisplayFunction(DisplayHorizontally);

    try
    {
        displayer.Display();
    }
    catch (InvalidOperationException e)
    {
        DisplayError(e.Message);
    }
}

static void DisplayHorizontally(int index, object? value)
{
    if (value == null) return;

    Console.Write($"{value} ");
}

static void DisplayVertically(int index, object? value)
{
    Console.WriteLine($"[{index}] {value}");
}

static void DisplayError(string message)
{
    Console.Write("[");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("ERROR");
    Console.ResetColor();
    Console.Write("] ");
    Console.WriteLine(message);
}

/***** Type Definitions *****/

internal delegate void DisplayFunction(int index, object? value);

internal class DataDisplayer<T>
{
    private readonly T[] _data;
    private DisplayFunction? _displayFn;

    public DataDisplayer(T[] data)
    {
        _data = data;
    }

    public void Display()
    {
        if (_displayFn == null)
            throw new InvalidOperationException("No display function set.");

        for (int i = 0; i < _data.Length; i++)
        {
            _displayFn?.Invoke(i, _data[i]);
        }
    }

    public void SetDisplayFunction(DisplayFunction fn)
    {
        _displayFn = fn;
    }
}