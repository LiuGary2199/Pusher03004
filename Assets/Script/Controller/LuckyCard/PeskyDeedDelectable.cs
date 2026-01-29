// Project: Pusher
// FileName: PeskyDeedDelectable.cs
// Author: AX
// CreateDate: 20230803
// CreateTime: 15:54
// Description:

using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PeskyDeedDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("bgGold")]    public GameObject SoNeon;
[UnityEngine.Serialization.FormerlySerializedAs("bgSilver")]    public GameObject SoScrape;
[UnityEngine.Serialization.FormerlySerializedAs("bgTop")]    public GameObject SoMob;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]
    public GameObject FlapRed;
[UnityEngine.Serialization.FormerlySerializedAs("coinImg")]    public GameObject GulfRed;
[UnityEngine.Serialization.FormerlySerializedAs("amazonImg")]    public GameObject MagnetRed;
[UnityEngine.Serialization.FormerlySerializedAs("overImg")]    public GameObject RakeRed;
[UnityEngine.Serialization.FormerlySerializedAs("BG")]    public GameObject BG;
[UnityEngine.Serialization.FormerlySerializedAs("fx_Open")]    public GameObject Ox_Down;
[UnityEngine.Serialization.FormerlySerializedAs("rewardText")]
    public Text SierraCent;
[UnityEngine.Serialization.FormerlySerializedAs("rewardType")]
    public LuckyObjType SierraFist;
[UnityEngine.Serialization.FormerlySerializedAs("rewardNum")]    public double SierraBed;



    public void PianoGel()
    {
        PianoRed();
        //bgTop.gameObject.SetActive(true);
    }


    public void TireSunlitGelHall(LuckyObjData luckyObjData)
    {
        BG.SetActive(true);
        SierraFist = luckyObjData.LuckyObjType;
        SierraBed = luckyObjData.RewardNum;
        PianoRed();
        SierraCent.text = SierraBed+"";

        switch (SierraFist)
        {
            case LuckyObjType.Cash:
                FlapRed.gameObject.SetActive(true);
                break;
            case LuckyObjType.Gold:
                GulfRed.gameObject.SetActive(true);
                SoScrape.gameObject.SetActive(true);
                break;
            default:
                MagnetRed.gameObject.SetActive(true);
                SoScrape.gameObject.SetActive(true);
                break;
        }

    }

    public void TireLaunchGelHall()
    {
        BG.SetActive(true);
        PianoRed();
        RakeRed.gameObject.SetActive(true);
    }

    private void PianoRed()
    {
        SoMob.gameObject.SetActive(false);
        FlapRed.gameObject.SetActive(false);
        MagnetRed.gameObject.SetActive(false);
        GulfRed.gameObject.SetActive(false);
        SoScrape.gameObject.SetActive(false);
        RakeRed.gameObject.SetActive(false);
        SoNeon.gameObject.SetActive(true);
        
    }


    private void OnMouseOver()
    {
        if (SoMob.activeInHierarchy != true||PeskyDeedScore.Instance.WeOnly) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            //bgTop.gameObject.SetActive(false);
            OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.Sound_PopShow);
            PeskyDeedScore.Instance.YewHamlinGerm(gameObject);
        }
    }

    public void CradLandslide(GameObject Card, GameObject CardBack, GameObject CardFront,System.Action start, System.Action finish) 
    {
        Card.transform.DOScale(1.3f, 0.3f);
        Card.transform.DORotate(new Vector3(0, 90, 0), 0.3f).OnComplete(() =>
        {
            start();
            CardBack.SetActive(false);
            CardFront.SetActive(true);
            Card.transform.DOScale(1, 0.3f);
            Card.transform.DORotate(new Vector3(0, 0, 0), 0.3f).OnComplete(()=>
            {
                finish();
            });
        });
    }
}