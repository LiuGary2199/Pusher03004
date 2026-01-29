using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeauWrapper : MonoBehaviour
{
    public static BeauWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("pushObj")]
    public GameObject StemGel;
[UnityEngine.Serialization.FormerlySerializedAs("slotObj")]    public GameObject PestGel;
[UnityEngine.Serialization.FormerlySerializedAs("gameLock")]
    public bool HostOnly;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        OfferJaw.YewVocation().TireOfferJaw();
        CorrectFingerSpoil.YewVocation()
            .Magnetic(CScream.Ask_Chain_Brawl_Toe_Loess, (messageData) => { UtahRestart(); });
    }

    public void HostTire()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CScream.If_HeRubObtain + "Bool") || ToilHallWrapper.YewShop(CScream.If_HeRubObtain);
        CosmosTireWrapper.Instance.TireCosmosHall(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            ToilHallWrapper.HubShop(CScream.If_HeRubObtain, false);
        }
        
        DaleBulgeScript.YewVocation().PoolBulge("1001");
        OfferJaw.YewVocation().BillBy(OfferFist.UIMusic.sound_bgm);
    
        UtahHallWrapper.YewVocation().TireUtahHall();
        UIManager.YewVocation().SinkUITruck(nameof(UtahScore));
        StemGel.gameObject.SetActive(true);
        PestGel.gameObject.SetActive(true);
        MudHourJaw.instance.ItWrapper.SetActive(true);
        if (KettleSure.HeYield())
        {
            UtahHallWrapper.YewVocation().ScrubDieCrustalValveForge();
            UtahHallWrapper.YewVocation().ScrubDieCrustalValveCensus();
            UtahHallWrapper.YewVocation().DefendVagueHomogeneousFact();
        }
    }

    public void ScantCrab()
    {
        RevealCrabPegCharcoal.Instance.MeAxCrab();
    }

    public void UtahRestart()
    {
        HostOnly = false;
        DemisePrimeWrapper.Instance.WeOnly = false;
        if (KettleSure.HeYield())
        { 
            RubTenthFastWrapper.Instance.MeAloneTenthFast();

        }
        else 
        {
            TenthFastWrapper.Instance.MeAloneTenthFast(); 
        }
        RawPegDelectable.Instance.ZoologyPeg();
        PusherManager.Instance.resumePusher();
        ScantCrab();
    }

    public void UtahPlow()
    {
        HostOnly = true;
        if (KettleSure.HeYield())
        { 
            RubTenthFastWrapper.Instance.PlowTenth(); 
        } 
        else 
        {
            TenthFastWrapper.Instance.PlowTenth();
        }
        RawPegDelectable.Instance.PlowPeg();
        PusherManager.Instance.pausePusher();
    }
}