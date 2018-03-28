using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 绑定 event -> Command
/// </summary>
public static class CommandBinding
{
    public static Context context { get; private set; }
    /// <summary>
    /// 当前绑定的事件
    /// </summary>
    private static ICommandBinder commandBinder { get; set; }
    static CommandBinding()
    {

    }
    /// <summary>
    /// 绑定事件对应的枚举类型
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public static ICommandBinder Bind(CommandEventType e)
    {
        commandBinder = new CommandBinder();

        commandBinder.Bind(e);

#if UNITY_EDITOR
        UnityEngine.Debug.Log("CommandBinder : " + e);
#endif

        CommandEvent.AddCommand(commandBinder);

        return commandBinder;
    }
    /// <summary>
    /// 需要绑定的事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ICommandBinder To<T>()
    {
        return commandBinder.To<T>();
    }
}
