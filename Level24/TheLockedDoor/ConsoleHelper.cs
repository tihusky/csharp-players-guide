namespace TheLockedDoor; 

public static class ConsoleHelper {
    public static string? GetString(string prompt) {
        Console.Write(prompt + " ");

        return Console.ReadLine()?.Trim();
    }

    public static void WriteLineColored(ConsoleColor color, string text) {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}