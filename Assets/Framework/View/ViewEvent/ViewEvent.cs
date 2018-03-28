using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ViewEvent
{
    static Dictionary<ViewEventType, ViewCallback> viewEvents;

    static ViewEvent()
    {
        viewEvents = new Dictionary<global::ViewEventType, global::ViewCallback>();
    }
    public static void AddListener(ViewEventType e, ViewCallback v)
    {
        if (v == null)
        {
            Debug.LogError("http service callback is null");
            return;
        }
        if (!viewEvents.ContainsKey(e)) viewEvents.Add(e, null);
        viewEvents[e] = viewEvents[e] + v;
    }
    //广播View事件，传递数据为model
    public static void BrodcastHttpEvent(ViewEventType e, Model m)
    {
        //检查当前这个事件是否为空
        if (viewEvents.ContainsKey(e)) if (viewEvents[e] == null) viewEvents.Remove(e);

        ViewCallback vc = null;

        viewEvents.TryGetValue(e, out vc);

        if (vc == null) return;

        vc(m);
    }
    public static void RemoveListener(ViewEventType e, ViewCallback v)
    {
        viewEvents[e] = viewEvents[e] - v;

        if (viewEvents[e] == null) viewEvents.Remove(e);
        Debug.Log(viewEvents.ContainsValue(v));
    }
}
