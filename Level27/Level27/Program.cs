// While the ExplodingBalloon class contains three implementations of the
// BlowUp method, the type of the variable it's called on determines which
// of the implementations is used.

ExplodingBalloon explodingBalloon = new ExplodingBalloon();

explodingBalloon.BlowUp();

IBomb bomb = explodingBalloon;

bomb.BlowUp();

IBalloon balloon = explodingBalloon;

balloon.BlowUp();

/***** Type Definitions *****/

public interface IBomb
{
    void BlowUp();
}

public interface IBalloon
{
    void BlowUp();
}

public class ExplodingBalloon : IBomb, IBalloon
{
    public void BlowUp()
    {
        Console.WriteLine("In ExplodingBalloon.BlowUp()");
    }

    // Explicitly implement the BlowUp method in the IBomb interface
    void IBomb.BlowUp()
    {
        Console.WriteLine("KABOOM!");
    }

    // Explicitly implement the BlowUp method in the IBalloon interface
    void IBalloon.BlowUp()
    {
        Console.WriteLine("WHOOSH!");
    }
}