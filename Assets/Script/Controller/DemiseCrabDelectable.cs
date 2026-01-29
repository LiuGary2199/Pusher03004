// Project: Plinko
// FileName: DemiseCrabDelectable.cs
// Author: AX
// CreateDate: 20230515
// CreateTime: 16:03
// Description:

using UnityEngine;
using System;
using UnityEngine.UI;


public class DemiseCrabDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject TireCreep;

    private GameObject DistrictDriveOutlet;
    private float PickLight= 130f; // 两个item的position.x之差

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
                fangkuai.transform.localPosition = new Vector3(x + PickLight * multiCount * i + PickLight * j,
                    DistrictDriveOutlet.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text =
                    "×" + MudHourJaw.instance.TireHall.RewardMultiList[j].multi;
            }
        }
    }

    public void TireDrive()
    {
        TireCreep.GetComponent<RectTransform>().localPosition = new Vector3(0, 6.6f, 0);
    }

    public void WorkCrab(int index, Action<int> finish)
    {
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_bigwin1_wheel);
        LandslideDelectable.IncidentalDevote(TireCreep,
            -(PickLight * 2 + PickLight * MudHourJaw.instance.TireHall.RewardMultiList.Count * 3 + PickLight * (index + 1)),
            () => { finish?.Invoke(MudHourJaw.instance.TireHall.RewardMultiList[index].multi); });
    }

}