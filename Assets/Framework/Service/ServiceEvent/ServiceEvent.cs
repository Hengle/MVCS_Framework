using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 从服务器解析广播的事件
/// </summary>
public static class ServiceEvent
{
    static Dictionary<ServiceEventType, HttpServiceCallback> httpEvens;//http 事件列表
    static Dictionary<ServiceEventType, SocketServiceCallback> socketEvents;//socket 事件列表

    static ServiceEvent()
    {
        httpEvens = new Dictionary<ServiceEventType, HttpServiceCallback>();
    }

    #region Http
    public static void AddHttpListener(ServiceEventType e, HttpServiceCallback c)
    {
        if (c == null)
        {
            Debug.LogError("http service callback is null");
            return;
        }
        if (!httpEvens.ContainsKey(e)) httpEvens.Add(e, null);
        httpEvens[e] = httpEvens[e] + c;
    }
    //广播Http事件
    public static void BrodcastHttpEvent(ServiceEventType e, string data)
    {
        //检查当前这个事件是否为空
        if (httpEvens.ContainsKey(e)) if (httpEvens[e] == null) httpEvens.Remove(e);

        HttpServiceCallback http = null;

        httpEvens.TryGetValue(e, out http);

        if (http == null) return;

        http(ref data);
    }

    public static void RemoveHttpEvent(ServiceEventType e, HttpServiceCallback cb)
    {
        httpEvens[e] = httpEvens[e] - cb;

        if (httpEvens[e] == null) httpEvens.Remove(e);
    }
    #endregion

    #region socket
    #endregion
}
