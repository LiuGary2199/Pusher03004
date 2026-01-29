// Project: Plinko
// FileName: RubTiltFifthDelectable.cs
// Author: AX
// CreateDate: 20230526
// CreateTime: 15:28
// Description:

using System;
using UnityEngine;
using UnityEngine.UI;

public class RubTiltFifthDelectable : MonoBehaviour
{
    public static RubTiltFifthDelectable Instance;
[UnityEngine.Serialization.FormerlySerializedAs("step1Btn")]
    public Button Beam1Few;
[UnityEngine.Serialization.FormerlySerializedAs("step2Btn")]
    public Button Beam2Few;
[UnityEngine.Serialization.FormerlySerializedAs("step3Btn")]
    public Button Beam3Few;
[UnityEngine.Serialization.FormerlySerializedAs("step4Btn")]
    public Button Beam4Few;
[UnityEngine.Serialization.FormerlySerializedAs("cashMaskObj")]
    public GameObject FlapMiteGel;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Beam1Few.onClick.AddListener(() =>
        {
            Beam1Few.gameObject.SetActive(false);
            Invoke(nameof(SinkSuck2Few), 0.3f);
        });

        Beam2Few.onClick.AddListener(() =>
        {
            Beam2Few.gameObject.SetActive(false);
            Invoke(nameof(SinkSuck3Few), 0.3f);
        });


        Beam3Few.onClick.AddListener(() =>
        {
            Beam3Few.gameObject.SetActive(false);
            Invoke(nameof(SinkSuck4Few), 0.3f);
        });


        Beam4Few.onClick.AddListener(() =>
        {
            Beam4Few.gameObject.SetActive(false);
            AloneUtah();
        });

        CorrectFingerSpoil.YewVocation().Magnetic(CScream.Ask_Hero_Flap_Fair,
            (messageData) =>
            {
                Invoke(nameof(SinkSuchMite),0.5f);
            });


        TireHall();
    }


    private void SinkSuck2Few()
    {
        Beam2Few.gameObject.SetActive(true);
    }

    private void SinkSuck3Few()
    {
        Beam3Few.gameObject.SetActive(true);
    }

    private void SinkSuck4Few()
    {
        Beam4Few.gameObject.SetActive(true);
    }

    private void AloneUtah()
    {
        ToilHallWrapper.HubCarpet(CScream.If_Rancho_Fly_Wipe_Panel, "done");
        BeauWrapper.Instance.UtahRestart();
    }

    public void TireHall()
    {
        if (ToilHallWrapper.YewCarpet(CScream.If_Rancho_Fly_Wipe_Panel) == "new" && !KettleSure.HeYield())
        {
            Beam1Few.gameObject.SetActive(false);
            Invoke(nameof(SinkSuchMite), 0.5f);

        }
        else
        {
            Beam1Few.gameObject.SetActive(false);
            Beam2Few.gameObject.SetActive(false);
            Beam3Few.gameObject.SetActive(false);
            Beam4Few.gameObject.SetActive(false);
            FlapMiteGel.gameObject.SetActive(false);
        }
    }


    public void SinkSuchMite()
    {
        if (ToilHallWrapper.YewCarpet(CScream.If_Loess_Flap_Shy) == "new")
        {
            ToilHallWrapper.HubCarpet(CScream.If_Loess_Flap_Shy, "done");

            if (KettleSure.HeYield())
            {
                return;
            }

            BeauWrapper.Instance.UtahPlow();
            FlapMiteGel.gameObject.SetActive(true);
        }
        else
        {
          
            if (ToilHallWrapper.YewCarpet(CScream.If_Rancho_Fly_Wipe_Panel) == "new" && !KettleSure.HeYield())
            {
                Beam1Few.gameObject.SetActive(true);
                Beam2Few.gameObject.SetActive(false);
                Beam3Few.gameObject.SetActive(false);
                Beam4Few.gameObject.SetActive(false);
                FlapMiteGel.gameObject.SetActive(false);
                BeauWrapper.Instance.UtahPlow();
            }
            else
            {
                FlapMiteGel.gameObject.SetActive(false);
                Beam1Few.gameObject.SetActive(false);
                Beam2Few.gameObject.SetActive(false);
                Beam3Few.gameObject.SetActive(false);
                Beam4Few.gameObject.SetActive(false);
                FlapMiteGel.gameObject.SetActive(false);
                BeauWrapper.Instance.UtahRestart();
            } 
        }
    }
}