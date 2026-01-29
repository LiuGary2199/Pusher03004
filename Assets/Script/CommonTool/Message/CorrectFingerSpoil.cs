using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class CorrectFingerSpoil:MonoWeightily<CorrectFingerSpoil>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<CorrectHall>> PhysicallyCorrect;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private CorrectFingerSpoil()
    {
        TireHall();
    }

    private void TireHall()
    {
        //初始化消息字典
        PhysicallyCorrect = new Dictionary<string, Action<CorrectHall>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Magnetic(string key, Action<CorrectHall> action)
    {
        if (!PhysicallyCorrect.ContainsKey(key))
        {
            PhysicallyCorrect.Add(key, null);
        }
        PhysicallyCorrect[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Midair(string key, Action<CorrectHall> action)
    {
        if (PhysicallyCorrect.ContainsKey(key) && PhysicallyCorrect[key] != null)
        {
            PhysicallyCorrect[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Pool(string key, CorrectHall data = null)
    {
        if (PhysicallyCorrect.ContainsKey(key) && PhysicallyCorrect[key] != null)
        {
            PhysicallyCorrect[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Roman()
    {
        PhysicallyCorrect.Clear();
    }
}
