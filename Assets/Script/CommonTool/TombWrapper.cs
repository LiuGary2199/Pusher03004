using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombWrapper : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("pool")]    public List<GameObject> Crew;
[UnityEngine.Serialization.FormerlySerializedAs("prefab")]    public GameObject Thirty;
    private Transform ThirtyQuench;
    private string ClosetClaw;

    public void TireTombWrapper(GameObject obj, Transform parent, int count, string _objectName)
    {
        Thirty = obj;
        ClosetClaw = _objectName;
        Crew = new List<GameObject>();
        ThirtyQuench = parent;
        int LoessPeart= 0;
        for (int k = 0; k < ThirtyQuench.childCount; k++)
        {
            if (ThirtyQuench.GetChild(k).name.Contains(ClosetClaw))
            {
                Crew.Add(ThirtyQuench.GetChild(k).gameObject);
                LoessPeart++;
            }
        }
        for (int i = LoessPeart; i < count; i++)
        {
            GameObject objClone = GameObject.Instantiate(Thirty, ThirtyQuench) as GameObject;
            //objClone.transform.parent = prefabParent;//为克隆出来的子弹指定父物体
            objClone.name = ClosetClaw + "(" + i.ToString() + ")";
            objClone.SetActive(false);
            Crew.Add(objClone);
        }
    }
    public void UnlikeTombYewGate(GameObject obj)
    {
        Crew.Add(obj);
    }

    public GameObject YewOutlet()
    {
        //遍历缓存池 找空闲的物体
        foreach (GameObject iter in Crew)
        {
            if (iter != null && !iter.activeSelf)
            {
                iter.transform.SetParent(ThirtyQuench);
                iter.SetActive(true);
                return iter;
            }
        }
        GameObject newPrefab = GameObject.Instantiate(Thirty) as GameObject;
        newPrefab.transform.SetParent(ThirtyQuench);
        newPrefab.name = ClosetClaw + "(" + Crew.Count.ToString() + ")"  ;
        newPrefab.SetActive(true);
        Crew.Add(newPrefab);
        return newPrefab;
    }

    public void PianoDot()
    {
        foreach (GameObject iter in Crew)
        {
            if (iter.activeSelf)
            {
                iter.SetActive(false);
            }
        }
    }
    public void DiverseDot()
    {
        foreach (GameObject iter in Crew)
        {
            Destroy(iter);
        }
        Destroy(ThirtyQuench);
        Destroy(this.gameObject);
    }
}
