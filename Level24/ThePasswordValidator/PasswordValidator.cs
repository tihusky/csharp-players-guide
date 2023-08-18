namespace ThePasswordValidator;

public static class PasswordValidator
{
    private static readonly char[] ForbiddenChars = { 'T', '&' };
    private static string _password = "";

    public static bool IsValid(string password)
    {
        _password = password;

        if (_password.Length < 6 || _password.Length > 13) return false;

        return HasLowercaseLetter() && HasUppercaseLetter() && HasNumber() && !HasForbiddenChar();
    }

    private static bool HasLowercaseLetter()
    {
        foreach (char ch in _password)
        {
            if (char.IsLower(ch)) return true;
        }

        return false;
    }

    private static bool HasUppercaseLetter()
    {
        foreach (char ch in _password)
        {
            if (char.IsUpper(ch)) return true;
        }

        return false;
    }

    private static bool HasNumber()
    {
        foreach (char ch in _password)
        {
            if (char.IsNumber(ch)) return true;
        }

        return false;
    }

    private static bool HasForbiddenChar()
    {
        foreach (char ch in _password)
        {
            if (ForbiddenChars.Contains(ch)) return true;
        }

        return false;
    }
}