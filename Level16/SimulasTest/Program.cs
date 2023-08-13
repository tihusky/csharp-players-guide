using SimulasTest;

string GetChestStateString(ChestState state) {
    switch (state) {
        case ChestState.Open:
            return "The chest is open.";
        case ChestState.Closed:
            return "The chest is unlocked.";
        case ChestState.Locked:
            return "The chest is locked.";
        default:
            return "The chest state is invalid.";
    }
}

while (true) {
    ChestState state = ChestState.Closed;
    string userAction;

    while (true) {
        Console.Write(GetChestStateString(state) + " ");
        Console.Write("What do you want to do? ");
        userAction = Console.ReadLine().ToLower();

        switch (state) {
            case ChestState.Open:
                if (userAction == "close")
                    state = ChestState.Closed;
                break;
            case ChestState.Closed:
                if (userAction == "open")
                    state = ChestState.Open;
                else if (userAction == "lock")
                    state = ChestState.Locked;
                break;
            case ChestState.Locked:
                if (userAction == "unlock")
                    state = ChestState.Closed;
                break;
        }
    }
}

namespace SimulasTest {
    public enum ChestState {
        Open,
        Closed,
        Locked
    }
}