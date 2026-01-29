/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructJaw 
{
    public static ObstructJaw _Explosive;
    //语言翻译的缓存集合
    private Dictionary<string, string> _LogObstructCache;

    private ObstructJaw()
    {
        _LogObstructCache = new Dictionary<string, string>();
        //初始化语言缓存集合
        TireObstructPlain();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static ObstructJaw YewVocation()
    {
        if (_Explosive == null)
        {
            _Explosive = new ObstructJaw();
        }
        return _Explosive;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string SinkCent(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_LogObstructCache!=null && _LogObstructCache.Count >= 1)
        {
            _LogObstructCache.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void TireObstructPlain()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        IScreamWrapper config = new ScreamWrapperAnGain("LauguageJSONConfig");
        if (config != null)
        {
            _LogObstructCache = config.BuyUnclear;
        }
    }
}
