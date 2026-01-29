// Project: Plinko
// FileName: ExecuteGelDelectable.cs
// Author: AX
// CreateDate: 20230522
// CreateTime: 10:13
// Description:

using System;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteGelDelectable : MonoBehaviour
{
    public static ExecuteGelDelectable Instance;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]
    public GameObject FlapRed;
[UnityEngine.Serialization.FormerlySerializedAs("goldImg")]    public GameObject SlowRed;
[UnityEngine.Serialization.FormerlySerializedAs("amazonImg")]    public GameObject MagnetRed;
[UnityEngine.Serialization.FormerlySerializedAs("circleImg")]    public GameObject WalnutRed;
[UnityEngine.Serialization.FormerlySerializedAs("mainNumText")]
    public Text LineBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("rewardNumText")]    public Text SierraBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("mainNum")]
    public int LineBed;
[UnityEngine.Serialization.FormerlySerializedAs("rewardNum")]    public double SierraBed;
[UnityEngine.Serialization.FormerlySerializedAs("scratchObjData")]
    public ScratchObjData GhostlyGelHall;

    private void Awake()
    {
        Instance = this;
    }


    private void PianoRed()
    {
        SlowRed.gameObject.SetActive(false);
        FlapRed.gameObject.SetActive(false);
        MagnetRed.gameObject.SetActive(false);
        WalnutRed.gameObject.SetActive(false);
    }

    private void SinkRed()
    {
        switch (GhostlyGelHall.ScratchObjType)
        {
            case ScratchObjType.Amazon:
                SierraBed = GhostlyGelHall.RewardNum * GameUtil.GetAmazonMulti();
                SierraBedCent.text = "" + SierraBed;
                MagnetRed.gameObject.SetActive(true);
                break;
            case ScratchObjType.Cash:
                double cashNum = GhostlyGelHall.RewardNum * GameUtil.GetCashMultiWithOutRandom();
                SierraBed = Math.Round(cashNum, 2);
                SierraBedCent.text = "" + SierraBed;
                FlapRed.gameObject.SetActive(true);
                break;
            default:
                SierraBed = GhostlyGelHall.RewardNum * GameUtil.GetGoldMulti();
                SierraBedCent.text = "" + SierraBed;
                SlowRed.gameObject.SetActive(true);
                break;
        }
        GhostlyGelHall.RewardNum = SierraBed;
    }

    public void SinkRavage()
    {
        // OfferJaw.GetInstance().PlayEffect(OfferFist.UIMusic.sound_scratch_reward);
        WalnutRed.gameObject.SetActive(true);
        LineBedCent.color = new Color(1f, 1f, 0f);
    }

    public void TireHall(int num, bool isRewardNumber = false)
    {
        LineBed = num;
        LineBedCent.text = num + "";
        LineBedCent.color = new Color(1f, 1f, 1f);
        if (isRewardNumber)
        {
            GhostlyGelHall = GameUtil.GetScratchObjData();
        }
        else
        {
            int Giant= MudHourJaw.instance.UtahHall.scratch_data_list.Count;
            ScratchDataItem item = MudHourJaw.instance.UtahHall.scratch_data_list[UnityEngine.Random.Range(0, Giant)];
            GhostlyGelHall = new ScratchObjData();
            GhostlyGelHall.RewardNum = item.reward_num;
            GhostlyGelHall.ScratchObjType = (ScratchObjType)Enum.Parse(typeof(ScratchObjType), item.type);
        }

        if (KettleSure.HeYield())
        {
            GhostlyGelHall.ScratchObjType = ScratchObjType.Gold;
        }

        PianoRed();
        SinkRed();
    }
}