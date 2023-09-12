namespace FountainOfObjects;

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
            return new ActionResult(false, "You don't have any arrows left.");

        Position target = _direction switch
        {
            Direction.North => _player.Position with { Row = _player.Position.Row - 1 },
            Direction.East => _player.Position with { Column = _player.Position.Column + 1 },
            Direction.South => _player.Position with { Row = _player.Position.Row + 1 },
            Direction.West => _player.Position with { Column = _player.Position.Column - 1 },
            _ => _player.Position
        };

        if (!_map.IsOnMap(target))
            return new ActionResult(false, "You can't shoot in that direction.");
        
        _player.Arrows--;
        
        Monster? monster = _map.GetMonsterAt(target);

        if (monster == null)
            return new ActionResult(true, "You shoot an arrow but hit nothing.");
        
        monster.IsAlive = false;

        return new ActionResult(true, "Your aim is true and you hit a monster!");
    }
}