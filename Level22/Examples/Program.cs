Console.Write("Enter your name: ");
string? name = Console.ReadLine()?.Trim();

if (string.IsNullOrEmpty(name)) {
    name = "Anonymous";
}

Console.WriteLine($"Hey there, {name}!");