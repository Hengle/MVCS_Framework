using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommandEvent
{
    static CommandEvent()
    {

    }

    public static List<ICommandBinder> commands { get; private set; }

    public static void AddCommand(ICommandBinder command)
    {
        if (command == null) UnityEngine.Debug.LogError("command is null");
        if (commands == null) commands = new List<ICommandBinder>();

        commands.Add(command);
    }
    public static void BrodcastCommandEvent(CommandEventType e,object[] parameter = null)
    {
        CommandExecute(e, parameter);
    }
    /// <summary>
    /// 执行注册的事件
    /// </summary>
    /// <param name="e"></param>
    /// <param name="parameter"></param>
    private static void CommandExecute(CommandEventType e, object[] parameter)
    {
        ICommandBinder commandBinder = GetCommandBinder(e);

        object[] commands = GenerateCommands(commandBinder, parameter);

        for (int i = 0; i < commands.Length; i++)
        {
            ICommand command = (commands[i] as ICommand);

            command.Execute();

            command = null;

            GC.Collect();
        }
    }
    private static ICommandBinder GetCommandBinder(CommandEventType e)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i].commandEventType == e)
            {
                return commands[i];
            }
        }

        if (AppConfig.IS_DEBUG_MODEL)
        {
            UnityEngine.Debug.LogError("CommandEventType : " + e + " is not Commands");
        }
        return null;
    }
    /// <summary>
    /// 获取枚举对应的所有命令
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private static object[] GenerateCommands(ICommandBinder c, object[] parameter)
    {
        object[] o = new object[c.commands.Count];

        for (int i = 0; i < c.commands.Count; i++)
        {
            o[i] = CreateCommand(c.commands[i], parameter);
        }

        return o;
    }
    /// <summary>
    /// 创建命令实例
    /// </summary>
    /// <param name="o"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    private static object CreateCommand(object o, object[] args)
    {
        Type value = (o is Type) ? o as Type : o.GetType();
        object retv = null;
        try
        {
            if (args == null || args.Length == 0)
            {
                retv = Activator.CreateInstance(value);
            }
            else
            {
                retv = Activator.CreateInstance(value, args);
            }
        }
        catch
        {
            Debug.LogError("Instantiation command failed : " + o);
        }
        return retv;
    }
}
