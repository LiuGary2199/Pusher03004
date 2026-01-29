using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusMite : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("targetObj")]    public GameObject RainerGel;
[UnityEngine.Serialization.FormerlySerializedAs("CurrentRadius")]
    public float CurrentAttack;
[UnityEngine.Serialization.FormerlySerializedAs("TargetRadius")]    public float RavageAttack;
[UnityEngine.Serialization.FormerlySerializedAs("shrinkTime")]    public float RubbleFast= 0f;

    private Material Register;


    private EnvelopeBulgeCarnation AdornCarnation;


    private void Start()
    {
        Vector3 targetPos = RainerGel.transform.localPosition * 0.7f;
        Vector4 centerMat = new Vector4(targetPos.x, targetPos.y, 0, 0);
        Register = GetComponent<Image>().material;
        Register.SetVector("_Center", centerMat);


        AdornCarnation = GetComponent<EnvelopeBulgeCarnation>();
        if (AdornCarnation != null)
        {
            AdornCarnation.HubRavageHoney(RainerGel.gameObject.GetComponent<Image>());
        }
    }


    /// <summary>
    /// 收缩速度
    /// </summary>
    private float RubbleConvince= 0f;

    private void Update()
    {
        float value = Mathf.SmoothDamp(CurrentAttack, RavageAttack, ref RubbleConvince, RubbleFast);
        if (!Mathf.Approximately(value, CurrentAttack))
        {
            CurrentAttack = value;
            Register.SetFloat("_Slider", CurrentAttack);
        }
    }
}