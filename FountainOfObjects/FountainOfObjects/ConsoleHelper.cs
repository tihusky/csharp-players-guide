namespace FountainOfObjects;

internal static class ConsoleHelper
{
    public static void WriteColoredMessage(ColoredMessage cm)
    {
        Console.ForegroundColor = cm.Color;
        Console.WriteLine(cm.Message);
        Console.ResetColor();
    }
}