using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : Context
{
    protected override void MapBindings()
    {
        CommandBinding.Bind(CommandEventType.START).To<StartCommand>();
    }
}
