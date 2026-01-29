// Project: Plinko
// FileName: DemiseVasKrillScore.cs
// Author: AX
// CreateDate: 20230515
// CreateTime: 16:01
// Description:

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Spine.Unity;

public class DemiseVasKrillScore : LastUITruck
{
    public static DemiseVasKrillScore Instance;
[UnityEngine.Serialization.FormerlySerializedAs("normalSlot")]
    public DemiseCrabDelectable PromptCrab;
[UnityEngine.Serialization.FormerlySerializedAs("getMoreBtn")]
    public Button EraTiltFew;
[UnityEngine.Serialization.FormerlySerializedAs("getBtn")]    public Button EraFew;
[UnityEngine.Serialization.FormerlySerializedAs("rewardPop01")]
    public GameObject SierraPay01;
[UnityEngine.Serialization.FormerlySerializedAs("rewardPop02")]    public GameObject SierraPay02;
[UnityEngine.Serialization.FormerlySerializedAs("rewardPop03")]    public GameObject SierraPay03;
[UnityEngine.Serialization.FormerlySerializedAs("titleAnim")]
    public SkeletonGraphic SpaceFair;


    private Dictionary<NormalRewardType, double> SierraHay;


    private string AdornFist;

    private string Rayon2;
    private string Rayon3;

    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        //OfferJaw.GetInstance().PlayEffect(OfferFist.UIMusic.sound_bigwin1_open);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }
    private void Start()
    {
        EraTiltFew.onClick.AddListener(() =>
        {
            ADWrapper.Vocation.DeepSunlitBleak((success) =>
            {
                if (success)
                {
                    AdornFist = "1";
                    EraTiltFew.gameObject.SetActive(false);
                    EraFew.gameObject.SetActive(false);
                    BillCrab();
                }
            },    ToilHallWrapper.YewCarpet(CScream.If_Prompt_Lip_It_To));
        });

        EraFew.onClick.AddListener(() =>
        {
            ADWrapper.Vocation.WeLaunchYewPupil();
            AdornFist = "0";
            YewSunlit();
        });
    }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        SierraHay = new Dictionary<NormalRewardType, double>();
    }

    public void TireHall(Dictionary<NormalRewardType, double> map)
    {
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_bigwin1_open);

        SpaceFair.AnimationState.SetAnimation(0, "chuxian", false);
        SpaceFair.AnimationState.AddAnimation(0, "daiji", true, 0f);

        PromptCrab.TireDrive();
        EraTiltFew.gameObject.SetActive(true);
        EraFew.gameObject.SetActive(true);
        EraFew.GetComponent<CanvasGroup>().alpha = 0f;
        EraFew.enabled = false;

        DOTween.To(x => EraFew.GetComponent<CanvasGroup>().alpha = x, 0, 1, 0.3f).SetDelay(2f).OnComplete(() =>
        {
            EraFew.enabled = true;
        });
        SierraHay = map;

        SierraPay02.gameObject.SetActive(false);
        SierraPay02.gameObject.SetActive(false);
        SierraPay03.gameObject.SetActive(false);
        SierraPay01.transform.localScale = new Vector3(1f, 1f, 1f);
        SierraPay02.transform.localScale = new Vector3(1f, 1f, 1f);
        SierraPay03.transform.localScale = new Vector3(1f, 1f, 1f);

        List<NormalRewardType> keyList = new List<NormalRewardType>();
        List<double> valueList = new List<double>();

        foreach (var item in SierraHay)
        {
            keyList.Add(item.Key);
            valueList.Add(item.Value);
        }

        if (SierraHay.Count == 1)
        {
            SierraPay01.transform.localPosition = new Vector3(0f, 380f, 0f);
            SierraPay01.transform.localScale *= 1.2f;
            SierraPay01.gameObject.SetActive(true);
            SierraPay01.gameObject.GetComponent<DemiseSunlitPayDelectable>().TireHall(keyList[0], valueList[0]);
            Rayon2 = valueList[0].ToString();
            Rayon3 = YewChalk3(keyList[0]);
        }

        if (SierraHay.Count == 2)
        {
            SierraPay01.transform.localPosition = new Vector3(-220f, 350f, 0f);
            SierraPay02.transform.localPosition = new Vector3(220f, 350f, 0f);

            SierraPay01.gameObject.SetActive(true);
            SierraPay02.gameObject.SetActive(true);
            SierraPay01.gameObject.GetComponent<DemiseSunlitPayDelectable>().TireHall(keyList[0], valueList[0]);
            SierraPay02.gameObject.GetComponent<DemiseSunlitPayDelectable>().TireHall(keyList[1], valueList[1]);
            Rayon2 = "0";
            Rayon3 = "0";
            for (int i = 0; i < keyList.Count; i++)
            {
                if (keyList[i] == NormalRewardType.Cash)
                {
                    Rayon2 = valueList[i].ToString();
                    Rayon3 = "1";
                }
            }
        }

        if (SierraHay.Count == 3)
        {
            SierraPay01.transform.localPosition = new Vector3(0f, 500f, 0f);
            SierraPay02.transform.localPosition = new Vector3(-240f, 250f, 0f);
            SierraPay03.transform.localPosition = new Vector3(240f, 250f, 0f);

            SierraPay01.transform.localScale *= 0.8f;
            SierraPay02.transform.localScale *= 0.8f;
            SierraPay03.transform.localScale *= 0.8f;

            SierraPay01.gameObject.SetActive(true);
            SierraPay02.gameObject.SetActive(true);
            SierraPay03.gameObject.SetActive(true);

            SierraPay01.gameObject.GetComponent<DemiseSunlitPayDelectable>().TireHall(keyList[0], valueList[0]);
            SierraPay02.gameObject.GetComponent<DemiseSunlitPayDelectable>().TireHall(keyList[1], valueList[1]);
            SierraPay03.gameObject.GetComponent<DemiseSunlitPayDelectable>().TireHall(keyList[2], valueList[2]);

            Rayon2 = "0";
            Rayon3 = "0";
            for (int i = 0; i < keyList.Count; i++)
            {
                if (keyList[i] == NormalRewardType.Cash)
                {
                    Rayon2 = valueList[i].ToString();
                    Rayon3 = "1";
                }
            }
        }
    }

    private int YewCrabPeart()
    {
        int sumWeight = 0;
        foreach (RewardMultiItem wg in MudHourJaw.instance.TireHall.RewardMultiList)
        {
            sumWeight += wg.weight;
        }

        int r = Random.Range(0, sumWeight);
        int nowWeight = 0;
        int Shock= 0;
        foreach (RewardMultiItem wg in MudHourJaw.instance.TireHall.RewardMultiList)
        {
            nowWeight += wg.weight;
            if (nowWeight > r)
            {
                return Shock;
            }

            Shock++;
        }

        return 0;
    }


    private string YewChalk3(NormalRewardType type)
    {
        switch (type)
        {
            case NormalRewardType.Cash:
                return "1";
            case NormalRewardType.Gold:
                return "2";
            default:
                return "3";
        }
    }


    private void BillCrab()
    {
        int Shock= YewCrabPeart();
        PromptCrab.WorkCrab(Shock, (multi) =>
        {
            if (SierraPay01.activeInHierarchy)
            {
                SierraPay01.gameObject.GetComponent<DemiseSunlitPayDelectable>().BalticBedFair(multi);
            }

            if (SierraPay02.activeInHierarchy)
            {
                SierraPay02.gameObject.GetComponent<DemiseSunlitPayDelectable>().BalticBedFair(multi);
            }

            if (SierraPay03.activeInHierarchy)
            {
                SierraPay03.gameObject.GetComponent<DemiseSunlitPayDelectable>().BalticBedFair(multi);
            }

            Invoke(nameof(YewSunlit), 1f);
        });
    }

    private void PianoDemiseScore()
    {
        if (ToilHallWrapper.YewCarpet(CScream.If_Prompt_Lip_Stir) == "1014")
        {
            Rayon3 = "1";
            String gemType = ToilHallWrapper.YewCarpet(CScream.If_Twig_Stir);
            switch (gemType)
            {
                case "Yellow":
                    Rayon3 = "1";
                    break;
                case "Blue":
                    Rayon3 = "2";
                    break;
                case "Silver":
                    Rayon3 = "3";
                    break;
                default:
                    Rayon3 = "4";
                    break;
            }

            DaleBulgeScript.YewVocation()
                .PoolBulge(ToilHallWrapper.YewCarpet(CScream.If_Prompt_Lip_Stir), AdornFist, Rayon2, Rayon3);
        }
        else
        {
            DaleBulgeScript.YewVocation()
                .PoolBulge(ToilHallWrapper.YewCarpet(CScream.If_Prompt_Lip_Stir), AdornFist, Rayon2, Rayon3);
        }

        CorrectFingerSpoil.YewVocation().Pool(CScream.Ask_Chain_Brawl_Toe_Loess);
        // CorrectFingerSpoil.GetInstance().Send(CScream.msg_show_cash_mask);

        PianoUIArid(GetType().Name);
    }

    private void YewSunlit()
    {
        if (SierraPay01.activeInHierarchy)
        {
            SierraPay01.gameObject.GetComponent<DemiseSunlitPayDelectable>().YewDemiseVasSunlit();
        }

        if (SierraPay02.activeInHierarchy)
        {
            SierraPay02.gameObject.GetComponent<DemiseSunlitPayDelectable>().YewDemiseVasSunlit();
        }

        if (SierraPay03.activeInHierarchy)
        {
            SierraPay03.gameObject.GetComponent<DemiseSunlitPayDelectable>().YewDemiseVasSunlit();
        }

        PianoDemiseScore();
    }
}