using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cedar : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text CedarCent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Display()
    {
        base.Display();

        CedarCent.text = CedarWrapper.YewVocation().Hour;
        StartCoroutine(nameof(TirePianoCedar));
    }

    private IEnumerator TirePianoCedar()
    {
        yield return new WaitForSeconds(2);
        PianoUIArid(GetType().Name);
    }

}
