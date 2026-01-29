using System.Collections;
using System.Collections.Generic;
using com.adjust.sdk;
using UnityEngine;
using UnityEngine.UI;

public class UtahScore : LastUITruck
{
    public static UtahScore Instance;
[UnityEngine.Serialization.FormerlySerializedAs("goldBtn")]
    public Button SlowFew;
[UnityEngine.Serialization.FormerlySerializedAs("cashBtn")]    public Button FlapFew;
    public Button ExchangeBtn;
    [UnityEngine.Serialization.FormerlySerializedAs("amazonBtn")]    public Button MagnetFew;
[UnityEngine.Serialization.FormerlySerializedAs("coinImg")]
    public Image GulfRed;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]    public Image FlapRed;
[UnityEngine.Serialization.FormerlySerializedAs("amazonImg")]    public Image MagnetRed;
[UnityEngine.Serialization.FormerlySerializedAs("ballImg")]    public Image LuceRed;
[UnityEngine.Serialization.FormerlySerializedAs("cashBar")]
    public GameObject FlapRod;
[UnityEngine.Serialization.FormerlySerializedAs("coinBar")]    public GameObject GulfRod;
[UnityEngine.Serialization.FormerlySerializedAs("amazonBar")]    public GameObject MagnetRod;
[UnityEngine.Serialization.FormerlySerializedAs("ballBar")]    public GameObject LuceRod;
[UnityEngine.Serialization.FormerlySerializedAs("NormalWindow")]
    public GameObject DemiseHugely;
[UnityEngine.Serialization.FormerlySerializedAs("PassWindow")]    public GameObject PestHugely;
[UnityEngine.Serialization.FormerlySerializedAs("newgoldBtn")]    public Button CreviceFew;
[UnityEngine.Serialization.FormerlySerializedAs("ExchangeBar")]    public GameObject CuspidorRod;
[UnityEngine.Serialization.FormerlySerializedAs("ExchangeNumText")]    public Text CuspidorBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("NewSettingBtn")]    public Button RubUnclearFew;
[UnityEngine.Serialization.FormerlySerializedAs("NewGoldNumText")]    public Text RubNeonBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("goldNumText")]
    public Text SlowBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("cashNumText")]    public Text FlapBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("amazonNumText")]    public Text MagnetBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("ballNumText")]    public Text LuceBedCent;
[UnityEngine.Serialization.FormerlySerializedAs("settingBtn")]
    public Button GazetteFew;
[UnityEngine.Serialization.FormerlySerializedAs("gemsStoreBtn")]    public Button TwigCaputFew;
[UnityEngine.Serialization.FormerlySerializedAs("testBtn")]   // public Button sohoShopBtn;

    public Button StunFew;
[UnityEngine.Serialization.FormerlySerializedAs("flyBoxController")]
    public RawPegDelectable AllPegDelectable;
    public Button TimeRewardBtn;
    public Button taskRewardBtn;

    // Start is called before the first frame update
    void Start()
    {
        GazetteFew.onClick.AddListener(() => { DemisePrimeWrapper.Instance.SinkUnclearScore(); });
        RubUnclearFew.onClick.AddListener(() => { DemisePrimeWrapper.Instance.SinkRubUnclearScore(); });
        TimeRewardBtn.onClick.AddListener(() => { UIManager.YewVocation().SinkUITruck(nameof(ATimerPanel_A)); });
        taskRewardBtn.onClick.AddListener(() => { UIManager.YewVocation().SinkUITruck(nameof(ATaskPanel_B)); });
        TwigCaputFew.onClick.AddListener(() => { DemisePrimeWrapper.Instance.SinkNonstopCaputScore(); });
        //sohoShopBtn.onClick.AddListener(() =>
        //{
        //    RubTiltFifthDelectable.Instance.ShowCashMask();
        //    if (ToilHallWrapper.GetString(CScream.msg_show_rate_us) == "new")
        //    {
        //        DaleBulgeScript.GetInstance().SendEvent("1002");
        //        ToilHallWrapper.SetString(CScream.msg_show_rate_us, "show");
        //    }

        //    BeauWrapper.Instance.GameStop();
        ////  SOHOShopManager.instance.ShowRedeemPanel();
        //});
        ExchangeBtn.onClick.AddListener(() =>
        {
            UIManager.YewVocation().SinkUITruck(nameof(ChangeCoin));

        });

        SlowFew.onClick.AddListener(() =>
        {
            if (KettleSure.HeYield()) return;
            BeauWrapper.Instance.UtahPlow();
            //SOHOShopManager.instance.ShowGoldAmazonRedeemPanel();
        });
        FlapFew.onClick.AddListener(() =>
        {
            BeauWrapper.Instance.UtahPlow();
          //  SOHOShopManager.instance.ShowRedeemPanel();
        });
        MagnetFew.onClick.AddListener(() =>
        {
            BeauWrapper.Instance.UtahPlow();
       //     SOHOShopManager.instance.ShowGoldAmazonRedeemPanel();
        });

        StunFew.onClick.AddListener(() =>
        {
            // AddGold(5000, transform);
            // AddCash(5000,transform);
            // AddAmazon(5000,transform);
            // UtahHallWrapper.GetInstance().AddGem(GemsType.Silver);
            // CourtWrapper.Instance.StartSkillLong(true, 5);
            // CourtWrapper.Instance.StartSkillWall(true, 8);
            // CourtWrapper.Instance.ShowSlotNum();
            // CourtWrapper.Instance.ShowCashCoinNum(2);
            DemisePrimeWrapper.Instance.SinkDivaUsScore();
            // SunlitScoreWrapper.Instance.ShowCashRollReward();
        });

        CorrectFingerSpoil.YewVocation().Magnetic(CScream.So_UtahChannel,
            (messageData) =>
            {
                BeauWrapper.Instance.UtahRestart();
                GeneticEncase();
            });

        CorrectFingerSpoil.YewVocation().Magnetic(CScream.Ask_Hero_Tine_us,
            (messageData) =>
            {
                    Invoke(nameof(SinkDivaUsScore),0.8f);
            });

        AllPegDelectable.NylonAndAlonePeg();
        if (KettleSure.HeYield()) 
        {
            DemiseHugely.SetActive(false);
            PestHugely.SetActive(true);
        }
        else
        {
            DemiseHugely.SetActive(true);
            PestHugely.SetActive(false);
        }
}

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public override void Display()
    {
        base.Display();

        ///sohoShopBtn.gameObject.SetActive(!KettleSure.IsApple());
        //cashBar.gameObject.SetActive(!KettleSure.IsApple());
       // amazonBar.gameObject.SetActive(!KettleSure.IsApple());
        LuceRod.gameObject.SetActive(!KettleSure.HeYield());
        CuspidorRod.gameObject.SetActive(KettleSure.HeYield());
        // gemsStoreBtn.gameObject.SetActive(!KettleSure.IsApple());
        print("adid: " + Adjust.getAdid());
        GeneticEncase();
      

    }

    private void SinkDivaUsScore()
    {
        DemisePrimeWrapper.Instance.SinkDivaUsScore();
    }

    public void GeneticEncase()
    {
        SlowBedCent.text = UtahHallWrapper.YewVocation().YewNeon() + "";
        RubNeonBedCent.text = UtahHallWrapper.YewVocation().YewNeon() + "";
        FlapBedCent.text = DisuseSure.IndigoMeLap(UtahHallWrapper.YewVocation().YewSuch());
        MagnetBedCent.text = UtahHallWrapper.YewVocation().YewEither() + "";
        LuceBedCent.text = UtahHallWrapper.YewVocation().YewLife() + "";
        CuspidorBedCent.text = UtahHallWrapper.YewVocation().YewLife() + "";
    }

    public void YewNeon(double gold, Transform objTrans = null)
    {
        UtahHallWrapper.YewVocation().YewNeon(gold);
        NeonYewLandslide(objTrans, 5);
    }

    public void YewSuch(double cash, Transform objTrans = null)
    {
        UtahHallWrapper.YewVocation().YewSuch(cash);
        SuchYewLandslide(objTrans, 5);
    }

    public void YewEither(double amazon, Transform objTrans = null)
    {
        UtahHallWrapper.YewVocation().YewEither(amazon);
        EitherYewLandslide(objTrans, 5);
    }

    private void NeonYewLandslide(Transform startTransform, double num)
    {
       
        if (KettleSure.HeYield()) 
        {
            YewLandslide(startTransform, GulfRed.transform, GulfRed.gameObject, RubNeonBedCent,UtahHallWrapper.YewVocation().YewNeon(), num);
        } else
        {
            YewLandslide(startTransform, GulfRed.transform, GulfRed.gameObject, SlowBedCent,UtahHallWrapper.YewVocation().YewNeon(), num);
        }

    }

    //  加现金动画
    private void SuchYewLandslide(Transform startTransform, double num)
    {
        YewLandslide(startTransform, FlapRed.transform, FlapRed.gameObject, FlapBedCent,
            UtahHallWrapper.YewVocation().YewSuch(), num);
    }

    // 加亚马逊币动画
    private void EitherYewLandslide(Transform startTransform, double num)
    {
        YewLandslide(startTransform, MagnetRed.transform, MagnetRed.gameObject, MagnetBedCent,
            UtahHallWrapper.YewVocation().YewEither(), num);
    }

    private void YewLandslide(Transform startTransform, Transform endTransform, GameObject icon, Text text,
        double textValue, double num)
    {
        if (startTransform != null)
        {
            LandslideDelectable.NeonHerbExpo(icon, Mathf.Max((int) num, 1), startTransform, endTransform,
                () =>
                {
                    OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_getcoin);
                    LandslideDelectable.BalticDisuse(double.Parse(text.text), textValue, 0.1f, text,
                        () => { text.text = DisuseSure.IndigoMeLap(textValue); });
                });
        }
        else
        {
            LandslideDelectable.BalticDisuse(double.Parse(text.text), textValue, 0.1f, text,
                () => { text.text = DisuseSure.IndigoMeLap(textValue); });
        }
    }
}