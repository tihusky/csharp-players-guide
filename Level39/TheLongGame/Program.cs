Console.Write("Enter your name: ");
string? userName = Console.ReadLine();
string fileName = $"{userName}.txt";

int userScore = 0;

if (File.Exists(fileName))
{
    try
    {
        userScore = Convert.ToInt32(File.ReadAllText(fileName));
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nCouldn't restore the user's score.");
        Console.ResetColor();
    }
}

ConsoleKey pressedKey;

do
{
    Console.Clear();
    Console.WriteLine($"Current Score: {userScore}");
    Console.WriteLine("Press any key...");

    pressedKey = Console.ReadKey().Key;

    if (pressedKey != ConsoleKey.Enter)
        userScore++;
} while (pressedKey != ConsoleKey.Enter);

File.WriteAllText(fileName, userScore.ToString());