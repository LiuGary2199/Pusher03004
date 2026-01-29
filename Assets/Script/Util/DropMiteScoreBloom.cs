// Project: HappyBingo-Real
// FileName: DropMiteScore.cs
// Author: AX
// CreateDate: 20230220
// CreateTime: 9:55
// Description:

using UnityEngine;
using UnityEngine.UI;

public class DropMiteScoreBloom : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetX")]    public float RainerReduceX;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetY")]    public float RainerReduceY;
    private Material Register;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetX")]
    public float SurmiseReduceX;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetY")]    public float SurmiseReduceY;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosX")]
    public float RainerEonX;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosY")]    public float RainerEonY;
[UnityEngine.Serialization.FormerlySerializedAs("shrinkTime")]
    public float RubbleFast= 0.3f;
    private EnvelopeBulgeCarnation AdornCarnation;
[UnityEngine.Serialization.FormerlySerializedAs("targetObj")]    public GameObject RainerGel;


    private float RubbleConvinceX= 0f;
    private float RubbleConvinceY= 0f;


    private void Start()
    {
        Vector4 centerMat = new Vector4(RainerEonX, RainerEonY, 0, 0);
        Register = GetComponent<Image>().material;
        Register.SetVector("_Center", centerMat);


        AdornCarnation = GetComponent<EnvelopeBulgeCarnation>();
        if (AdornCarnation != null)
        {
            AdornCarnation.HubRavageHoney(RainerGel.gameObject.GetComponent<Image>());
        }
    }

    private void Update()
    {
        
        //从当前偏移量到目标偏移量差值显示收缩动画
        float valueX = Mathf.SmoothDamp(SurmiseReduceX, RainerReduceX, ref RubbleConvinceX, RubbleFast);
        float valueY = Mathf.SmoothDamp(SurmiseReduceY, RainerReduceY, ref RubbleConvinceY, RubbleFast);
        if (!Mathf.Approximately(valueX, SurmiseReduceX))
        {
            SurmiseReduceX = valueX;
            Register.SetFloat("_SliderX", SurmiseReduceX);
        }

        if (!Mathf.Approximately(valueY, SurmiseReduceY))
        {
            SurmiseReduceY = valueY;
            Register.SetFloat("_SliderY", SurmiseReduceY);
        }
    }
    
    
    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 SpiteMeChurchEon(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }
    
}