using System.ComponentModel.DataAnnotations;

var objects = new List<GameObject>()
{
    new Ship() { ID = 4, X = 7, Y = 1, HP = 50, MaxHP = 100, PlayerID = 2 },
    new Ship() { ID = 1, X = 0, Y = 0, HP = 50, MaxHP = 100, PlayerID = 1 },
    new Ship() { ID = 2, X = 4, Y = 2, HP = 75, MaxHP = 100, PlayerID = 1 },
    new Ship() { ID = 3, X = 9, Y = 3, HP = 0, MaxHP = 100, PlayerID = 2 }
};

var players = new List<Player>()
{
    new Player(1, "Player 1", "Red"),
    new Player(2, "Player 2", "Blue")
};

Test3();

void Test1()
{
    // It's not possible to access the Shield property in this way.
    // The compiler only knows object contains GameObject instances.
    // var shipStrings = from o in objects
    //                   select (o, $"Shield: {o.Shield}, Hull: {o.HP}");

    // This code would throw an InvalidCastException if there's anything
    // in objects that's not a ship.
    // var shipStrings = from Ship s in objects
    //                   select (s, $"Shield: {s.Shield}, Hull: {s.HP}");

    // Alternative to the above using method call syntax. This would still
    // throw an exception if there's anything other than a ship in the List.
    // var shipStrings = objects
    //                     .Cast<Ship>()
    //                     .Select(s => (s, $"Shield: {s.Shield}, Hull: {s.HP}"));

    // Alternative to the above. This filters out anything that's not a ship
    // before casting.
    var shipStrings = objects
                        .OfType<Ship>()
                        .Select(s => (s, $"Shield: {s.Shield}, Hull: {s.HP}"));
}

void Test2()
{
    var shipColors = from Ship s in objects
                     join Player p in players on s.PlayerID equals p.ID
                     select (s, p.TeamColor);
}

void Test3()
{
    // var playerOneDeadShips = from o in objects
    //                          where o.PlayerID == 1
    //                          select o
    //                 into playerOneShip
    //                          where playerOneShip.HP <= 0
    //                          select playerOneShip;

    var playerOneShips = from o in objects
                         where o.PlayerID == 1
                         select o;
    var playerOneDeadShips = from s in playerOneShips
                             where s.HP <= 0
                             select s;
}

/***** Type Definitions *****/

public class GameObject
{
    public int ID { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public float MaxHP { get; set; }
    public float HP { get; set; }
    public int PlayerID { get; set; }
}

public class Ship : GameObject 
{
    public int Shield { get; set; }
}

public record Player(int ID, string UserName, string TeamColor);