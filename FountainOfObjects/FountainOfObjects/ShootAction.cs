namespace FountainOfObjects;

internal class ShootAction : IPlayerAction
{
    private Player _player;
    private Map _map;
    private Direction _direction;

    public ShootAction(Player player, Map map, Direction direction)
    {
        _player = player;
        _map = map;
        _direction = direction;
    }

    public bool Perform()
    {
        if (_player.Arrows <= 0) return false;

        Position target = _direction switch
        {
            Direction.North => _player.Position with { Row = _player.Position.Row - 1 },
            Direction.East => _player.Position with { Column = _player.Position.Column + 1 },
            Direction.South => _player.Position with { Row = _player.Position.Row + 1 },
            Direction.West => _player.Position with { Column = _player.Position.Column - 1 },
            _ => _player.Position
        };

        if (!_map.IsOnMap(target)) return false;

        Monster? monster = _map.GetMonsterAt(target);

        if (monster != null) monster.IsAlive = false;

        _player.Arrows--;

        return true;
    }
}