using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Context : MonoBehaviour
{
    public static Context Instance { get; private set; }
    public Context()
    {
        Instance = this;
    }
    protected virtual void Awake()
    {
        MapBindings();

        CommandEvent.BrodcastCommandEvent(CommandEventType.START);
    }
    /// <summary>
    /// 绑定对应关系
    /// </summary>
    virtual protected void MapBindings()
    {
        
    }
}
