using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    private static Dictionary<string, GameObject> gameobjects { get; set; }//所有资源

     static ResourceManager()
    {
        gameobjects = new Dictionary<string, GameObject>();
    }
    /// <summary>
    /// 加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    public static T[] LoadAssets<T>(string path) where T : UnityEngine.Object
    {
        return Resources.LoadAll<T>(path);
    }

    /// <summary>
    /// 加载游戏对象
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static View LoadGameObject(string path, Transform parent)
    {
        GameObject go = Resources.Load<GameObject>(path);
        go = GameObject.Instantiate(go, parent);

        gameobjects.Add(path, go);
        return go.GetComponent<View>();
    }

    public static void LoadGameObjects(string path, Transform parent, float waitTime)
    {
        GameObject[] go = Resources.LoadAll<GameObject>(path);
        Context.Instance.StartCoroutine(LoadGameObject(path, go, parent, waitTime));
    }

    private static IEnumerator LoadGameObject(string path, GameObject[] g, Transform parent, float waitTime = 0.05f)
    {
        for (int i = 0; i < g.Length; i++)
        {
            if (parent != null) g[i] = GameObject.Instantiate(g[i], parent);
            else g[i] = GameObject.Instantiate(g[i]);

            //gameobjects.Add(path, g[i]);

            yield return new WaitForSeconds(waitTime);
        }
    }
    /// <summary>
    /// 资源释放
    /// </summary>
    public static void ReleaseAllGameObjects()
    {
        foreach (GameObject g in gameobjects.Values)
        {
            GameObject.Destroy(g);
        }
        gameobjects.Clear();
    }
}
