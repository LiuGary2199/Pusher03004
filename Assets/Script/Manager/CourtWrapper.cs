// Project: Pusher
// FileName: CourtWrapper.cs
// Author: AX
// CreateDate: 20230823
// CreateTime: 14:33
// Description:

using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CourtWrapper : MonoBehaviour
{
    public static CourtWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("skillWall")]
    public GameObject DraftLake;
[UnityEngine.Serialization.FormerlySerializedAs("skillLong")]    public GameObject DraftFall;
[UnityEngine.Serialization.FormerlySerializedAs("slotObj")]    public GameObject PestGel;
[UnityEngine.Serialization.FormerlySerializedAs("cashCoinObj")]    public GameObject FlapKindGel;
[UnityEngine.Serialization.FormerlySerializedAs("skillLongText")]
    public Text DraftFallCent;
[UnityEngine.Serialization.FormerlySerializedAs("skillWallText")]    public Text DraftLakeCent;
[UnityEngine.Serialization.FormerlySerializedAs("slotNumText")]    public Text PestBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("cashCoinNumText")]    public Text FlapKindBedCent;


    private int DraftLakeFast;
    private int DraftFallFast;
    private int FlapKindFast;

    private bool PestMust;


    private void Awake()
    {
        Instance = this;
        DraftLakeFast = 0;
        DraftFallFast = 0;
        FlapKindFast = 0;
        PestMust = false;
    }


    private void SinkCourtFallAil()
    {
        DraftFall.transform.DOLocalMoveX(-450, 0.5f);
    }

    private void PianoCourtFallAil()
    {
        DraftFall.transform.DOLocalMoveX(-725, 0.5f);
        StopCoroutine(nameof(CourtFallScope));
    }

    private void SinkCourtLakeAil()
    {
        DraftLake.transform.DOLocalMoveX(450, 0.5f);
    }

    private void PianoCourtLakeAil()
    {
        DraftLake.transform.DOLocalMoveX(725, 0.5f);
        StopCoroutine(nameof(CourtLakeScope));
    }

    public void AloneCourtFall(bool flag, int time)
    {
        if (flag)
        {
            SinkCourtFallAil();
            DraftFallFast = 0;
        }

        DraftFallFast += time;
        StopCoroutine(nameof(CourtFallScope));
        StartCoroutine(nameof(CourtFallScope));
    }

    public void AloneCourtLake(bool flag, int time)
    {
        if (flag)
        {
            SinkCourtLakeAil();
            DraftLakeFast = 0;
        }

        DraftLakeFast += time;
        StopCoroutine(nameof(CourtLakeScope));
        StartCoroutine(nameof(CourtLakeScope));
    }


    public void SinkCrabBed(bool flag,int num)
    {
        PestBedCent.text = num + "";
        if (flag)
        {
            if (PestMust) return;
            PestMust = true;
            PestGel.transform.DOLocalMoveX(-450, 0.5f);
        }
        else
        {
            PestMust = false;
            PestBedCent.text = num +"";
            PestGel.transform.DOLocalMoveX(-725, 0.5f);
        }

    }
    
    

    public void SinkSuchKindBed(bool flag, int num)
    {
        FlapKindBedCent.text = num + "";
        if (flag)
        {
            FlapKindGel.transform.DOLocalMoveX(450, 0.5f);
        }

        if (num == 1)
        {
            FlapKindBedCent.text = "0";
            FlapKindGel.transform.DOLocalMoveX(725, 0.5f).SetDelay(1f);
        }
        
    }


    IEnumerator CourtFallScope()
    {
        while (DraftFallFast > 0)
        {
            DraftFallFast--;
            DraftFallCent.text = DraftFallFast + "";

            if (DraftFallFast == 0)
            {
                PianoCourtFallAil();
            }

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator CourtLakeScope()
    {
        while (DraftLakeFast > 0)
        {
            DraftLakeFast--;
            DraftLakeCent.text = DraftLakeFast + "";
            if (DraftLakeFast == 0)
            {
                PianoCourtLakeAil();
            }

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SuchKindScope()
    {
        while (DraftLakeFast > 0)
        {
            DraftLakeFast--;

            if (DraftLakeFast == 0)
            {
                PianoCourtLakeAil();
            }

            yield return new WaitForSeconds(1);
        }
    }
}