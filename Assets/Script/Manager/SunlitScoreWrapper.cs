// Project: Pusher
// FileName: SunlitScoreWrapper.cs
// Author: AX
// CreateDate: 20230809
// CreateTime: 17:33
// Description:

using System;
using System.Collections.Generic;
using UnityEngine;

public class SunlitScoreWrapper : MonoBehaviour
{
    public static SunlitScoreWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("isLock")]    public bool WeOnly;


    protected void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        WeOnly = false;

        CorrectFingerSpoil.YewVocation().Magnetic(CScream.Ask_Chain_Brawl_Toe_Loess,
            (messageData) => { PianoOnly(); });
    }


    private void PianoOnly()
    {
        WeOnly = false;
    }


    // show big win panel
    public void SinkTinSunlitScore(double num)
    {
        if (WeOnly) return;

        WeOnly = true;
        if (KettleSure.HeYield())
        {
            return;
        }
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(TinVasKrillScore));
        TinVasKrillScore.Instance.TireHall(num);
    }

    // show normal win panel
    public void SinkDemiseSunlitScore(Dictionary<NormalRewardType, double> rewardMap)
    {
        if (WeOnly) return;
        WeOnly = true;
        UIManager.YewVocation().SinkUITruck(nameof(DemiseVasKrillScore));
        DemiseVasKrillScore.Instance.TireHall(rewardMap);
    }


    public void SinkSuchSodaSunlit()
    {
        BeauWrapper.Instance.UtahPlow();
        Dictionary<NormalRewardType, double> SierraHay= new Dictionary<NormalRewardType, double>();

        double num = GameUtil.GetCashRollReward();
        SierraHay[NormalRewardType.RollCash] = num;
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_Stir, "1012");
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_It_To,"5");
        SinkDemiseSunlitScore(SierraHay);
    }

}