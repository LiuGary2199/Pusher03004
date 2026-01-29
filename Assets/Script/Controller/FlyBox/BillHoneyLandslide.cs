using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BillHoneyLandslide : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("imageList")]    public List<Sprite> FancyGerm;
    private Image Fancy;
[UnityEngine.Serialization.FormerlySerializedAs("speen")]    public float Pylon;
    IEnumerator DeepEnough()
    {
        foreach(Sprite sprite in FancyGerm)
        {
            Fancy.sprite = sprite;
            yield return new WaitForSeconds(Pylon);
        }
    }
    private void OnEnable()
    {
        Fancy = GetComponent<Image>();
        StartCoroutine(nameof(DeepEnough));
    }
    // private void OnDisable()
    // {
    //     StopCoroutine("playAction");
    // }
}
