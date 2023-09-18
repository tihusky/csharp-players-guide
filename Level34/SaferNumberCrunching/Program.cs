static int GetInt()
{
    while (true)
    {
        Console.Write("Enter an integer: ");

        bool isInteger = int.TryParse(Console.ReadLine(), out int number);

        if (isInteger)
            return number;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That's not an integer.");
        Console.ResetColor();
    }
}

static double GetDouble()
{
    while (true)
    {
        Console.Write("Enter a floating point number: ");

        bool isDouble = double.TryParse(Console.ReadLine(), out double number);

        if (isDouble)
            return number;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That's not a floating point number.");
        Console.ResetColor();
    }
}

static bool GetBool()
{
    while (true)
    {
        Console.Write("Enter a boolean value: ");

        bool isBool = bool.TryParse(Console.ReadLine(), out bool boolean);

        if (isBool)
            return boolean;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That's not a boolean value.");
        Console.ResetColor();
    }
}

int integer = GetInt();
double floatingPoint = GetDouble();
bool boolean = GetBool();

Console.WriteLine($"\nInteger: {integer}");
Console.WriteLine($"Double: {floatingPoint}");
Console.WriteLine($"Boolean: {boolean}");