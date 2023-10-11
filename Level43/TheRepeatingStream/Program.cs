var recentNumbers = new RecentNumbers();
var thread = new Thread(GenerateNumber);

thread.Start(recentNumbers);

while (true)
{
    Console.ReadKey();
    
    if (recentNumbers.Current == recentNumbers.Previous)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("CORRECT");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("WRONG");
        Console.ResetColor();
    }
}

void GenerateNumber(object? obj)
{
    if (obj is RecentNumbers nums)
    {
        var random = new Random();

        while (true)
        {
            nums.Previous = nums.Current;
            nums.Current = random.Next(10);

            Console.Clear();
            Console.WriteLine("Previous: " + nums.Previous);
            Console.WriteLine("Current: " + nums.Current);

            // Yield remaining time and wait
            Thread.Sleep(1000);
        }
    }
}

public class RecentNumbers
{
    private int _previous;
    private int _current;

    public int Previous 
    {
        get
        {
            lock (this)
            {
                return _previous;
            }
        }

        set
        {
            lock (this)
            {
                _previous = value;
            }
        }
    }

    public int Current
    {
        get
        {
            lock (this)
            {
                return _current;
            }
        }

        set
        {
            lock (this)
            {
                _current = value;
            }
        }
    }
}