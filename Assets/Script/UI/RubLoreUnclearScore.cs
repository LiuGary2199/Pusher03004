using Lofelt.NiceVibrations;
using UnityEngine;
using UnityEngine.UI;

public class RubLoreUnclearScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("musicBtn")]    public Button CliffFew;
[UnityEngine.Serialization.FormerlySerializedAs("soundBtn")]    public Button GroupFew;
[UnityEngine.Serialization.FormerlySerializedAs("vibrationBtn")]    public Button TraditionFew;
[UnityEngine.Serialization.FormerlySerializedAs("closeBtn")]
    public Button ChainFew;
[UnityEngine.Serialization.FormerlySerializedAs("musicOn")]
    public GameObject CliffHe;
[UnityEngine.Serialization.FormerlySerializedAs("musicOff")]    public GameObject CliffAny;
[UnityEngine.Serialization.FormerlySerializedAs("soundOn")]    public GameObject GroupHe;
[UnityEngine.Serialization.FormerlySerializedAs("soundOff")]    public GameObject GroupAny;
[UnityEngine.Serialization.FormerlySerializedAs("vibrationOn")]    public GameObject TraditionHe;
[UnityEngine.Serialization.FormerlySerializedAs("vibrationOff")]    public GameObject TraditionAny;

    private string TraditionKey;

    protected override void Awake()
    {
        base.Awake();
        TraditionKey = "sv_vibrationType";
        if (!PlayerPrefs.HasKey(TraditionKey))
        {
            ToilHallWrapper.HubSow(TraditionKey, 1);
        }
    }

    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        CliffHe.gameObject.SetActive(OfferJaw.YewVocation().ByOfferRelate);
        CliffAny.gameObject.SetActive(!OfferJaw.YewVocation().ByOfferRelate);

        GroupHe.gameObject.SetActive(OfferJaw.YewVocation().PurifyOfferRelate);
        GroupAny.gameObject.SetActive(!OfferJaw.YewVocation().PurifyOfferRelate);

        TraditionHe.gameObject.SetActive(ToilHallWrapper.YewSow(TraditionKey) == 1);
        TraditionAny.gameObject.SetActive(ToilHallWrapper.YewSow(TraditionKey) != 1);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }
    // Start is called before the first frame update
    void Start()
    {
        ChainFew.onClick.AddListener(() =>
        {
            BeauWrapper.Instance.UtahRestart();
            if (KettleSure.HeYield())
            {
                PianoUIArid(nameof(RubLoreUnclearScore));
            }
            else
            {
                PianoUIArid(GetType().Name);
            }
        });

        CliffFew.onClick.AddListener(() =>
        {
            OfferJaw.YewVocation().ByOfferRelate = !OfferJaw.YewVocation().ByOfferRelate;
            CliffHe.gameObject.SetActive(OfferJaw.YewVocation().ByOfferRelate);
            CliffAny.gameObject.SetActive(!OfferJaw.YewVocation().ByOfferRelate);
        });
        GroupFew.onClick.AddListener(() =>
        {
            OfferJaw.YewVocation().PurifyOfferRelate = !OfferJaw.YewVocation().PurifyOfferRelate;
            GroupHe.gameObject.SetActive(OfferJaw.YewVocation().PurifyOfferRelate);
            GroupAny.gameObject.SetActive(!OfferJaw.YewVocation().PurifyOfferRelate);
        });

        TraditionFew.onClick.AddListener(() =>
        {
            int vibrationType = ToilHallWrapper.YewSow(TraditionKey) * -1;
            TraditionHe.gameObject.SetActive((vibrationType == 1));
            TraditionAny.gameObject.SetActive((vibrationType != 1));
            ToilHallWrapper.HubSow(TraditionKey, vibrationType);
            HapticController.hapticsEnabled = (vibrationType == 1);
        });
    }
}