using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class MoveAction : IPlayerAction
{
    private readonly Player _player;
    private readonly Map _map;
    private readonly Direction _direction;

    public MoveAction(Player player, Map map, Direction direction)
    {
        _player = player;
        _map = map;
        _direction = direction;
    }

    public bool Perform()
    {
        var newPosition = _direction switch
        {
            Direction.North => _player.Position with { Row = _player.Position.Row - 1 },
            Direction.East => _player.Position with { Column = _player.Position.Column + 1 },
            Direction.South => _player.Position with { Row = _player.Position.Row + 1 },
            Direction.West => _player.Position with { Column = _player.Position.Column - 1 },
            _ => _player.Position
        };

        if (_map.IsPositionValid(newPosition))
        {
            _player.Position = newPosition;

            return true;
        }

        return false;
    }
}