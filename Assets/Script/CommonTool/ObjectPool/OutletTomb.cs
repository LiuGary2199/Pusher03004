/*
 *   管理对象的池子
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletTomb 
{
    private Queue<GameObject> m_TombPlain;
    //池子名称
    private string m_TombClaw;
    //父物体
    protected Transform m_Quench;
    //缓存对象的预制体
    private GameObject Thirty;
    //最大容量
    private int m_ViePupil;
    //默认最大容量
    protected const int m_FresherViePupil= 20;
    public GameObject Runway    {
        get => Thirty;set { Thirty = value;  }
    }
    //构造函数初始化
    public OutletTomb()
    {
        m_ViePupil = m_FresherViePupil;
        m_TombPlain = new Queue<GameObject>();
    }
    //初始化
    public virtual void Tire(string poolName,Transform transform)
    {
        m_TombClaw = poolName;
        m_Quench = transform;
    }
    //取对象
    public virtual GameObject Yew()
    {
        GameObject obj;
        if (m_TombPlain.Count > 0)
        {
            obj = m_TombPlain.Dequeue();
        }
        else
        {
            obj = GameObject.Instantiate<GameObject>(Thirty);
            obj.transform.SetParent(m_Quench);
            obj.SetActive(false);
        }
        obj.SetActive(true);
        return obj;
    }
    //回收对象
    public virtual void Primary(GameObject obj)
    {
        if (m_TombPlain.Contains(obj)) return;
        if (m_TombPlain.Count >= m_ViePupil)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            m_TombPlain.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    /// <summary>
    /// 回收所有激活的对象
    /// </summary>
    public virtual void PrimaryDot()
    {
        Transform[] child = m_Quench.GetComponentsInChildren<Transform>();
        foreach (Transform item in child)
        {
            if (item == m_Quench)
            {
                continue;
            }
            
            if (item.gameObject.activeSelf)
            {
                Primary(item.gameObject);
            }
        }
    }
    //销毁
    public virtual void Diverse()
    {
        m_TombPlain.Clear();
    }
}
