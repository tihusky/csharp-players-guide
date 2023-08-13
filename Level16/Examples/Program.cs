using Enums;

var current = Season.Summer;
var another = (Season)42; // Not a valid season!

if (current == Season.Summer || current == Season.Winter)
    Console.WriteLine("Happy solstice!");
else
    Console.WriteLine("Happy equinox!");

Console.WriteLine(another);

namespace Enums {
    public enum Season {
        Winter,
        Spring,
        Summer,
        Fall
    }
}