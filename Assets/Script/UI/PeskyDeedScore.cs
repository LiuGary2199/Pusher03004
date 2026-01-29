// Project: Pusher
// FileName: PeskyDeedScore.cs
// Author: AX
// CreateDate: 20230803
// CreateTime: 15:55
// Description:

using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
using Spine.Unity;

public class PeskyDeedScore : LastUITruck
{
    public static PeskyDeedScore Instance;
[UnityEngine.Serialization.FormerlySerializedAs("luckyCardList")]
    public List<GameObject> CoralDeedGerm;
[UnityEngine.Serialization.FormerlySerializedAs("selectObjList")]    public List<GameObject> ImpendGelGerm;
[UnityEngine.Serialization.FormerlySerializedAs("rewardMap")]
    public Dictionary<NormalRewardType, double> SierraHay;
[UnityEngine.Serialization.FormerlySerializedAs("luckyObjDataList")]
    public List<LuckyObjData> CoralGelHallGerm;
[UnityEngine.Serialization.FormerlySerializedAs("isLock")]
    public bool WeOnly;
    private bool WeDeer;
[UnityEngine.Serialization.FormerlySerializedAs("onThanksWeight")]
    public int onLaunchFrench;
[UnityEngine.Serialization.FormerlySerializedAs("titleAnim")]
    public SkeletonGraphic SpaceFair;

    private int GiftPupil;
    private int LipViePupil;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        LipViePupil = MudHourJaw.instance.UtahHall.base_config.lucky_card_win_max_count;
    }

    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        TirePeskyDeed();
        SpaceFair.AnimationState.SetAnimation(0, "chuxian", false);
        SpaceFair.AnimationState.AddAnimation(0, "daiji", true, 0f);
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_littlegame_show);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }

    private void Start()
    {
        CorrectFingerSpoil.YewVocation().Magnetic(CScream.Ask_Chain_Brawl_Toe_Loess,
            (messageData) => { PianoPeskyDeedScore(); });
    }

    private void PianoPeskyDeedScore()
    {
        if (!gameObject.activeInHierarchy) return;
        PianoUIArid(GetType().Name);
    }

    public void TirePeskyDeed()
    {
        GiftPupil = Random.Range(2, LipViePupil) + 1;
        CoralGelHallGerm = new List<LuckyObjData>();

        WeOnly = true;
        WeDeer = false;
        for (int i = 0; i < CoralDeedGerm.Count; i++)
        {
            GameObject obj = CoralDeedGerm[i].gameObject;
            if (i == 4)
            {
                obj.GetComponent<PeskyDeedDelectable>().TireLaunchGelHall();
            }
            else
            {
                LuckyObjData objData = GameUtil.GetLuckyCardObjData();
                CoralGelHallGerm.Add(objData);
                obj.GetComponent<PeskyDeedDelectable>().TireSunlitGelHall(objData);
            }

            obj.GetComponent<PeskyDeedDelectable>().Ox_Down.SetActive(false);
        }

        ImpendGelGerm = new List<GameObject>();
        SierraHay = new Dictionary<NormalRewardType, double>();

        Invoke(nameof(AxAil), 3f);
    }


    private void AxAil()
    {
        float TingeFast= 0.5f;

        for (int i = 0; i < CoralDeedGerm.Count; i++)
        {
            GameObject obj = CoralDeedGerm[i].gameObject;
            Vector3 objPos = obj.transform.localPosition;

            //obj.GetComponent<PeskyDeedDelectable>().CloseObj(); 
            obj.GetComponent<PeskyDeedDelectable>().CradLandslide(obj, obj.GetComponent<PeskyDeedDelectable>().BG,
                obj.GetComponent<PeskyDeedDelectable>().SoMob, () => { },
                () =>
                {
                    obj.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                    {
                        obj.transform.DOLocalMove(objPos, 0.5f).SetDelay(TingeFast);
                    });
                });
            TingeFast = +0.1f;
        }

        Invoke(nameof(DownOnly), 2f);
    }

    private void DownOnly()
    {
        WeOnly = false;
    }

    private void YewSunlitHay(LuckyObjData rewardObj)
    {
        string type = rewardObj.LuckyObjType.ToString();
        NormalRewardType SierraFist= (NormalRewardType) Enum.Parse(typeof(NormalRewardType), type);
        if (SierraHay.ContainsKey(SierraFist))
        {
            SierraHay[SierraFist] =
                SierraHay[SierraFist] + rewardObj.RewardNum;
        }
        else
        {
            SierraHay.Add(SierraFist, rewardObj.RewardNum);
        }
    }

    private void SinkKrillScore()
    {
        for (int i = 0; i < CoralDeedGerm.Count; i++)
        {
            GameObject obj = CoralDeedGerm[i].gameObject;
            obj.GetComponent<PeskyDeedDelectable>().Ox_Down.SetActive(false);
        }
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_Stir, "1011");
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_It_To,"4");
        SunlitScoreWrapper.Instance.SinkDemiseSunlitScore(SierraHay);
    }

    public void YewHamlinGerm(GameObject obj)
    {
        ImpendGelGerm.Add(obj);

        if (ImpendGelGerm.Count < GiftPupil && !WeDeer)
        {
            int num = Random.Range(0, CoralGelHallGerm.Count);
            LuckyObjData objData = CoralGelHallGerm[num];
            obj.GetComponent<PeskyDeedDelectable>().CradLandslide(obj, obj.GetComponent<PeskyDeedDelectable>().SoMob,
                obj.GetComponent<PeskyDeedDelectable>().BG, () =>
                {
                    obj.GetComponent<PeskyDeedDelectable>().Ox_Down.SetActive(true);
                    obj.GetComponent<PeskyDeedDelectable>().TireSunlitGelHall(objData);
                }, () => { });
            YewSunlitHay(objData);
            CoralGelHallGerm.Remove(objData);
        }
        else
        {
            OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_scratch_reward);
            WeDeer = true;
            WeOnly = true;
            obj.GetComponent<PeskyDeedDelectable>().CradLandslide(obj, obj.GetComponent<PeskyDeedDelectable>().SoMob,
                obj.GetComponent<PeskyDeedDelectable>().BG,
                () => { obj.GetComponent<PeskyDeedDelectable>().TireLaunchGelHall(); }, () => { });
            Invoke(nameof(SinkKrillScore), 2f);
        }
    }
}