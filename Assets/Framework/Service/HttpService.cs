using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// 通过Http向服务器发送命令
/// </summary>
public static class HttpService
{
    static HttpService()
    {

    }
    /// <summary>
    /// 请求服务器命令
    /// </summary>
    /// <param name="url"></param>
    public static void RequestHttp(string url)
    {
        Context.Instance.StartCoroutine(wait());
    }

    private static IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        string data = "1,10,Start Login";
        OnResponse(ref data);
    }
    /// <summary>
    /// 相应服务器发送的消息
    /// </summary>
    /// <param name="data"></param>
    private static void OnResponse(ref string data)
    {
        //TODO 解析对应的类型ID，通过BrodcastHttpEvent把相对应的ID数据广播出去
        string[] value = data.Split(',');

        ServiceEvent.BrodcastHttpEvent((ServiceEventType)(int.Parse(value[0])), value[2]);
    }
}
