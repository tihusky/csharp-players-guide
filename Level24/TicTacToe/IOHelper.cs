namespace TicTacToe;

public static class IoHelper
{
    public static void WriteLineColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}