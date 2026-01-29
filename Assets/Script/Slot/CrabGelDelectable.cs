// Project: Plinko
// FileName: CrabGelDelectable.cs
// Author: AX
// CreateDate: 20230512
// CreateTime: 14:21
// Description:

using System;
using UnityEngine;
using UnityEngine.UI;

public class CrabGelDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("BigWin")]    public GameObject TinVas;
[UnityEngine.Serialization.FormerlySerializedAs("Cash_1")]    public GameObject Such_1;
[UnityEngine.Serialization.FormerlySerializedAs("Cash_2")]    public GameObject Such_2;
[UnityEngine.Serialization.FormerlySerializedAs("Cash_3")]    public GameObject Such_3;
[UnityEngine.Serialization.FormerlySerializedAs("SkillWall")]    public GameObject CourtLake;
[UnityEngine.Serialization.FormerlySerializedAs("SkillBigCoin")]    public GameObject CourtTinKind;
[UnityEngine.Serialization.FormerlySerializedAs("SkillLong")]    public GameObject CourtFall;
[UnityEngine.Serialization.FormerlySerializedAs("GemBlue")]    public GameObject TieEven;
[UnityEngine.Serialization.FormerlySerializedAs("GemRed")]    public GameObject TieZoo;
[UnityEngine.Serialization.FormerlySerializedAs("GemDiamond")]    public GameObject TieHeroism;
[UnityEngine.Serialization.FormerlySerializedAs("Golden")]    public GameObject Concur;
[UnityEngine.Serialization.FormerlySerializedAs("slotObjData")]
    //public Text numText;

    public SlotRewardType PestGelHall;


    public void TireHallTanker()
    {
        PestGelHall = GameUtil.GetSlotObjDataWithOutThanks();
        TireHallAnHall(PestGelHall);
    }

    public void TireHallAnHall(SlotRewardType targetObj)
    {
        //if (KettleSure.IsApple())
        //{
        //    if (targetObj.SlotObjType == SlotObjType.Cash)
        //    {
        //        targetObj.SlotObjType = SlotObjType.Ball;
        //    }
        //}

        PestGelHall = targetObj;
        PianoRed();
        SinkRed();
    }


    private void PianoRed()
    {
        TinVas.gameObject.SetActive(false);
        Such_1.gameObject.SetActive(false);
        Such_2.gameObject.SetActive(false);
        Such_3.gameObject.SetActive(false);
        CourtLake.gameObject.SetActive(false);
        CourtTinKind.gameObject.SetActive(false);
        CourtFall.gameObject.SetActive(false);
        TieEven.gameObject.SetActive(false);
        TieZoo.gameObject.SetActive(false);
        TieHeroism.gameObject.SetActive(false);
        Concur.gameObject.SetActive(false);
    }


    private void SinkRed()
    {
        switch (PestGelHall)
        {
            case SlotRewardType.BigWin:
                TinVas.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.Cash1:
                Such_1.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.Cash2:
                Such_2.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.Cash3:
                Such_3.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.SkillWall:
                CourtLake.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.SkillBigCoin:
                CourtTinKind.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.SkillLong:
                CourtFall.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.GemBlue:
                TieEven.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.GemRed:
                TieZoo.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            case SlotRewardType.GemDiamond:
                TieHeroism.gameObject.SetActive(true);
                //numText.text = slotObjData.RewardNum + "";
                break;
            default:
                Concur.gameObject.SetActive(true);
                //numText.text = "";
                break;
        }
    }
}