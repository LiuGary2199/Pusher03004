// Project: Plinko
// FileName: CrabWrapper.cs
// Author: AX
// CreateDate: 20230512
// CreateTime: 11:26
// Description:

using System;
using System.Collections;
using System.IO;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using Lofelt.NiceVibrations;
using UnityEngine;

public class CrabWrapper : MonoBehaviour
{
    public static CrabWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("slotGroup01")]
    public GameObject PestCreep01;
[UnityEngine.Serialization.FormerlySerializedAs("slotGroup02")]    public GameObject PestCreep02;
[UnityEngine.Serialization.FormerlySerializedAs("slotGroup03")]    public GameObject PestCreep03;
[UnityEngine.Serialization.FormerlySerializedAs("inLittleGame")]
    public bool NoLocaleUtah;

    private SlotRewardType PestGelHall;

    private bool CliffMust;
    private bool WePass;

    private Sequence PestFin;

    private void Awake()
    {
        Instance = this;
        CliffMust = false;
        WePass = false;
    }

    public void GeneticCrabCreep()
    {
        PestCreep01.transform.localPosition = new Vector3(-0.88f, 0, 0);
        PestCreep02.transform.localPosition = new Vector3(0, 0, 0);
        PestCreep03.transform.localPosition = new Vector3(0.88f, 0, 0);

        PestCreep01.GetComponent<CrabGelCreepDelectable>().GeneticHall();
        PestCreep02.GetComponent<CrabGelCreepDelectable>().GeneticHall();
        PestCreep03.GetComponent<CrabGelCreepDelectable>().GeneticHall();
    }

    public void CrabPlow()
    {
        WePass = true;
        PestCreep01.transform.DOPause();
        PestCreep02.transform.DOPause();
        PestCreep03.transform.DOPause();
    }

    public void CrabMeAlone()
    {
        WePass = false;
        PestCreep01.transform.DOPlay();
        PestCreep02.transform.DOPlay();
        PestCreep03.transform.DOPlay();
    }

    public void AloneCrab()
    {
        
        if (PestGelHall == SlotRewardType.Null)
        {
            SlotRewardType slotObjData1 = GameUtil.GetSlotObjDataWithOutThanks();
            SlotRewardType slotObjData2 = GameUtil.GetSlotObjDataWithOutThanks();
            SlotRewardType slotObjData3 = GameUtil.GetSlotObjDataWithOutThanks();
            while (slotObjData1 == slotObjData2)
            {
                slotObjData2 = GameUtil.GetSlotObjDataWithOutThanks();
            }

            PestCreep01.GetComponent<CrabGelCreepDelectable>().StatueSunlitGel(slotObjData1);
            PestCreep02.GetComponent<CrabGelCreepDelectable>().StatueSunlitGel(slotObjData2);
            PestCreep03.GetComponent<CrabGelCreepDelectable>().StatueSunlitGel(slotObjData3);
        }
        else
        {
            PestCreep01.GetComponent<CrabGelCreepDelectable>().StatueSunlitGel(PestGelHall);
            PestCreep02.GetComponent<CrabGelCreepDelectable>().StatueSunlitGel(PestGelHall);
            PestCreep03.GetComponent<CrabGelCreepDelectable>().StatueSunlitGel(PestGelHall);
        }
        
    }

    private void HerbAil(Action finish)
    {
        CliffMust = true;
        StartCoroutine(nameof(BillCrabOffer));
        PestCreep01.transform.DOLocalMoveY(-1f * 28,3f).OnComplete(() =>
        {
            //音效
            OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_slotwheel_stop);
        });
        PestCreep02.transform.DOLocalMoveY(-1f * 28, 3f).SetDelay(0.3f).OnComplete(() =>
        {
            //音效
            OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_slotwheel_stop);
        });
        PestCreep03.transform.DOLocalMoveY(-1f * 28, 3f).SetDelay(0.6f).OnComplete(() =>
        {
            OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_slotwheel_stop);

            StopCoroutine(nameof(BillCrabOffer));
            PestCreep03.transform.DOScale(1f, 0f).SetDelay(1f).OnComplete(() =>
            {
                RevealCrabPegCharcoal.Instance.WeCrabMust = false;
                //音效
            
                CliffMust = false;

                finish();
                GeneticCrabCreep();
                if (PestGelHall == SlotRewardType.Null)
                {
                    Invoke(nameof(SinkLaunchScore), 0.5f);
                }
                else
                {
                    BeauWrapper.Instance.ScantCrab();
                }
            });
        });
    }


    public void YewShadowBed(SlotRewardType targetType)
    {

        // PlaySlot();
    }


    public void BillCrab(SlotRewardType targetType ,Action finish)
    {
        PestGelHall = targetType;
        DaleBulgeScript.YewVocation().PoolBulge("1003",PestGelHall.ToString());
        CliffMust = false;
        AloneCrab();
        HerbAil(finish);
    }

    private void SinkLaunchScore()
    {
        if (!NoLocaleUtah)
        {
            DemisePrimeWrapper.Instance.SinkTiltCrabScore();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // PlaySlot();
        }
    }


    IEnumerator BillCrabOffer()
    {
        while (CliffMust)
        {
            if (!WePass)
            {
                OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_slotwheel_rotate, 0.1f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
    public void Start()
    {
        //根据分辨率不同修改slot位置
        //float x = -0.616f* Screen.height - 159;
        //gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, x);
    }
    public void PianoCrabBG()
    {
     this.gameObject.SetActive(false);
    }
}