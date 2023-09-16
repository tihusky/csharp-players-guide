namespace FountainOfObjects.PlayerActions;

internal struct ActionResult
{
    public bool Success { get; init; }
    public string? Message { get; init; }

    public bool HasMessage => !string.IsNullOrEmpty(Message);
}