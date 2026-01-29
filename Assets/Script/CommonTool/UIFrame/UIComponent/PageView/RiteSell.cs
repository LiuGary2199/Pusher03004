/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class RiteSell : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Rome;
    //求出每页的临界角，页索引从0开始
    List<float> FarGerm= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool WeLust= false;
    bool stopHerb= true;
    //滑动的起始坐标  
    float RainerIncidental= 0;
    float LoessLustIncidental;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float Arboreal= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Imaginative= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> HeRiteBaltic;
    //当前页面下标
    int SurmiseRitePeart= -1;
    void Start()
    {
        Rome = this.GetComponent<ScrollRect>();
        float horizontalLength = Rome.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        FarGerm.Add(0);
        for(int i = 1; i < Rome.content.childCount - 1; i++)
        {
            FarGerm.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        FarGerm.Add(1);
    }

    
    void Update()
    {
        if(!WeLust && !stopHerb)
        {
            startTime += Time.deltaTime;
            float t = startTime * Arboreal;
            Rome.horizontalNormalizedPosition = Mathf.Lerp(Rome.horizontalNormalizedPosition, RainerIncidental, t);
            if (t >= 1)
            {
                stopHerb = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void HubRitePeart(int index)
    {
        if (SurmiseRitePeart != index)
        {
            SurmiseRitePeart = index;
            if (HeRiteBaltic != null)
            {
                HeRiteBaltic(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        WeLust = true;
        LoessLustIncidental = Rome.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Rome.horizontalNormalizedPosition;
        posX += ((posX - LoessLustIncidental) * Imaginative);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int Shock= 0;
        float offset = Mathf.Abs(FarGerm[Shock] - posX);
        for(int i = 0; i < FarGerm.Count; i++)
        {
            float temp = Mathf.Abs(FarGerm[i] - posX);
            if (temp < offset)
            {
                Shock = i;
                offset = temp;
            }
        }
        HubRitePeart(Shock);
        RainerIncidental = FarGerm[Shock];
        WeLust = false;
        startTime = 0f;
        stopHerb = false;
    }
}
