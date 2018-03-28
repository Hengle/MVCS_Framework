using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIViewManager
{
    private static Transform canvas;
    private static Transform Canvas
    {
        get
        {
            if (canvas == null) canvas = Context.Instance.transform.Find("Canvas");
            return canvas;
        }
    }
    private static Dictionary<string, UIView> uiViewDictionary;//所有UI面板
    private static Stack<UIView> uiViewStack;

    static UIViewManager()
    {
        uiViewDictionary = new Dictionary<string, global::UIView>();
        uiViewStack = new Stack<global::UIView>();


    }

    private static string UIViewPath
    {
        get
        {
            return AppConfig.UI_Panel_Path;
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <param name="paneName"></param>
    public static void PushPanel(string paneName)
    {
        if (uiViewStack.Count > 0)
        {
            UIView topPanel = uiViewStack.Peek();
            topPanel.OnPause();
        }

        UIView panel = GetPanel(ref paneName);
        panel.OnEnter();
        uiViewStack.Push(panel);
    }
    /// <summary>
    /// 弹出面板
    /// </summary>
    public static void PopPanel()
    {
        if (uiViewDictionary.Count <= 0) return;

        UIView topPanel = uiViewStack.Pop();
        topPanel.OnExit();

        if (uiViewStack.Count <= 0) return;
        UIView panel = uiViewStack.Peek();
        panel.OnResume();
    }
    /// <summary>
    /// 获取Panel
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    private static UIView GetPanel(ref string panelName)
    {
        UIView panel = null;
        uiViewDictionary.TryGetValue(panelName, out panel);

        if (panel == null)
        {
            //如果找不到，那么就找这个面板的prefab的路径，然后去根据prefab去实例化面板

            if (uiViewDictionary.ContainsKey(panelName)) { uiViewDictionary.Remove(panelName); }

            string path = UIViewPath + panelName;
            UIView instPanel = (UIView)ResourceManager.LoadGameObject(path,Canvas );

            uiViewDictionary.Add(panelName, instPanel);

            return instPanel;
        }

        return panel;
    }
}
