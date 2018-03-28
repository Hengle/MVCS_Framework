using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    public override void Execute()
    {
        ServiceEvent.AddHttpListener(ServiceEventType.Login, OnResponse);

        //加载UI面板
        UIViewManager.PushPanel("StartPanel");

        HttpService.RequestHttp("http://test.com");
    }

    private void OnResponse(ref string data)
    {
        ServiceEvent.RemoveHttpEvent(ServiceEventType.Login, OnResponse);
        //加载游戏物体
        ResourceManager.LoadGameObjects("Cubes", null, 0.1f);
        //获取对应的Model
        StartModel model = ModelManager.GetModel<StartModel>();
        model.data = data;
        //通知UI显示model内容
        ViewEvent.BrodcastHttpEvent(ViewEventType.StartLogin, model);
        StartModel model2 = ModelManager.GetModel<StartModel>();
        Debug.Log(model.Equals(model2));
        //等待CG清理实例
        GC.WaitForPendingFinalizers();
    }
}
