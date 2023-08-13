using VinFletchersArrows;

int GetIntBetween(int min, int max, string prompt = ">") {
    while (true) {
        Console.Write(prompt + " ");

        bool isParseable = int.TryParse(Console.ReadLine(), out int number);

        if (isParseable && number >= min && number <= max)
            return number;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input.");
        Console.ResetColor();
    }
}

Arrowhead GetArrowhead() {
    int userSelection = GetIntBetween(1, 3, @"Pick the arrowhead type:
1) Steel
2) Wood
3) Obsidian
>");

    return userSelection switch {
        1 => Arrowhead.Steel,
        2 => Arrowhead.Wood,
        _ => Arrowhead.Obsidian
    };
}

Fletching GetFletching() {
    int userSelection = GetIntBetween(1, 3, @"Pick the fletching type:
1) Plastic
2) Turkey Feathers
3) Goose Feathers
>");

    return userSelection switch {
        1 => Fletching.Plastic,
        2 => Fletching.TurkeyFeathers,
        _ => Fletching.GooseFeathers
    };
}

Arrowhead arrowhead = GetArrowhead();
Console.Clear();

Fletching fletching = GetFletching();
Console.Clear();

int length = GetIntBetween(60, 100, "Enter arrow length (60 to 100 cm):");

var arrow = new Arrow(arrowhead, fletching, length);

Console.WriteLine($"The price of this arrow will be {arrow.GetCost()} gold.");

/********** Type Definitions **********/

namespace VinFletchersArrows {
    enum Arrowhead {
        Steel,
        Wood,
        Obsidian
    }

    enum Fletching {
        Plastic,
        TurkeyFeathers,
        GooseFeathers
    }

    class Arrow {
        private readonly Arrowhead _arrowhead;
        private readonly Fletching _fletching;
        private readonly int _length;

        public Arrow(Arrowhead arrowhead, Fletching fletching, int length) {
            _arrowhead = arrowhead;
            _fletching = fletching;
            _length = length;
        }

        public Arrowhead GetArrowhead() => _arrowhead;
        public Fletching GetFletching() => _fletching;
        public int GetLength() => _length;

        public float GetCost() {
            const float costPerCm = 0.05f;
            float totalCost = 0.0f;

            // Add cost for the arrowhead
            totalCost += _arrowhead switch {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5,
                _ => 0
            };

            // Add cost for the fletching
            totalCost += _fletching switch {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3,
                _ => 0
            };

            totalCost += (_length * costPerCm);

            return totalCost;
        }
    }
}