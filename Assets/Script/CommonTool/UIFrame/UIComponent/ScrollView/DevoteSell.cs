/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DevoteSell : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public Item PickWren;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect ManureDrop;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Zoology;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Evident= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float DutchLight;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float DutchParent;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int DepositPupil;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool WeClac= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int LoessPeart;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int WindPeart;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float PickParent= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<Item> PickGerm;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<Item> DepositGerm;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> OatGerm;

    void Start()
    {
        DutchParent = this.GetComponent<RectTransform>().sizeDelta.y;
        DutchLight = this.GetComponent<RectTransform>().sizeDelta.x;
        Zoology = ManureDrop.content;
        TireHall();

    }
    //初始化
    public void TireHall()
    {
        DepositPupil = Mathf.CeilToInt(DutchParent / GoldParent) + 1;
        for (int i = 0; i < DepositPupil; i++)
        {
            this.YewGate();
        }
        LoessPeart = 0;
        WindPeart = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        HubHall(numberList);
    }
    //设置数据
    void HubHall(List<int> list)
    {
        OatGerm = list;
        LoessPeart = 0;
        if (HallPupil <= DepositPupil)
        {
            WindPeart = HallPupil;
        }
        else
        {
            WindPeart = DepositPupil - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = LoessPeart; i < WindPeart; i++)
        {
            Item obj = PayGate();
            if (obj == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                obj.gameObject.name = i.ToString();

                obj.gameObject.SetActive(true);
                obj.transform.localPosition = new Vector3(0, -i * GoldParent, 0);
                DepositGerm.Add(obj);
                VirtueGate(i, obj);
            }

        }
        Zoology.sizeDelta = new Vector2(DutchLight, HallPupil * GoldParent - Evident);
        WeClac = true;
    }
    //更新item
    public void VirtueGate(int index, Item obj)
    {
        int d = OatGerm[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public Item PayGate()
    {
        Item obj = null;
        if (PickGerm.Count > 0)
        {
            obj = PickGerm[0];
            obj.gameObject.SetActive(true);
            PickGerm.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return obj;
    }
    //item进入itemlist
    public void JuryGate(Item obj)
    {
        PickGerm.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int HallPupil    {
        get
        {
            return OatGerm.Count;
        }
    }
    //每一行的高
    public float GoldParent    {
        get
        {
            return PickParent + Evident;
        }
    }
    //添加item到缓存列表中
    public void YewGate()
    {
        GameObject obj = Instantiate(PickWren.gameObject);
        obj.transform.SetParent(Zoology);
        RectTransform Rome= obj.GetComponent<RectTransform>();
        Rome.anchorMin = new Vector2(0.5f, 1);
        Rome.anchorMax = new Vector2(0.5f, 1);
        Rome.pivot = new Vector2(0.5f, 1);
        obj.SetActive(false);
        obj.transform.localScale = Vector3.one;
        Item o = obj.GetComponent<Item>();
        PickGerm.Add(o);
    }



    void Update()
    {
        if (WeClac)
        {
            Devote();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Devote()
    {
        float vy = Zoology.anchoredPosition.y;
        float rollUpTop = (LoessPeart + 1) * GoldParent;
        float rollUnderTop = LoessPeart * GoldParent;

        if (vy > rollUpTop && WindPeart < HallPupil)
        {
            //上边界移除
            if (DepositGerm.Count > 0)
            {
                Item obj = DepositGerm[0];
                DepositGerm.RemoveAt(0);
                JuryGate(obj);
            }
            LoessPeart++;
        }
        float rollUpBottom = (WindPeart - 1) * GoldParent - Evident;
        if (vy < rollUpBottom - DutchParent && LoessPeart > 0)
        {
            //下边界减少
            WindPeart--;
            if (DepositGerm.Count > 0)
            {
                Item obj = DepositGerm[DepositGerm.Count - 1];
                DepositGerm.RemoveAt(DepositGerm.Count - 1);
                JuryGate(obj);
            }

        }
        float rollUnderBottom = WindPeart * GoldParent - Evident;
        if (vy > rollUnderBottom - DutchParent && WindPeart < HallPupil)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            Item go = PayGate();
            DepositGerm.Add(go);
            go.transform.localPosition = new Vector3(0, -WindPeart * GoldParent);
            VirtueGate(WindPeart, go);
            WindPeart++;
        }


        if (vy < rollUnderTop && LoessPeart > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            LoessPeart--;
            Item go = PayGate();
            DepositGerm.Insert(0, go);
            VirtueGate(LoessPeart, go);
            go.transform.localPosition = new Vector3(0, -LoessPeart * GoldParent);
        }

    }
}
