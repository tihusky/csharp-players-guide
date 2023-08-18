namespace RockPaperScissors;

public static class ConsoleHelper
{
    public static int GetIntBetween(int min, int max, string prompt)
    {
        while (true)
        {
            Console.Write(prompt + " ");
            bool isParseable = int.TryParse(Console.ReadLine(), out int number);

            if (isParseable && number >= min && number <= max)
            {
                return number;
            }
            
            WriteLineColored("Invalid input.", ConsoleColor.Red);
        }
    }

    public static void WriteLineColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}