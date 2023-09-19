Test2();

static void Test1()
{
    int number = 0;

    do
    {
        Console.Write("Enter a number between 1 and 10: ");
        string? response = Console.ReadLine();

        try
        {
            number = Convert.ToInt32(response);
        }
        catch (FormatException)
        {
            number = -1;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"'{response}' is not a number.");
        }
        catch (OverflowException)
        {
            number = -1;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That number is too large.");
        }
        finally
        {
            Console.ResetColor();
        }
    } while (number < 1 || number > 10);
}

static void Test2()
{
    Console.Write("Enter an animal: ");
    string? animal = Console.ReadLine();

    try
    {
        if (animal == "snake")
        {
            var exception = new SnakeException("I have ophidiophobia.");

            // The throw keyword is what starts the search for a handler, not the creation of an exception object!
            Console.WriteLine("Created a new exception object!");

            throw exception;
        }

        Console.WriteLine($"Great, {animal}s are cute!");
    }
    catch (SnakeException e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[ERROR] ");
        Console.ResetColor();
        Console.WriteLine(e.Message);
    }
    finally
    {
        Console.WriteLine("\nWe're all done here.");
    }
}

/***** Type Definitions *****/

internal class SnakeException : Exception
{
    public SnakeException() : base() { }
    public SnakeException(string message) : base(message) { }
}