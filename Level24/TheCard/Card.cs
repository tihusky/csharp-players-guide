namespace TheCard;

public enum Color
{
    Red = 0,
    Green,
    Blue,
    Yellow
}

public enum Rank
{
    One = 0,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Caret,
    Ampersand
}

public class Card
{
    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }

    public Color Color { get; }
    public Rank Rank { get; }

    public bool IsFaceCard
    {
        get
        {
            switch (Rank)
            {
                case Rank.Dollar:
                case Rank.Percent:
                case Rank.Caret:
                case Rank.Ampersand:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool IsNumberCard => !IsFaceCard;
}