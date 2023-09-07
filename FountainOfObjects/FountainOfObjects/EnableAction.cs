﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects;

internal class EnableAction : IPlayerAction
{
    private readonly Player _player;
    private readonly Map _map;

    public EnableAction(Player player, Map map)
    {
        _player = player;
        _map = map;
    }

    public bool Perform()
    {
        if (_player.Position == _map.Fountain.Position)
        {
            _map.Fountain.IsActivated = true;

            return true;
        }

        return false;
    }
}