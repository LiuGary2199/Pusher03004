using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyWrapperCoilScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("LastPlayTimeCounterText")]    public Text PrayBillFastDynastyCent;
[UnityEngine.Serialization.FormerlySerializedAs("Counter101Text")]    public Text Dynasty101Cent;
[UnityEngine.Serialization.FormerlySerializedAs("Counter102Text")]    public Text Dynasty102Cent;
[UnityEngine.Serialization.FormerlySerializedAs("Counter103Text")]    public Text Dynasty103Cent;
[UnityEngine.Serialization.FormerlySerializedAs("TrialNumText")]    public Text LooseBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("PlayRewardedAdButton")]    public Button BillAppetiteMyHandle;
[UnityEngine.Serialization.FormerlySerializedAs("PlayInterstitialAdButton")]    public Button BillHelplessnessMyHandle;
[UnityEngine.Serialization.FormerlySerializedAs("NoThanksButton")]    public Button WeLaunchHandle;
[UnityEngine.Serialization.FormerlySerializedAs("TrialNumButton")]    public Button LooseBedHandle;
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    public Button PianoHandle;
[UnityEngine.Serialization.FormerlySerializedAs("TimeInterstitialText")]    public Text FastHelplessnessCent;
[UnityEngine.Serialization.FormerlySerializedAs("PauseTimeInterstitialButton")]    public Button DecayFastHelplessnessHandle;
[UnityEngine.Serialization.FormerlySerializedAs("ResumeTimeInterstitialButton")]    public Button InventFastHelplessnessHandle;

    private void Start()
    {
        InvokeRepeating(nameof(SinkDynastyCent), 0, 0.5f);

        PianoHandle.onClick.AddListener(() => {
            PianoUIArid(GetType().Name);
        });

        BillAppetiteMyHandle.onClick.AddListener(() => {
            ADWrapper.Vocation.DeepSunlitBleak((success) => { }, "10");
        });

        BillHelplessnessMyHandle.onClick.AddListener(() => {
            ADWrapper.Vocation.DeepHelplessnessMy(1);
        });

        WeLaunchHandle.onClick.AddListener(() => {
            ADWrapper.Vocation.WeLaunchYewPupil();
        });

        LooseBedHandle.onClick.AddListener(() => {
            ADWrapper.Vocation.VirtueLooseBed(ToilHallWrapper.YewSow(CScream.If_It_trial_Fox) + 1);
            LooseBedCent.text = ToilHallWrapper.YewSow(CScream.If_It_trial_Fox).ToString();
        });

        DecayFastHelplessnessHandle.onClick.AddListener(() => {
            ADWrapper.Vocation.DecayFastHelplessness();
            SinkDecayFastHelplessness();
        });

        InventFastHelplessnessHandle.onClick.AddListener(() => {
            ADWrapper.Vocation.InventFastHelplessness();
            SinkDecayFastHelplessness();
        });

    }

    public override void Display()
    {
        base.Display();
        LooseBedCent.text = ToilHallWrapper.YewSow(CScream.If_It_trial_Fox).ToString();
        SinkDecayFastHelplessness();
    }

    private void SinkDynastyCent()
    {
        PrayBillFastDynastyCent.text = ADWrapper.Vocation.WindBillFastDynasty.ToString();
        Dynasty101Cent.text = ADWrapper.Vocation.Liberty101.ToString();
        Dynasty102Cent.text = ADWrapper.Vocation.Liberty102.ToString();
        Dynasty103Cent.text = ADWrapper.Vocation.Liberty103.ToString();
    }

    private void SinkDecayFastHelplessness()
    {
        FastHelplessnessCent.text = ADWrapper.Vocation.WearyFastHelplessness ? "已暂停" : "未暂停";
    }
}
