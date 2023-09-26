Console.WriteLine("""
                  Select a filter from the list:
                  1) Even Numbers
                  2) Positive Numbers
                  3) Multiples of 10
                  """);

int userSelection = GetIntBetween(1, 3, ">");

Sieve sieve = userSelection switch
{
    1 => new Sieve(number => number % 2 == 0),
    2 => new Sieve(number => number > 0),
    3 => new Sieve(number => number % 10 == 0)
};

Console.Clear();

while (true)
{
    int number = GetInt("Enter a number:");

    if (sieve.IsGood(number))
        WriteLineColored($"The number {number} is good.", ConsoleColor.Green);
    else
        WriteLineColored($"The number {number} is bad.", ConsoleColor.Red);
}

int GetInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt + " ");

        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            WriteLineColored("The input must be numeric.", ConsoleColor.Red);
        }
        catch (OverflowException)
        {
            WriteLineColored("Number is too large or too small.", ConsoleColor.Red);
        }
    }
}


int GetIntBetween(int min, int max, string prompt)
{
    while (true)
    {
        int number = GetInt(prompt);

        if (number >= min && number <= max)
            return number;

        WriteLineColored($"Number must be between {min} and {max}.", ConsoleColor.Red);
    }
}

void WriteLineColored(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

/***** Type Definitions *****/

public delegate bool FilterFunc(int number);

public class Sieve
{
    private FilterFunc _filter;

    public Sieve(FilterFunc fn)
    {
        _filter = fn;
    }

    public bool IsGood(int number) => _filter(number);
}

// I could have solved this problem by creating an abstract Sieve class
// and derive three classes from it where each class implements the IsGood
// method in its own way.
// I like the modularity the approach with using delegates offers. First of
// all I don't have to define a new class and derive it from the Sieve class
// whenever I want to add a new filter, and the filter functions can also be
// used if different contexts.