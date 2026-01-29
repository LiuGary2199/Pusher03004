using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabCreep : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject TireCreep;

    private GameObject DistrictDriveOutlet;
    private float PickLight= 120f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        DistrictDriveOutlet = TireCreep.transform.Find("SlotCard_1").gameObject;
        float x = PickLight * 3;
        int multiCount = MudHourJaw.instance.TireHall.RewardMultiList.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(DistrictDriveOutlet, TireCreep.transform);
                fangkuai.transform.localPosition = new Vector3(x + PickLight * multiCount * i + PickLight * j, DistrictDriveOutlet.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + MudHourJaw.instance.TireHall.RewardMultiList[j].multi;
            }
        }
    }

    public void PealDrive()
    {
        TireCreep.GetComponent<RectTransform>().localPosition = new Vector3(0, -10, 0);
    }

    public void Pest(int index, Action<int> finish)
    {
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.Sound_OneArmBandit);
        LandslideDelectable.IncidentalDevote(TireCreep, -(PickLight * 2 + PickLight * MudHourJaw.instance.TireHall.RewardMultiList.Count * 3 + PickLight * (index + 1)), () =>
        {
            finish?.Invoke(MudHourJaw.instance.TireHall.RewardMultiList[index].multi);
        });
    }
}
