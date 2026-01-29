// Project: Pusher
// FileName: NonstopGelDelectable.cs
// Author: AX
// CreateDate: 20230809
// CreateTime: 10:42
// Description:

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonstopGelDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("getBtn")]    public Button EraFew;
[UnityEngine.Serialization.FormerlySerializedAs("btnBgY")]    public Image EggByY;
[UnityEngine.Serialization.FormerlySerializedAs("silverImg")]
    public GameObject PeopleRed;
[UnityEngine.Serialization.FormerlySerializedAs("blueImg")]    public GameObject SlabRed;
[UnityEngine.Serialization.FormerlySerializedAs("yellowImg")]    public GameObject SliderRed;
[UnityEngine.Serialization.FormerlySerializedAs("goldBarImg")]    public GameObject SlowRodRed;
[UnityEngine.Serialization.FormerlySerializedAs("goldImg")]
    public Image SlowRed;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]    public Image FlapRed;
[UnityEngine.Serialization.FormerlySerializedAs("amazonImg")]    public Image MagnetRed;
[UnityEngine.Serialization.FormerlySerializedAs("sliderProgress")]
    public Image UnwellSquirrel;
[UnityEngine.Serialization.FormerlySerializedAs("gemsNum")]    public Text TwigBed;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text DirectorCent;
[UnityEngine.Serialization.FormerlySerializedAs("rewardNumText")]    public Text SierraBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("maxNum")]
    public int AlpBed;
[UnityEngine.Serialization.FormerlySerializedAs("currentNum")]    public int SurmiseBed;
[UnityEngine.Serialization.FormerlySerializedAs("gemsDataItem")]
    public GemsDataItem TwigHallGate;
    private GemsType GiftTieFist;
    private RewardType SierraFist;

    
    private Dictionary<NormalRewardType, double> SierraHay;

    private void Start()
    {
        EraFew.onClick.AddListener(() =>
        {
            if (!EggByY.gameObject.activeInHierarchy)
            {
                return;
            }

            YewSunlit();
        });
    }

    private void PianoBarnRed()
    {
        PeopleRed.gameObject.SetActive(false);
        SlabRed.gameObject.SetActive(false);
        SliderRed.gameObject.SetActive(false);
        SlowRodRed.gameObject.SetActive(false);
    }

    private void SinkBarnRed()
    {
        switch (GiftTieFist)
        {
            case GemsType.Silver:
                PeopleRed.gameObject.SetActive(true);
                break;
            case GemsType.Blue:
                SlabRed.gameObject.SetActive(true);
                break;
            case GemsType.Yellow:
                SliderRed.gameObject.SetActive(true);
                break;
            default:
                SlowRodRed.gameObject.SetActive(true);
                break;
        }
    }

    private void PianoSunlitRed()
    {
        SlowRed.gameObject.SetActive(false);
        FlapRed.gameObject.SetActive(false);
        MagnetRed.gameObject.SetActive(false);
    }

    private void SinkSunlitRed()
    {
        switch (SierraFist)
        {
            case RewardType.Gold:
                SlowRed.gameObject.SetActive(true);
                break;
            case RewardType.Cash:
                FlapRed.gameObject.SetActive(true);
                break;
            default:
                MagnetRed.gameObject.SetActive(true);
                break;
        }
    }

    public void TireHall()
    {
        GiftTieFist = (GemsType) Enum.Parse(typeof(GemsType), TwigHallGate.gem_type);
        SierraFist = (RewardType) Enum.Parse(typeof(RewardType), TwigHallGate.reward_type);
        SierraBedCent.text = TwigHallGate.reward_num + "";

        if (KettleSure.HeYield())
        {
            SierraFist = RewardType.Gold;
        }

        PianoBarnRed();
        SinkBarnRed();
        PianoSunlitRed();
        SinkSunlitRed();

        SurmiseBed = ToilHallWrapper.YewSow(GiftTieFist.ToString());
        AlpBed = TwigHallGate.gem_limit;

        DirectorCent.text = (SurmiseBed < AlpBed ? SurmiseBed : AlpBed) + "/" + AlpBed;
        TwigBed.text = "x " + AlpBed;
        UnwellSquirrel.fillAmount = (SurmiseBed < AlpBed ? SurmiseBed : AlpBed) * 1.0f / AlpBed;
        EggByY.gameObject.SetActive(SurmiseBed >= AlpBed);
    }


    public void YewSunlit()
    {
        
        SierraHay = new Dictionary<NormalRewardType, double>();
        NormalRewardType SierraFist= (NormalRewardType) Enum.Parse(typeof(NormalRewardType), TwigHallGate.reward_type);
        SierraHay.Add(SierraFist, TwigHallGate.reward_num);
        
        SurmiseBed = 0;
        ToilHallWrapper.HubSow(GiftTieFist.ToString(),0);
        // InitData();
        // UIGrimly.GetInstance().CloseOrReturnUIForms(GetType().Name);
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_It_To,"7");
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_Stir, "1014");
        ToilHallWrapper.HubCarpet(CScream.If_Twig_Stir, GiftTieFist.ToString());
        SunlitScoreWrapper.Instance.SinkDemiseSunlitScore(SierraHay);
        
    }
}