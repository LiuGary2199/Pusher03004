using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class SendUproot : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Ravage_Fist;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Uproot_Fist;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Bis_Fast;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Uproot_Number;
    private void Awake()
    {
        if (Bis_Fast == RunTime.Awake)
        {
            LikelyEnough();
        }
    }
    private void Start()
    {
        if (Bis_Fast == RunTime.Start)
        {
            LikelyEnough();
        }
    }

    public void LikelyEnough()
    {
        if (Uproot_Fist == LayoutType.Sprite_First_Weight)
        {
            if (Ravage_Fist == TargetType.UGUI)
            {

                float scale = Screen.width / Uproot_Number;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        if (Uproot_Fist == LayoutType.Screen_First_Weight)
        {
            if (Ravage_Fist == TargetType.Scene)
            {
                float scale = YewMortarHall.YewVocation().EraUpwindLight() / Uproot_Number;
                transform.localScale = transform.localScale * scale;
            }
        }
        
        if (Uproot_Fist == LayoutType.Bottom)
        {
            if (Ravage_Fist == TargetType.Scene)
            {
                float screen_bottom_y = YewMortarHall.YewVocation().EraUpwindParent() / -2;
                screen_bottom_y += (Uproot_Number + (YewMortarHall.YewVocation().EraHumbleBurn(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
