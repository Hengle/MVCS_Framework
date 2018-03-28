using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : ICommand
{
    public bool retain { get; set; }
    public Command()
    {
#if UNITY_EDITOR
        UnityEngine.Debug.Log("执行"+this);
#endif
    }
    public virtual void Execute()
    {

    }
    ~Command()
    {
#if UNITY_EDITOR
        UnityEngine.Debug.Log("析构释放" + this);
#endif
    }
}
