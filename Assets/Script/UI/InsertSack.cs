using System;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class InsertSack : LastUITruck
{
    public static InsertSack Instance;
[UnityEngine.Serialization.FormerlySerializedAs("rewardText")]
    public Text SierraCent;

   
    public override void Display()
    {
        base.Display();
    }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void Start()
    {
    }
    public void IsTireHall(double num)
    {
        SierraCent.text = num.ToString();
    }
    public void TireHall(double num)
    {
        SierraCent.text = num.ToString();
    }
    public override void Hidding()
    {
        base.Hidding();
    }
}