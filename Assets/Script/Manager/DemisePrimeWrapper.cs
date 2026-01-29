// Project: Pusher
// FileName: DemisePrimeWrapper.cs
// Author: AX
// CreateDate: 20230821
// CreateTime: 9:30
// Description:

using System;
using UnityEngine;

public class DemisePrimeWrapper : MonoBehaviour
{
    public static DemisePrimeWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("isLock")]    public bool WeOnly;


    protected void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        WeOnly = false;

        // CorrectFingerSpoil.GetInstance().Register(CScream.msg_close_panel_and_start,
        //     (messageData) => { CloseLock(); });
    }


    /*
     *
     * 各类弹窗
     */
    public void SinkPeskyDeedScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        DaleBulgeScript.YewVocation().PoolBulge("1010");
        ToilHallWrapper.HubSow(CScream.If_It_trial_Fox, ToilHallWrapper.YewSow(CScream.If_It_trial_Fox) + 1);
        UIManager.YewVocation().SinkUITruck(nameof(PeskyDeedScore));
    }

    public void SinkExecuteDeedScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        DaleBulgeScript.YewVocation().PoolBulge("1008");
        ToilHallWrapper.HubSow(CScream.If_It_trial_Fox, ToilHallWrapper.YewSow(CScream.If_It_trial_Fox) + 1);
        UIManager.YewVocation().SinkUITruck(nameof(ExecuteDeedScore));
    }

    public void SinkNonstopCaputScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;

        if (PorkSure.Ghostly() - ToilHallWrapper.YewSow("sv_show_gems_times") < 10)
        {
            return;
        }

        ToilHallWrapper.HubSow("sv_show_gems_times", (int) PorkSure.Ghostly());

        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();

        UIManager.YewVocation().SinkUITruck(nameof(NonstopCaputScore));
    }

    public void SinkUnclearScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(UnclearScore));
    }
    public void SinkRubUnclearScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(RubLoreUnclearScore));
    }
    public void SinkTiltSunlitScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(TiltSunlitScore));
    }
    public void SinkTiltCordKindScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(TiltCordKindScore));
    }

    public void SinkTiltCrabScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(TiltCrabScore));
    }
    
    public void SinkDivaUsScore()
    {
        if (WeOnly || BeauWrapper.Instance.HostOnly) return;

        if (KettleSure.HeYield())
        {
            return;
        }
        WeOnly = true;
        BeauWrapper.Instance.UtahPlow();
        UIManager.YewVocation().SinkUITruck(nameof(DivaAnScore));
     
    }

}