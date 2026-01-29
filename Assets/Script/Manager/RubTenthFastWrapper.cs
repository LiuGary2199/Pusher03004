// Project: Plinko
// FileName: TenthFastWrapper.cs
// Author: AX
// CreateDate: 20230508
// CreateTime: 16:04
// Description:

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class
    RubTenthFastWrapper : MonoBehaviour
{
    public static RubTenthFastWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("progressImg")]
    public Image DirectorRed;

    private int TrashPylon;
    private int TrashFast;

    private int SurmiseFast;
    private int SurmiseLife;
[UnityEngine.Serialization.FormerlySerializedAs("isFeverTime")]
    public bool WeTenthFast;

    private double LoessSuch;
    private double SacSuch;

    private bool ThemTenthFast;

    private void Awake()
    {
        Instance = this;
        WeTenthFast = false;
        ThemTenthFast = false;
        TrashPylon = MudHourJaw.instance.UtahHall.base_config.fever_limit;
        TrashFast = MudHourJaw.instance.UtahHall.base_config.fever_time;
    }

    private void Start()
    {
        RomanHall();
    }


    private void Update()
    {
        if (WeTenthFast)
        {
            if (!ThemTenthFast)
            {
                DirectorRed.fillAmount -= Time.deltaTime / TrashFast;
                if (DirectorRed.fillAmount == 0)
                {
                    PianoTenthFast();
                }
            }
        }
    }

    public void PlowTenth()
    {
        ThemTenthFast = true;
    }

    public void MeAloneTenthFast()
    {
        ThemTenthFast = false;
    }

    public void RomanHall()
    {
        SurmiseLife = ToilHallWrapper.YewSow(CScream.If_Trash_Rust_Surmise);
        GeneticSquirrel();
    }


    public void YewTenthLife()
    {
        if (WeTenthFast) return;

        SurmiseLife++;
        ToilHallWrapper.HubSow(CScream.If_Trash_Rust_Surmise, SurmiseLife);
        GeneticSquirrel();
        if (SurmiseLife >= TrashPylon)
        {
            AloneTenthFast();
        }
    }

    private void AloneTenthFast()
    {
        ToilHallWrapper.HubSow(CScream.If_Trash_Rust_Surmise, 0);
        DaleBulgeScript.YewVocation().PoolBulge("1006");

        // OfferJaw.GetInstance().PlayBg(OfferFist.UIMusic.sound_fever_bgm);

        // startCash = ToilHallWrapper.GetDouble(CScream.sv_CumulativeCash);
        WeTenthFast = true;
        SurmiseFast = TrashFast;
        // PillarManager.Instance.CloseBigWinPillar();
        // HeaveLifeWrapper.Instance.StartFeverTimeForSteelBall();
        // PillarManager.Instance.PillarGroupMove();
        // Fx_Group.Instance.FX_Fever.SetActive(true);
    }

    private void PianoTenthFast()
    {
        // OfferJaw.GetInstance().PlayBg(OfferFist.UIMusic.sound_bgm);

        // Fx_Group.Instance.FX_Fever.SetActive(false);
        WeTenthFast = false;
        // HeaveLifeWrapper.Instance.CloseFeverTimeForSteelBall();
        RomanHall();
        if (KettleSure.HeYield()) return;

        // endCash = ToilHallWrapper.GetDouble(CScream.sv_CumulativeCash);
        // double cash = Math.Round((endCash - startCash), 2);
        // ToilHallWrapper.SetDouble(CScream.sv_big_win_cash, cash);
        // NeedleWrapper.Instance.StopGame();

        // ToilHallWrapper.SetString(CScream.sv_big_win_type, "1007");
        // ToilHallWrapper.SetString(CScream.sv_big_win_ad_id, "3");

        // UIGrimly.GetInstance().ShowUIForms(nameof(TinVasKrillScore));
        // double num = 10;
        // SunlitScoreWrapper.Instance.ShowBigRewardPanel(num);
    }

    private void GeneticSquirrel()
    {
        DirectorRed.fillAmount = 1f * SurmiseLife / TrashPylon;
    }
}