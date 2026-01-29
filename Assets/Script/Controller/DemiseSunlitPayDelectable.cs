// Project: Plinko
// FileName: DemiseSunlitPayDelectable.cs
// Author: AX
// CreateDate: 20230522
// CreateTime: 16:53
// Description:

using System;
using UnityEngine;
using UnityEngine.UI;

public class DemiseSunlitPayDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("goldImg")]    public GameObject SlowRed;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]    public GameObject FlapRed;
[UnityEngine.Serialization.FormerlySerializedAs("amazonImg")]    public GameObject MagnetRed;
[UnityEngine.Serialization.FormerlySerializedAs("rollCashImg")]    public GameObject BossCashRed;
[UnityEngine.Serialization.FormerlySerializedAs("rewardNumText")]
    public Text SierraBedCent;

    private NormalRewardType SierraFist;
    private double SierraBed;


    public void TireHall(NormalRewardType thisType, double num)
    {
        SierraFist = thisType;
        SierraBed = num;
        PianoRed();
        SinkRed();
        SierraBedCent.text = "+ " + SierraBed;
    }


    private void PianoRed()
    {
        SlowRed.gameObject.SetActive(false);
        FlapRed.gameObject.SetActive(false);
        MagnetRed.gameObject.SetActive(false);
        BossCashRed.gameObject.SetActive(false);
    }

    private void SinkRed()
    {
        switch (SierraFist)
        {
            case NormalRewardType.Amazon:
                MagnetRed.gameObject.SetActive(true);
                break;
            case NormalRewardType.Cash:
                FlapRed.gameObject.SetActive(true);
                break;
            case NormalRewardType.RollCash:
                BossCashRed.gameObject.SetActive(true);
                break;
            default:
                SlowRed.gameObject.SetActive(true);
                break;
        }
    }

    public void BalticBedFair(int multi)
    {
        LandslideDelectable.BalticDisuse(SierraBed, SierraBed * multi, 0, SierraBedCent, "+", () =>
        {
            SierraBed = SierraBed * multi;
            SierraBedCent.text = "+" + DisuseSure.IndigoMeLap(SierraBed);
        });
    }


    public void YewDemiseVasSunlit()
    {
        switch (SierraFist)
        {
            case NormalRewardType.Amazon:
                UtahScore.Instance.YewEither(SierraBed, MagnetRed.transform);
                break;
            case NormalRewardType.Cash:
                UtahScore.Instance.YewSuch(SierraBed, FlapRed.transform);
                break;
            case NormalRewardType.RollCash:
                UtahScore.Instance.YewSuch(SierraBed, FlapRed.transform);
                break;
            default:
                UtahScore.Instance.YewNeon(SierraBed, SlowRed.transform);
                break;
        }
    }
}