using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiteBlubber : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform Fair;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public RiteSell Electrical;
    private void Awake()
    {
        Electrical.HeRiteBaltic = Stonemason;
    }

    void Stonemason(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        Fair.GetComponent<RectTransform>().position = pos;
    }
}
