using FountainOfObjects.MapTools;
using FountainOfObjects.MapTools.Obstacles.Monsters;

namespace FountainOfObjects.PlayerActions;

internal class ShootAction : IPlayerAction
{
    private readonly Player _player;
    private readonly Map _map;
    private readonly Direction _direction;

    public ShootAction(Player player, Map map, Direction direction)
    {
        _player = player;
        _map = map;
        _direction = direction;
    }

    public ActionResult Perform()
    {
        if (_player.Arrows <= 0)
            return new ActionResult { Success = false, Message = "You don't have any arrows left." };

        Position target = _direction switch
        {
            Direction.North => _player.Position with { Row = _player.Position.Row - 1 },
            Direction.East => _player.Position with { Column = _player.Position.Column + 1 },
            Direction.South => _player.Position with { Row = _player.Position.Row + 1 },
            Direction.West => _player.Position with { Column = _player.Position.Column - 1 },
            _ => _player.Position
        };

        if (!_map.IsOnMap(target))
            return new ActionResult { Success = false, Message = "You can't shoot in that direction." };
        
        _player.Arrows--;
        
        Monster? monster = _map.GetMonsterAt(target);

        if (monster == null)
            return new ActionResult { Success = true, Message = "You shoot but hit nothing." };
        
        monster.IsAlive = false;

        return new ActionResult { Success = true, Message = "Your aim is true and you hit a monster!" };
    }
}