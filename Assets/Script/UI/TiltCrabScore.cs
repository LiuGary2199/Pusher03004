// Project: Plinko
// FileName: TiltCrabScore.cs
// Author: AX
// CreateDate: 20230510
// CreateTime: 9:23
// Description:

using System;
using UnityEngine;
using UnityEngine.UI;

public class TiltCrabScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("closeBtn")]    public Button ChainFew;
[UnityEngine.Serialization.FormerlySerializedAs("getBtn")]    public Button EraFew;
[UnityEngine.Serialization.FormerlySerializedAs("getBtnText")]

    public GameObject EraFewCent;
[UnityEngine.Serialization.FormerlySerializedAs("adImg")]    public GameObject adRed;


    private string AdornFist;

    private void Start()
    {
        ChainFew.onClick.AddListener(() =>
        {
            AdornFist = "0";
            ADWrapper.Vocation.WeLaunchYewPupil();
            BeauWrapper.Instance.UtahRestart();
            PianoWellScore();
        });

        EraFew.onClick.AddListener(() =>
        {
            if (ToilHallWrapper.YewCarpet(CScream.If_Loess_Pest_Aloof) == "new")
            {
                ToilHallWrapper.HubCarpet(CScream.If_Loess_Pest_Aloof, "done");
                YewSunlit();
            }
            else
            {
                ADWrapper.Vocation.DeepSunlitBleak((success) => {
                    if (success)
                    {
                        YewSunlit();
                    }
                }, "1");
            }
        });
    }

    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        if (ToilHallWrapper.YewCarpet(CScream.If_Loess_Pest_Aloof) == "new")
        {
            adRed.gameObject.SetActive(false);
            EraFewCent.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        else
        {
            EraFewCent.transform.localPosition = new Vector3(37f, 0f, 0f);
            adRed.gameObject.SetActive(true);
        }
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }

    private void YewSunlit()
    {
        AdornFist = "1";

        RevealCrabPegCharcoal.Instance.YewCrabPupil();
        PianoWellScore();
    }


    private void PianoWellScore()
    {
        DaleBulgeScript.YewVocation().PoolBulge("1004", AdornFist);
        BeauWrapper.Instance.UtahRestart();
        PianoUIArid(GetType().Name);
    }
}