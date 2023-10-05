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

//var healthInfo = from o in objects
//                 where o.HP > 50
//                 where o.PlayerID == 1
//                 select (o, $"{o.HP}/{o.MaxHP}");

var healthInfo = objects
                    .Where(o => o.HP > 0)
                    .OrderBy(o => o.HP)
                    .ThenBy(o => o.ID);

Console.ReadKey();

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

public class Ship : GameObject { }

public record Player(int ID, string UserName, string TeamColor);