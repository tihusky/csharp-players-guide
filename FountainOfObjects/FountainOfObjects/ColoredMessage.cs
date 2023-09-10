namespace FountainOfObjects;

internal struct ColoredMessage
{
    public ConsoleColor Color { get; }
    public string Message { get; }

    public ColoredMessage(ConsoleColor color, string message)
    {
        Color = color;
        Message = message;
    }
}