// Project: HappyBingo
// FileName: RawPegDelectable.cs
// Author: AX
// CreateDate: 20221124
// CreateTime: 11:39
// Description:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawPegDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("flyBox")]    public GameObject AllPeg;

    private int _RustSmoothly;

    private int _SurmiseFast;
[UnityEngine.Serialization.FormerlySerializedAs("isOnFlag")]
    public bool WeHeMust;

    private Dictionary<NormalRewardType, double> SierraHay;

    public static RawPegDelectable Instance;


    private void Awake()
    {
        Instance = this;
        _RustSmoothly = MudHourJaw.instance.UtahHall.base_config.bubble_time;
    }

    IEnumerator PegFastSmoothly()
    {
        while (WeHeMust)
        {
            if (_SurmiseFast >= _RustSmoothly)
            {
                _SurmiseFast = 0;
                StatueRawPeg();
            }

            _SurmiseFast++;
            //print(_currentTime);
            yield return new WaitForSeconds(1);
        }
    }


    public void NylonAndAlonePeg()
    {
        WeHeMust = true;
        _SurmiseFast = 0;
        StartCoroutine(PegFastSmoothly());
        StatueRawPeg();
    }

    public void PlowPeg()
    {
        if (!gameObject.activeInHierarchy) return;
        WeHeMust = false;
        StopCoroutine(PegFastSmoothly());
        if (transform.childCount > 0)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void HubPegFewCausal()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<RawColony>().HubFewCausal();
        }
    }

    public void HubPegFewKinglet()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<RawColony>().HubFewKinglet();
        }
    }

    public void ZoologyPeg()
    {
        gameObject.SetActive(true);
        if (gameObject.activeInHierarchy)
        {
            WeHeMust = true;
            StartCoroutine(PegFastSmoothly());
            if (transform.childCount > 0)
            {
                transform.GetChild(0).GetComponent<RawColony>().RawInvent();
                transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 120;
                transform.gameObject.SetActive(true);
            }
        }
    }

    public void StatueRawPeg()
    {
        if (KettleSure.HeYield()) return;
        if (ToilHallWrapper.YewCarpet(CScream.If_Loess_Ere_Ant) == "new") return;
        GameObject obj = Instantiate(AllPeg, transform);
        obj.transform.SetParent(gameObject.transform);
        obj.SetActive(true);
    }

    public void RomanHall()
    {
        WeHeMust = false;
        _SurmiseFast = 0;
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void SinkKrillScore()
    {
        BeauWrapper.Instance.UtahPlow();

        SierraHay = new Dictionary<NormalRewardType, double>();
        BubbleObjData bubbleObjData = GameUtil.GetBubbleObjData();
        
        string type = bubbleObjData.BubbleObjType.ToString();
        NormalRewardType SierraFist= (NormalRewardType) Enum.Parse(typeof(NormalRewardType), type);
        SierraHay.Add(SierraFist, bubbleObjData.RewardNum);
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_It_To,"6");
        ToilHallWrapper.HubCarpet(CScream.If_Prompt_Lip_Stir, "1013");
        SunlitScoreWrapper.Instance.SinkDemiseSunlitScore(SierraHay);

    }
}