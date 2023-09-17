namespace Level34;

internal static class Die
{
    private static readonly Random _rng;

    static Die()
    {
        _rng = new Random();
    }


    /// <summary>
    /// Rolls a die with the given number of sides the given number of times.
    /// </summary>
    public static int[] Roll(int times = 1, int sides = 6)
    {
        int[] result = new int[times];

        for (int i = 0; i < times; i++)
        {
            result[i] = _rng.Next(sides) + 1;
        }

        return result;
    }
}
