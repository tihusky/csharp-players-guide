namespace BetterRandom;

internal static class RandomExtensions
{
    /// <summary>
    ///  Generates a random floating point number greater than 0.0 and less than maxValue.
    /// </summary>
    public static double NextDouble(this Random rng, double maxValue)
    {
        return rng.NextDouble() * maxValue;
    }

    /// <summary>
    /// Randomly picks a string from the given strings. Every string has the same chance
    /// of being picked.
    /// </summary>
    public static string NextString(this Random rng, params string[] strings)
    {
        if (strings.Length == 0) return "";

        int index = rng.Next(strings.Length);

        return strings[index];
    }

    /// <summary>
    /// Flips a coin. By default heads and tails have the same chance of coming up but the
    /// headsProbability parameter allows to control this behaviour.
    /// </summary>
    /// <param name="rng"></param>
    /// <param name="headsProbability">
    /// The chance of heads coming up, with the default of 0.5 meaning it has a 50% chance.
    /// </param>
    /// <returns>
    /// True if heads, False if tails.
    /// </returns>
    public static bool CoinFlip(this Random rng, double headsProbability = 0.5)
    {
        return rng.NextDouble() <= headsProbability;
    }
}
