using TheCard;

int colorCount = Enum.GetNames<Color>().Length;
int rankCount = Enum.GetNames<Rank>().Length;
var cards = new Card[colorCount * rankCount];
var currentIndex = 0;

for (var colorIndex = 0; colorIndex < colorCount; colorIndex++) {
    for (var rankIndex = 0; rankIndex < rankCount; rankIndex++) {
        cards[currentIndex] = new Card((Color)colorIndex, (Rank)rankIndex);

        currentIndex++;
    }
}

foreach (Card card in cards) {
    Console.WriteLine($"The {card.Color} {card.Rank}");
}