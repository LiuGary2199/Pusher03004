using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivaAnScore : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Pitch;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Wolf1Humble;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Wolf2Humble;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Pitch)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int Shock= indexStr == "" ? 0 : int.Parse(indexStr);
                NewlyAlone(Shock);
            });
        }
        
    }

    public override void Display()
    {
        base.Display();
        ADWrapper.Vocation.DecayFastHelplessness();
        for (int i = 0; i < 5; i++)
        {
            Pitch[i].gameObject.GetComponent<Image>().sprite = Wolf2Humble;
        }
    }
    public override void Hidding()
    {
        base.Hidding();
        ADWrapper.Vocation.InventFastHelplessness();
    }


    private void NewlyAlone(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Pitch[i].gameObject.GetComponent<Image>().sprite = i <= index ? Wolf1Humble : Wolf2Humble;
        }
        if (index < 3)
        {
            StartCoroutine(ChainScore());
        } else
        {
            // 跳转到应用商店
            DivaAnWrapper.instance.DownAPEatSquare();
            StartCoroutine(ChainScore());
        }
        
        // 打点
        DaleBulgeScript.YewVocation().PoolBulge("1016", (index + 1).ToString());
    }

    IEnumerator ChainScore(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        BeauWrapper.Instance.UtahRestart();
        PianoUIArid(GetType().Name);
    }
}
