using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    /// <summary>
    /// 当前的Model是否是全局唯一
    /// </summary>
    public bool IsSingle { get; protected set; }
    ~Model()
    {
#if UNITY_EDITOR
        Debug.Log("析构释放:" + this);
#endif
    }
}
