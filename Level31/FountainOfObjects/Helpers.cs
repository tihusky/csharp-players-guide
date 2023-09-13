namespace FountainOfObjects;

internal static class Helpers
{
    public static void WriteColoredMessage(ColoredMessage cm)
    {
        Console.ForegroundColor = cm.Color;
        Console.WriteLine(cm.Message);
        Console.ResetColor();
    }
    
    public static int GetIntBetween(int min, int max, string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int number);

            if (isNumber && number >= min && number <= max)
            {
                return number;
            }

            Helpers.WriteColoredMessage(new ColoredMessage(ConsoleColor.Red, "Invalid input."));
        }
    }
}