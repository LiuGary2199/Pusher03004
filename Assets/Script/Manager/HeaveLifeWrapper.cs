// Project: Plinko
// FileName: HeaveLifeWrapper.cs
// Author: AX
// CreateDate: 20230427
// CreateTime: 15:20
// Description:

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HeaveLifeWrapper : MonoBehaviour
{
    public static HeaveLifeWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("currentBallNum")]
    public int SurmiseLifeBed;

    private float LucePylon;

    private double FoodstuffIt;

    private bool ThemMust;

    private bool WeTenthFast;

    string cdFast;

    private bool LeaseLifeOnly;

    private void Awake()
    {
        Instance = this;
        LucePylon = MudHourJaw.instance.UtahHall.base_config.ball_limit;
        FoodstuffIt = MudHourJaw.instance.UtahHall.base_config.multiball_cd;
        SurmiseLifeBed = ToilHallWrapper.YewSow(CScream.If_Lease_Luce_Fox);
    }

    private void Start()
    {
        GeneticHall();
        StartCoroutine(nameof(JoineryHeaveLife));
    }


    public bool CordLife()
    {
        SurmiseLifeBed = ToilHallWrapper.YewSow(CScream.If_Lease_Luce_Fox);
        if (SurmiseLifeBed <1)
        {
            DemisePrimeWrapper.Instance.SinkTiltSunlitScore();
            return false;
        }

        SurmiseLifeBed--;
        GeneticHall();
        return true;
    }

    public bool CordKindForYield()//审核用的 
    {
        SurmiseLifeBed = ToilHallWrapper.YewSow(CScream.If_Lease_Luce_Fox);
        if (SurmiseLifeBed < 1)
        {
            DemisePrimeWrapper.Instance.SinkTiltCordKindScore();
            return false;
        }
        SurmiseLifeBed--;
        UtahHallWrapper.YewVocation().DefendKilnExterior();
        GeneticHall();
        return true;
    }


    public void YewHeaveLife()
    {
        SurmiseLifeBed = MudHourJaw.instance.UtahHall.base_config.ball_limit;
        StopCoroutine(nameof(JoineryHeaveLifeFast));
        cdFast = "";
        // UtahScore.Instance.cdText.text = cdTime;
        GeneticHall();
    }


    private void GeneticHall()
    {
        //Debug.Log("currentBallNum"+ currentBallNum);
        ToilHallWrapper.HubSow(CScream.If_Lease_Luce_Fox, SurmiseLifeBed);
        UtahHallWrapper.YewVocation().YewLife(SurmiseLifeBed);
        UtahScore.Instance.LuceBedCent.text = SurmiseLifeBed + "";
        UtahScore.Instance.CuspidorBedCent.text = SurmiseLifeBed + "";
        // UtahScore.Instance.cdText.text = cdTime;
    }



    IEnumerator JoineryHeaveLife()
    {
        while (SurmiseLifeBed > -10)
        {
            if (SurmiseLifeBed < LucePylon)
            {
                string time = ToilHallWrapper.YewCarpet(CScream.If_Lease_Luce_Have);
                if (time.Length == 0)
                {
                    ToilHallWrapper.HubCarpet(CScream.If_Lease_Luce_Have, DateTime.Now.ToString());
                    StopCoroutine(nameof(JoineryHeaveLifeFast));
                    StartCoroutine(nameof(JoineryHeaveLifeFast));
                }
                else
                {
                    int timenow = YewMortarHall.YewVocation().SecPorkRite(time, DateTime.Now);
                    int a = (int) ( timenow / FoodstuffIt);
                    if (a >= 1)
                    {
                        SurmiseLifeBed += a;
                  
                        ToilHallWrapper.HubCarpet(CScream.If_Lease_Luce_Have, DateTime.Now.ToString());
                        if (SurmiseLifeBed < LucePylon)
                        {
                            UtahHallWrapper.YewVocation().YewLife(a);
                            StopCoroutine(nameof(JoineryHeaveLifeFast));
                            StartCoroutine(nameof(JoineryHeaveLifeFast));
                        }
                        else
                        {
                            UtahHallWrapper.YewVocation().YewLife((int)(SurmiseLifeBed-LucePylon));
                            SurmiseLifeBed = (int) LucePylon;
                            StopCoroutine(nameof(JoineryHeaveLifeFast));
                            cdFast = "";
                            // UtahScore.Instance.cdText.text = cdTime;
                        }
                    }
                    else
                    {
                        if (cdFast == "")
                        {
                            StopCoroutine(nameof(JoineryHeaveLifeFast));
                            StartCoroutine(nameof(JoineryHeaveLifeFast));
                        }
                    }
                }

                GeneticHall();
            }

            yield return new WaitForSeconds((float) 0.05);
        }
    }

    IEnumerator JoineryHeaveLifeFast()
    {
        for (int i = (int) FoodstuffIt; i > 0; i--)
        {
            cdFast = i + "s";
            // UtahScore.Instance.cdText.text = cdTime;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator BalticHeaveLifeOnly()
    {
        // yield return new WaitForSeconds((float) multiballCd);
        yield return new WaitForSeconds(0.5f);
        LeaseLifeOnly = false;
    }
}