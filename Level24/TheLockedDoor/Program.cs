using TheLockedDoor;

string ReadPasscode(string prompt) {
    while (true) {
        string? passcode = ConsoleHelper.GetString(prompt);

        if (!string.IsNullOrEmpty(passcode)) {
            return passcode;
        }

        ConsoleHelper.WriteLineColored(ConsoleColor.Red, "Passcode can't be empty.");
    }
}

string passcode = ReadPasscode("Enter initial passcode:");
var door = new Door(passcode);

while (true) {
    string? command = ConsoleHelper.GetString($"The door is {door.State}. What do you want to do?");

    switch (command) {
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "lock":
            door.Lock();
            break;
        case "unlock":
        {
            if (door.State == DoorState.Locked) {
                door.Unlock(ReadPasscode("Enter current passcode:"));
            }
            
            break;
        }
        case "setpasscode":
        {
            string currentCode = ReadPasscode("Enter current passcode:");
            string newCode = ReadPasscode("Enter new passcode:");

            if (door.SetPasscode(currentCode, newCode)) {
                ConsoleHelper.WriteLineColored(ConsoleColor.Green, "Passcode changed.");
            }
            else {
                ConsoleHelper.WriteLineColored(ConsoleColor.Red, "Invalid passcode.");
            }

            break;
        }
        default:
            ConsoleHelper.WriteLineColored(ConsoleColor.Red, "Invalid command.");
            break;
    }
}