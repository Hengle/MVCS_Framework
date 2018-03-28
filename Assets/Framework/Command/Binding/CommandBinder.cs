using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单个枚举与事件的绑定
/// </summary>
public class CommandBinder: ICommandBinder
{
    public bool single { get; set; }
    public List<object> commands { get; set; }
    public CommandEventType commandEventType { get; set; }
    public ICommandBinder Bind(CommandEventType e)
    {
        commandEventType = e;

        commands = new List<object>();

        return this;
    }
    public ICommandBinder To<T>()
    {
        commands.Add(typeof(T) as object);
        return this;
    }

}
