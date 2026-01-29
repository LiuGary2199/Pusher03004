using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class EnvelopeBulgeCarnation : MonoBehaviour, ICanvasRaycastFilter
{
    private Image RainerHoney;
    private RectTransform RainerDrop;
    public void HubRavageHoney(Image target)
    {
        RainerHoney = target;
    }
    public void HubRavageDrop(RectTransform rect)
    {
        RainerDrop = rect;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (RainerHoney == null)
        {
            return true;
        }
        return !RectTransformUtility.RectangleContainsScreenPoint(RainerHoney.rectTransform, sp, eventCamera);
    }
}