// Project: Plinko
// FileName: TiltSunlitScore.cs
// Author: AX
// CreateDate: 20230510
// CreateTime: 10:00
// Description:

using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TiltSunlitScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("closeBtn")]    public Button ChainFew;
[UnityEngine.Serialization.FormerlySerializedAs("getRewardBtn")]    public Button EraSunlitFew;
[UnityEngine.Serialization.FormerlySerializedAs("GoldBtn")]    public Button NeonFew;
[UnityEngine.Serialization.FormerlySerializedAs("adImg")]    public GameObject adRed;
[UnityEngine.Serialization.FormerlySerializedAs("getBtnText")]    public GameObject EraFewCent;
[UnityEngine.Serialization.FormerlySerializedAs("ballNum")]
    public Text LuceBed;
[UnityEngine.Serialization.FormerlySerializedAs("needGoldNum")]    public Text CornNeonBed;


    private string AdornFist;


    private void Start()
    {
        ChainFew.onClick.AddListener(() =>
        {
            AdornFist = "0";
            ADWrapper.Vocation.WeLaunchYewPupil();
            PianoWellScore();
        });

        NeonFew.onClick.AddListener(() =>
        {
            int buyCount = PlayerPrefs.GetInt("MoneyBuyBall", 1);
            double coincount = UtahHallWrapper.YewVocation().YewNeon();
            double CornBed= buyCount * 50000;
            if (CornBed >= 300000)
            {
                CornBed = 300000;
            }
            if (coincount >= CornBed)
            {
                YewSunlit();
                UtahHallWrapper.YewVocation().YewNeon(-CornBed);
                PlayerPrefs.SetInt("MoneyBuyBall", buyCount + 1);
            }
            else 
            {
                EraSunlitFew.gameObject.SetActive(true);
                NeonFew.gameObject.SetActive(false);
            }
        });

        EraSunlitFew.onClick.AddListener(() =>
        {
            if (!ToilHallWrapper.YewShop(CScream.If_Mislead_Gel_Luce)) {
                ToilHallWrapper.HubShop(CScream.If_Mislead_Gel_Luce, true);
                YewSunlit();
            }
            else
            {
                ADWrapper.Vocation.DeepSunlitBleak((success) => {
                    if (success)
                    {
                        YewSunlit();
                    }
                }, "8");
            }
        });

        LuceBed.text = "" + MudHourJaw.instance.UtahHall.base_config.ball_limit;
    }


    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        // if (KettleSure.IsApple())
        // {
        //     adImg.gameObject.SetActive(false);
        //     getBtnText.transform.localPosition = new Vector3(37f, 0f, 0f);
        //     closeBtn.gameObject.SetActive(true);
        // }
        // else
        // {
        if (!ToilHallWrapper.YewShop(CScream.If_Mislead_Gel_Luce))
        {
            adRed.gameObject.SetActive(false);
            ChainFew.gameObject.SetActive(false);
            EraFewCent.transform.localPosition = new Vector3(0f, 0f, 0f);
            
        }
        else
        {
            EraFewCent.transform.localPosition = new Vector3(37f, 0f, 0f);
            adRed.gameObject.SetActive(true);
            ChainFew.gameObject.SetActive(true);
            ChainFew.GetComponent<CanvasGroup>().alpha = 0f;
            ChainFew.enabled = false;


            ChainFew.GetComponent<CanvasGroup>().alpha = 0f;
            DOTween.To(x => ChainFew.GetComponent<CanvasGroup>().alpha = x, 0, 1, 0.3f).SetDelay(2f)
                .OnComplete(() => { ChainFew.enabled = true; });

            int buyCount = PlayerPrefs.GetInt("MoneyBuyBall", 1);
            double coincount = UtahHallWrapper.YewVocation().YewNeon();
            double CornBed= buyCount * 50000;
            CornNeonBed.text = CornBed.ToString();
            if (CornBed >= 300000)
            {
                CornBed = 300000;
            }
            if (coincount >= CornBed)
            {
                EraSunlitFew.gameObject.SetActive(false);
                NeonFew.gameObject.SetActive(true);
            }
            else
            {
                EraSunlitFew.gameObject.SetActive(true);
                NeonFew.gameObject.SetActive(false);
            }
        }
        // }
    }

    private void YewSunlit()
    {
        AdornFist = "1";
        HeaveLifeWrapper.Instance.YewHeaveLife();
        PianoWellScore();
    }


    private void PianoWellScore()
    {
        DaleBulgeScript.YewVocation().PoolBulge("1015", AdornFist);
        BeauWrapper.Instance.UtahRestart();
        PianoUIArid(GetType().Name);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }
}