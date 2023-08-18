using ThePasswordValidator;

void WriteLineColored(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

while (true) 
{
    Console.Write("Enter your password: ");
    string password = Console.ReadLine() ?? "";

    if (PasswordValidator.IsValid(password))
    {
        WriteLineColored(ConsoleColor.Green, "The password is valid.");
    }
    else
    {
        WriteLineColored(ConsoleColor.Red, "The password is invalid.");
    }
}