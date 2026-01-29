/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulgeOverlapEducable : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate OxForge;
    public VoidDelegate OxPont;
    public VoidDelegate OxMetal;
    public VoidDelegate OxMule;
    public VoidDelegate OxSo;
    public VoidDelegate OxHamlin;
    public VoidDelegate OxVirtueHamlin;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static BulgeOverlapEducable Yew(GameObject go)
    {
        BulgeOverlapEducable listener = go.GetComponent<BulgeOverlapEducable>();
        if (listener == null)
        {
            listener = go.AddComponent<BulgeOverlapEducable>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (OxForge != null)
        {
            OxForge(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (OxPont != null)
        {
            OxPont(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (OxMetal != null)
        {
            OxMetal(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (OxMule != null)
        {
            OxMule(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (OxSo != null)
        {
            OxSo(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (OxHamlin != null)
        {
            OxHamlin(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (OxVirtueHamlin != null)
        {
            OxVirtueHamlin(gameObject);
        }
    }
}
