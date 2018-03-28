using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : View
{
    /// <summary>
    ///当界面被其他界面覆盖时
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    ///当界面被其他界面覆盖时
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    ///当界面退出时
    /// </summary>
    public virtual void OnExit()
    {

    }

    /// <summary>
    /// UI继续显示在最前面的时候
    /// </summary>
    public virtual void OnResume()
    {

    }

}
