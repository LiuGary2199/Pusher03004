using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CosmosCoilScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    public Button PianoHandle;
[UnityEngine.Serialization.FormerlySerializedAs("AdjustAdidText")]    public Text CosmosEdgeCent;
[UnityEngine.Serialization.FormerlySerializedAs("ServerIdText")]    public Text SourceGoCent;
[UnityEngine.Serialization.FormerlySerializedAs("ActCounterText")]    public Text ActDynastyCent;
[UnityEngine.Serialization.FormerlySerializedAs("AdjustTypeText")]    public Text CosmosFistCent;
[UnityEngine.Serialization.FormerlySerializedAs("ResetActCountButton")]    public Button NylonAilPupilHandle;
[UnityEngine.Serialization.FormerlySerializedAs("AddActCountButton")]    public Button YewAilPupilHandle;

    // Start is called before the first frame update
    void Start()
    {
        PianoHandle.onClick.AddListener(() => {
            PianoUIArid(GetType().Name);
        });

        NylonAilPupilHandle.onClick.AddListener(() => {
            CosmosTireWrapper.Instance.NylonAilPupil();
        });

        YewAilPupilHandle.onClick.AddListener(() => {
            CosmosTireWrapper.Instance.YewAilPupil("test");
        });
    }

    private void SinkDynastyCent()
    {
        CosmosEdgeCent.text = CosmosTireWrapper.Instance.YewCosmosEdge();
        SourceGoCent.text = ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo);
        ActDynastyCent.text = CosmosTireWrapper.Instance._SurmisePupil.ToString();
        CosmosFistCent.text = ToilHallWrapper.YewCarpet("sv_ADJustInitType");
    }

    public override void Display()
    {
        base.Display();
        InvokeRepeating(nameof(SinkDynastyCent), 0, 0.5f);
    }

    public override void Hidding()
    {
        base.Hidding();
        CancelInvoke(nameof(SinkDynastyCent));
    }
}
