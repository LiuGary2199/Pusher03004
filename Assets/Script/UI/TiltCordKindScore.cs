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
public class TiltCordKindScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("closeBtn")]    public Button ChainFew;
[UnityEngine.Serialization.FormerlySerializedAs("getRewardBtn")]    public Button EraSunlitFew;
[UnityEngine.Serialization.FormerlySerializedAs("ExchangeBtn")]    public Button CuspidorFew;
[UnityEngine.Serialization.FormerlySerializedAs("NoExchangeBtn")]    public GameObject NoCuspidorFew;
[UnityEngine.Serialization.FormerlySerializedAs("adImg")]
    public GameObject adRed;
[UnityEngine.Serialization.FormerlySerializedAs("getBtnText")]
    public GameObject EraFewCent;
[UnityEngine.Serialization.FormerlySerializedAs("ballNum")]
    public Text LuceBed;
[UnityEngine.Serialization.FormerlySerializedAs("NeedNum")]    public Text SiteBed;
[UnityEngine.Serialization.FormerlySerializedAs("needNum")]    public int CornBed;
    private string AdornFist;


    private void Start()
    {
        SiteBed.text = CornBed.ToString();
        ChainFew.onClick.AddListener(() =>
        {
            AdornFist = "0";
            ADWrapper.Vocation.WeLaunchYewPupil();
            PianoWellScore();
        });

        CuspidorFew.onClick.AddListener(() =>
        {
            double coincount = UtahHallWrapper.YewVocation().YewNeon();
            if (coincount >= CornBed)
            {
                UtahHallWrapper.YewVocation().YewNeon(-CornBed);
                HeaveLifeWrapper.Instance.YewHeaveLife();
                //UtahScore.Instance.goldNumText.text = UtahHallWrapper.GetInstance().GetGold() + "";
                UtahScore.Instance.RubNeonBedCent.text = UtahHallWrapper.YewVocation().YewNeon() + "";
                PianoWellScore();
            }
        });

        EraSunlitFew.onClick.AddListener(() =>
        {
            if (!ToilHallWrapper.YewShop(CScream.If_Mislead_Gel_Luce))
            {
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
        double coincount = UtahHallWrapper.YewVocation().YewNeon();
        CuspidorFew.gameObject.SetActive(coincount >= CornBed);
        NoCuspidorFew.SetActive(coincount < CornBed);
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
            //closeBtn.gameObject.SetActive(false);
            EraFewCent.transform.localPosition = new Vector3(0f, 0f, 0f);

        }
        else
        {
            EraFewCent.transform.localPosition = new Vector3(37f, 0f, 0f);
            adRed.gameObject.SetActive(true);
            ChainFew.gameObject.SetActive(true);
           // closeBtn.GetComponent<CanvasGroup>().alpha = 0f;
           // closeBtn.enabled = false;


            //closeBtn.GetComponent<CanvasGroup>().alpha = 0f;
           // DOTween.To(x => closeBtn.GetComponent<CanvasGroup>().alpha = x, 0, 1, 0.3f).SetDelay(2f).OnComplete(() => { closeBtn.enabled = true; });
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
