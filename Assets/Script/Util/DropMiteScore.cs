using UnityEngine;
using UnityEngine.UI;

public class DropMiteScore : LastUITruck
{
    [Header("目标设置")]
[UnityEngine.Serialization.FormerlySerializedAs("targetObj")]    public GameObject RainerGel;
[UnityEngine.Serialization.FormerlySerializedAs("padding")]    public float Conduct= 10f; // 目标周围的边距

    [Header("动画设置")]
[UnityEngine.Serialization.FormerlySerializedAs("shrinkTime")]    public float RubbleFast= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetX")]    public float RainerReduceX;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetY")]    public float RainerReduceY;

    private Material Register;
    private RectTransform RainerDrop;
    private Canvas RainerChurch;
    private RectTransform maskDrop;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetX")]
    public float SurmiseReduceX;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetY")]    public float SurmiseReduceY;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosX")]    public float RainerEonX;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosY")]    public float RainerEonY;

    private float RubbleConvinceX= 0f;
    private float RubbleConvinceY= 0f;
    private EnvelopeBulgeCarnation AdornCarnation;
    private bool LugRavageGel= false;

    private void Start()
    {
        maskDrop = GetComponent<RectTransform>();
        Register = GetComponent<Image>().material;
        AdornCarnation = GetComponent<EnvelopeBulgeCarnation>();

        // 检查是否有目标对象
        if (RainerGel != null)
        {
            RainerDrop = RainerGel.GetComponent<RectTransform>();
            if (RainerDrop != null)
            {
                RainerChurch = RainerGel.GetComponentInParent<Canvas>();
                if (RainerChurch != null)
                {
                    LugRavageGel = true;
                    VirtueRavageProportion();
                }
            }
        }

        if (!LugRavageGel)
        {
            // 原逻辑：使用Inspector中设置的参数
            Vector4 centerMat = new Vector4(RainerEonX, RainerEonY, 0, 0);
            Register.SetVector("_Center", centerMat);
        }

        if (AdornCarnation != null && LugRavageGel)
        {
            AdornCarnation.HubRavageDrop(RainerDrop);
        }
    }

    private void Update()
    {
        if (LugRavageGel)
        {
            VirtueRavageProportion();
        }

        // 原逻辑：平滑动画
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

    private void VirtueRavageProportion()
    {
        // 获取目标在屏幕空间的位置
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(RainerChurch.worldCamera, RainerDrop.position);

        // 转换为遮罩面板的本地坐标
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(maskDrop, screenPos, RainerChurch.worldCamera, out localPos);

        // 设置遮罩中心为目标中心
        RainerEonX = localPos.x;
        RainerEonY = localPos.y;
        Register.SetVector("_Center", new Vector4(RainerEonX, RainerEonY, 0, 0));

        // 设置遮罩大小为目标大小加上边距
        RainerReduceX = (RainerDrop.rect.width / 2) + Conduct;
        RainerReduceY = (RainerDrop.rect.height / 2) + Conduct;
    }

    // 外部调用：设置新的目标对象
    public void HubRavage(GameObject newTarget)
    {
        RainerGel = newTarget;

        if (RainerGel != null)
        {
            RainerDrop = RainerGel.GetComponent<RectTransform>();
            if (RainerDrop != null)
            {
                RainerChurch = RainerGel.GetComponentInParent<Canvas>();
                if (RainerChurch != null)
                {
                    LugRavageGel = true;
                    VirtueRavageProportion();

                    if (AdornCarnation != null)
                    {
                        AdornCarnation.HubRavageDrop(RainerDrop);
                    }
                }
            }
        }
        else
        {
            LugRavageGel = false;
        }
    }
}