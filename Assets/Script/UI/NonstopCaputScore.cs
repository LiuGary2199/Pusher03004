// Project: Pusher
// FileName: NonstopCaputScore.cs
// Author: AX
// CreateDate: 20230809
// CreateTime: 10:20
// Description:

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonstopCaputScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("closeBtn")]    public Button ChainFew;
[UnityEngine.Serialization.FormerlySerializedAs("objList")]
    public List<GameObject> RimGerm;

    private List<GemsDataItem> JobHallGerm;
    private void Start()
    {
        ChainFew.onClick.AddListener(() =>
        {
            PianoScore();
        });
        
        
        CorrectFingerSpoil.YewVocation().Magnetic(CScream.Ask_Chain_Brawl_Toe_Loess,
            (messageData) => {PianoScore(); });

    }


    protected override void Awake()
    {
        base.Awake();
        JobHallGerm = MudHourJaw.instance.UtahHall.Gem_Reward_list;
    }

    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        TireHall();
    }

    private void TireHall()
    {
        for (int i = 0; i < RimGerm.Count; i++)
        {
            GameObject objItem = RimGerm[i];
            objItem.GetComponent<NonstopGelDelectable>().TwigHallGate = JobHallGerm[i];
            objItem.GetComponent<NonstopGelDelectable>().TireHall();
        }
    }


    private void PianoScore()
    {
        TireHall();
        BeauWrapper.Instance.UtahRestart();
        PianoUIArid(GetType().Name);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }
}