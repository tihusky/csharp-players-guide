Test4();

void Test1()
{
    var t1 = new Thread(CountTo1000);
    var t2 = new Thread(CountTo1000);

    t1.Start();
    t2.Start();

    t1.Join();
    t2.Join();

    Console.WriteLine("Main thread done.");

    void CountTo1000()
    {
        for (int i = 0; i < 1000; i++)
            Console.WriteLine(i + 1);
    }
}

void Test2()
{
    var problem = new MultiplicationProblem() { A = 10.5, B = 6.75 };
    var thread = new Thread(Multiply);

    thread.Start(problem);
    thread.Join();

    Console.WriteLine("Result: " + problem.Result);

    static void Multiply(object? obj)
    {
        if (obj == null) return;

        var problem = (MultiplicationProblem)obj;
        problem.Result = problem.A * problem.B;
    }
}

void Test3()
{
    var message = new ColoredMessage("Hello, World!", ConsoleColor.Cyan);
    var thread = new Thread(message.Display);

    // No need to pass the message object here!
    thread.Start();
}

void Test4()
{
    var thread = new Thread(SleepAndPrint);

    Console.WriteLine("Inside the main thread.");
    thread.Start();
    Console.WriteLine("Main thread finished.");

    void SleepAndPrint()
    {
        Console.WriteLine("Second thread started.");
        Thread.Sleep(3000);
        Console.WriteLine("Second thread finished.");
    }
}

/***** Type Definitions *****/

public class MultiplicationProblem
{
    public double A { get; init; }
    public double B { get; init; }
    public double Result { get; set; }
}

public class ColoredMessage
{
    public string Text { get; }
    public ConsoleColor Color { get; }

    public ColoredMessage(string text, ConsoleColor color)
    {
        Text = text;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Text);
        Console.ResetColor();
    }
}