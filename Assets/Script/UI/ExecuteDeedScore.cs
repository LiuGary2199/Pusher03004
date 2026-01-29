// Project: Plinko
// FileName: ExecuteDeedScore.cs
// Author: AX
// CreateDate: 20230510
// CreateTime: 10:28
// Description:

using System;
using System.Collections.Generic;
using DG.Tweening;
using ScratchCardAsset;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ExecuteDeedScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("closeBtn")]    // public SkeletonGraphic titleAnim;

    public Button ChainFew;
[UnityEngine.Serialization.FormerlySerializedAs("targetCard")]
    public ScratchCardManager RainerDeed;
[UnityEngine.Serialization.FormerlySerializedAs("mainCard")]    public ScratchCardManager LineDeed;
[UnityEngine.Serialization.FormerlySerializedAs("cardLessProgress")]
    public float LungKnowSquirrel;
[UnityEngine.Serialization.FormerlySerializedAs("targetNum01")]
    public Text RainerBed01;
[UnityEngine.Serialization.FormerlySerializedAs("targetNum02")]    public Text RainerBed02;
[UnityEngine.Serialization.FormerlySerializedAs("mainCardObjList")]
    public List<ExecuteGelDelectable> LineDeedGelGerm;

    private bool RainerDeedMust;
    private bool LineDeedMust;

    private int GhostlyVasViePupil;
    private int GiftVasPupil;

    private List<int> RainerBedGerm;

    private Dictionary<NormalRewardType, double> SierraHay;
[UnityEngine.Serialization.FormerlySerializedAs("titleAnim")]    
    public SkeletonGraphic SpaceFair;


    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        DaleBulgeScript.YewVocation().PoolBulge("1008");

        SpaceFair.AnimationState.SetAnimation(0, "chuxian", false);
        SpaceFair.AnimationState.AddAnimation(0, "daiji", true, 0f);

        RainerDeedMust = false;
        LineDeedMust = false;

        TireUtahHall();
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_littlegame_show);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }
    protected override void Awake()
    {
        base.Awake();
        GhostlyVasViePupil = MudHourJaw.instance.UtahHall.base_config.scratch_win_max_count;
        //scratchWinMaxCount = 3;
        GiftVasPupil = 0;
    }

    private void Start()
    {
        ChainFew.onClick.AddListener(() => { PianoExecuteDeedScore(); });

        CorrectFingerSpoil.YewVocation().Magnetic(CScream.Ask_Chain_Brawl_Toe_Loess,
            (messageData) => { PianoExecuteDeedScore(); });
        
        TireUtahHall();
    }

    private void Update()
    {
        if (!RainerDeedMust && RainerDeed.Progress.GetProgress() > 0.7f)
        {
            RainerDeedMust = true;
            RainerDeed.FillScratchCard();
            if (LineDeedMust)
            {
                SinkExecuteKrill();
            }
        }

        if (!LineDeedMust && LineDeed.Progress.GetProgress() > LungKnowSquirrel)
        {
            LineDeedMust = true;
            LineDeed.FillScratchCard();
            if (RainerDeedMust)
            {
                SinkExecuteKrill();
            }
        }
    }


    private void SinkLocaleKrillScore()
    {
        if (SierraHay.Count > 0)
        {
            ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_Stir, "1009");
 
            ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_It_To,"3");
            SunlitScoreWrapper.Instance.SinkDemiseSunlitScore(SierraHay);
            // DemiseVasKrillScore.Instance.InitData(rewardMap, GetType().Name);
        }
        else
        {
            PianoExecuteDeedScore();
        }
    }

    private void SinkExecuteKrill()
    {
        List<ExecuteGelDelectable> RimGerm= new List<ExecuteGelDelectable>();


        foreach (ExecuteGelDelectable obj in LineDeedGelGerm)
        {
            if (RainerBedGerm.Contains(obj.LineBed))
            {
                string type = obj.GhostlyGelHall.ScratchObjType.ToString();
                NormalRewardType SierraFist= (NormalRewardType) Enum.Parse(typeof(NormalRewardType), type);
                if (SierraHay.ContainsKey(SierraFist))
                {
                    SierraHay[SierraFist] =
                        SierraHay[SierraFist] + obj.GhostlyGelHall.RewardNum;
                }
                else
                {
                    SierraHay.Add(SierraFist, obj.GhostlyGelHall.RewardNum);
                }

                RimGerm.Add(obj);
            }
        }

        float timeTemp = 0f;

        for (int i = 0; i < RimGerm.Count; i++)
        {
            ExecuteGelDelectable obj = RimGerm[i];
            obj.transform.DOScale(1, 0f).SetDelay(timeTemp).OnComplete(() => { obj.SinkRavage(); });

            timeTemp += 0.15f;
        }

        Invoke(nameof(SinkLocaleKrillScore), 0.6f + timeTemp);
    }


    private int YewTankerGelBed()
    {
        return Random.Range(1, 71);
    }

    private void TireUtahHall()
    {
        SierraHay = new Dictionary<NormalRewardType, double>();
        RainerBedGerm = YewRavageGerm();
        GiftVasPupil = Random.Range(2, GhostlyVasViePupil);

        RainerDeed.MainCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();;
        LineDeed.MainCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();;
 
        List<int> mainNumList = new List<int>();
        for (int i = 0; i < GiftVasPupil; i++)
        {
            int Shock= Random.Range(0, 2);
            int num = RainerBedGerm[Shock];
            mainNumList.Add(num);
        }

        while (mainNumList.Count < 9)
        {
            int num = YewTankerGelBed();
            if (!mainNumList.Contains(num))
            {
                mainNumList.Add(num);
            }
        }

        mainNumList = TankerSure.TankerScat(mainNumList);

        for (int i = 0; i < mainNumList.Count; i++)
        {
            LineDeedGelGerm[i].TireHall(mainNumList[i], RainerBedGerm.Contains(mainNumList[i]));
        }
    }

    private List<int> YewRavageGerm()
    {
        List<int> targetList = new List<int>();
        int num1 = YewTankerGelBed();
        targetList.Add(num1);
        int num2 = YewTankerGelBed();
        while (num1 == num2)
        {
            num2 = YewTankerGelBed();
        }

        targetList.Add(num2);
        RainerBed01.text = num1.ToString();
        RainerBed02.text = num2.ToString();

        return targetList;
    }

    private void PianoExecuteDeedScore()
    {
        if (!gameObject.activeInHierarchy) return;
        RainerDeed.ClearScratchCard();
        LineDeed.ClearScratchCard();
        Invoke(nameof(PianoScore), 0.2f);
    }

    private void PianoScore()
    {
        // ToilHallWrapper.SetInt(CScream.sv_ad_trial_num, ToilHallWrapper.GetInt(CScream.sv_ad_trial_num) + 1);
        BeauWrapper.Instance.UtahRestart();
        PianoUIArid(GetType().Name);

        // PillarManager.Instance.StartLittleGameTimeBar();
        // NeedleWrapper.Instance.ReStartGame();
        // CrabWrapper.Instance.inLittleGame = false;
    }
}