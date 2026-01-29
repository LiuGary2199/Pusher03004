// Project: Plinko
// FileName: TinVasKrillScore.cs
// Author: AX
// CreateDate: 20230510
// CreateTime: 16:00
// Description:

using System;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class TinVasKrillScore : LastUITruck
{
    public static TinVasKrillScore Instance;
[UnityEngine.Serialization.FormerlySerializedAs("bigWinBGAnim")]
    public SkeletonGraphic LysVasBGFair;
[UnityEngine.Serialization.FormerlySerializedAs("bigWinWordAnim")]    public SkeletonGraphic LysVasDoomFair;
[UnityEngine.Serialization.FormerlySerializedAs("getMoreBtn")]
    public Button EraTiltFew;
[UnityEngine.Serialization.FormerlySerializedAs("getBtn")]    public Button EraFew;
[UnityEngine.Serialization.FormerlySerializedAs("adImg")]
    public GameObject adRed;
[UnityEngine.Serialization.FormerlySerializedAs("getBtnText")]    public GameObject EraFewCent;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]
    public GameObject FlapRed;
[UnityEngine.Serialization.FormerlySerializedAs("rewardText")]
    public Text SierraCent;
[UnityEngine.Serialization.FormerlySerializedAs("bigWinType")]
    public BigWinType LysVasFist;
[UnityEngine.Serialization.FormerlySerializedAs("rewardNum")]
    public double SierraBed;

    private string AdornFist;

    public override void Display()
    {
        base.Display();
        //OfferJaw.GetInstance().PlayEffect(OfferFist.UIMusic.sound_bigwin2_open);
    }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void Start()
    {
        EraTiltFew.onClick.AddListener(() =>
        {
            if (ToilHallWrapper.YewCarpet(CScream.If_Loess_Roam_Lip_Sierra) == "new")
            {
                ToilHallWrapper.HubCarpet(CScream.If_Loess_Roam_Lip_Sierra, "done");
                ToilHallWrapper.HubCarpet(CScream.If_Loess_Ere_Ant, "done");

             //   CorrectFingerSpoil.YewVocation().Pool(CScream.Ask_Hero_Flap_Fair);
                YewSunlit();
            }
            else
            {
                ADWrapper.Vocation.DeepSunlitBleak((success) =>
                {
                    if (success)
                    {
                        AdornFist = "1";
                        YewSunlit();
                    }
                }, "2");
            }
        });

        EraFew.onClick.AddListener(() =>
        {
            AdornFist = "0";
            ADWrapper.Vocation.WeLaunchYewPupil();
            PianoScore();
        });
    }

    public void TireHall(double num)
    {
        ADWrapper.Vocation.DecayFastHelplessness();
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_bigwin2_open);
        SierraBed = num;
        SierraCent.text = "" + SierraBed;
        TireFair();

        if (ToilHallWrapper.YewCarpet(CScream.If_Loess_Roam_Lip_Sierra) == "new")
        {
            EraFew.gameObject.SetActive(false);
            adRed.gameObject.SetActive(false);
            EraFewCent.transform.localPosition = new Vector3(0f, 0f, 0f);
            ToilHallWrapper.HubSow(CScream.If_It_trial_Fox, ToilHallWrapper.YewSow(CScream.If_It_trial_Fox) + 1);
        }
        else
        {
            EraFewCent.transform.localPosition = new Vector3(37f, 0f, 0f);
            adRed.gameObject.SetActive(true);
            EraFew.gameObject.SetActive(true);
            EraFew.GetComponent<CanvasGroup>().alpha = 0f;
            EraFew.enabled = false;

            DOTween.To(x => EraFew.GetComponent<CanvasGroup>().alpha = x, 0, 1, 0.3f).SetDelay(2f).OnComplete(() =>
            {
                EraFew.enabled = true;
            });
        }
    }


    private void TireFair()
    {
        LysVasBGFair.AnimationState.SetAnimation(0, "chuxian", false);
        LysVasBGFair.AnimationState.AddAnimation(0, "daiji", true, 0f);
        switch (LysVasFist)
        {
            case BigWinType.BigWin:
                LysVasDoomFair.AnimationState.SetAnimation(0, "Big_chuxian", false);
                LysVasDoomFair.AnimationState.AddAnimation(0, "Big_daiji", true, 0f);

                break;
            case BigWinType.HugeWin:
                LysVasDoomFair.AnimationState.SetAnimation(0, "Huge_chuxian", false);
                LysVasDoomFair.AnimationState.AddAnimation(0, "Huge_daiji", true, 0f);
                break;
            default:
                LysVasDoomFair.AnimationState.SetAnimation(0, "Mega_chuxian", false);
                LysVasDoomFair.AnimationState.AddAnimation(0, "Mega_daiji", true, 0f);
                break;
        }
    }


    private void YewSunlit()
    {
        AdornFist = "1";

        UtahScore.Instance.YewSuch(SierraBed, transform);

        // LandslideDelectable.CollectAni(UtahScore.Instance.cashImg.transform.position,
        //     Resources.Load<GameObject>("Art/FX/RewardImage"), new Vector3(0, 0, 0), UtahScore.Instance.transform,
        //     () => { });
        PianoScore();
    }

    private void PianoScore()
    {
        if (ToilHallWrapper.YewCarpet(CScream.Ask_Hero_Tine_us) == "new")
        {
            ToilHallWrapper.HubCarpet(CScream.Ask_Hero_Tine_us, "done");
            CorrectFingerSpoil.YewVocation().Pool(CScream.Ask_Hero_Tine_us);
        }

        CorrectFingerSpoil.YewVocation().Pool(CScream.Ask_Chain_Brawl_Toe_Loess);

        DaleBulgeScript.YewVocation().PoolBulge("1007", AdornFist,SierraBed.ToString());
        PianoUIArid(GetType().Name);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }
}