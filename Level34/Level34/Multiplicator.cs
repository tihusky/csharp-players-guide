namespace Level34;

internal class Multiplicator
{
    public Multiplicator(int multiplier)
    {
        Multiplier = multiplier;
    }

    public int Multiplier { get; }

    public int[] MultiplyAll(params int[] numbers)
    {
        int[] results = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            results[i] = numbers[i] * Multiplier;
        }

        return results;
    }

    public void MultiplyInPlace(ref int number)
    {
        number *= Multiplier;
    }
}
