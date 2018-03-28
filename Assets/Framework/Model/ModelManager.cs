using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ModelManager
{
    private static Dictionary<string,Model> singoleModles;//仅仅只是存的全局唯一model
    static ModelManager()
    {
        singoleModles = new Dictionary<string, global::Model>();
    }
    public static T GetModel<T>() where T : Model
    {
        return CreateModel<T>() as T;
    }
    private static Model CreateModel<T>() where T : Model
    {
        //如果当前已经存在了全局model，直接返回，确保model全局唯一
        if (singoleModles.ContainsKey(typeof(T).ToString())) return singoleModles[typeof(T).ToString()];
        //创建model
        object type = typeof(T) as object;

        Model model = CreateModel(type, null) as Model;

        if (model.IsSingle) singoleModles.Add(typeof(T).ToString(), model);

        return (model);
    }
    private static object CreateModel(object o, object[] args)
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
            Debug.LogError("Instantiation model failed : " + o);
        }
        return retv;
    }
}
