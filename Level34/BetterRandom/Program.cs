using BetterRandom;

var rng = new Random();
var number = rng.NextDouble(8.5);
var greeting = rng.NextString("Hey!", "Hello!", "Howdy!", "Hi!", "Hola!");

Console.WriteLine(number);
Console.WriteLine(greeting);

if (rng.CoinFlip())
    Console.WriteLine("Heads!");
else
    Console.WriteLine("Tails!");