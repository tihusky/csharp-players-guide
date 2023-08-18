namespace TheLockedDoor;

public enum DoorState {
    Open,
    Closed,
    Locked
}

public class Door {
    private string _passcode;

    public DoorState State { get; private set; } = DoorState.Open;

    public Door(string passcode) {
        _passcode = passcode;
    }

    public void Open() {
        if (State == DoorState.Closed) State = DoorState.Open;
    }

    public void Close() {
        if (State == DoorState.Open) State = DoorState.Closed;
    }

    public void Lock() {
        if (State == DoorState.Closed) State = DoorState.Locked;
    }

    public void Unlock(string passcode) {
        if (State == DoorState.Locked && passcode == _passcode) State = DoorState.Closed;
    }

    public bool SetPasscode(string currentCode, string newCode) {
        if (currentCode != _passcode) return false;

        _passcode = newCode;

        return true;
    }
}