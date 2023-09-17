using Level34;

void Test1()
{
    Console.WriteLine("Rolling a default 6-sided die once: " + Die.Roll()[0]);
}


void Test2()
{
    Console.Write("Rolling a default 6-sided die multiple times: ");

    int[] dieResults = Die.Roll(times: 10);

    foreach (int result in dieResults)
    {
        Console.Write(result + " ");
    }
}

void Test3()
{
    Console.WriteLine("Rolling a 20-sided die once: " + Die.Roll(sides: 20)[0]);
}

void Test4()
{
    var multiplicator = new Multiplicator(2);

    // This shows how to pass in separate arguments for a params parameter.
    var numbers = multiplicator.MultiplyAll(10, 20, 30, 40, 50);

    foreach (int number in numbers)
    {
        Console.Write(number + " ");
    }

    Console.WriteLine();
}

void Test5()
{
    var multiplicator = new Multiplicator(3);

    // This shows that we can also pass in an array for a params parameter.
    var numbers = new int[] { 10, 20, 30, 40, 50 };
    var results = multiplicator.MultiplyAll(numbers);

    for (int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine($"{numbers[i]} * {multiplicator.Multiplier} = {results[i]}");
    }
}

void Test6()
{
    var multiplicator = new Multiplicator(2);
    var number = 21;

    Console.WriteLine("number: " + number);
    multiplicator.MultiplyInPlace(ref number);
    Console.WriteLine("number: " + number);
}

Test6();