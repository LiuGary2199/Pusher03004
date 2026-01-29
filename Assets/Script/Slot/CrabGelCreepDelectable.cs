// Project: Plinko
// FileName: CrabGelCreepDelectable.cs
// Author: AX
// CreateDate: 20230512
// CreateTime: 15:50
// Description:

using System;
using System.Collections.Generic;
using Spine;
using UnityEngine;

public class CrabGelCreepDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("baseSlotObj")]    public GameObject MayaCrabGel;
[UnityEngine.Serialization.FormerlySerializedAs("slotObjList")]    public List<GameObject> PestGelGerm;
[UnityEngine.Serialization.FormerlySerializedAs("rewardObjList")]

    public List<SlotRewardType> SierraGelGerm;
    
    private int AlpPeart;
    private int SierraPeart;


    private void Awake()
    {
        AlpPeart = 33;
        SierraPeart = 30;
    }

    private void Start()
    {
        TireHall();
    }

    public void TireHall()
    {
        for (int i = 0; i < AlpPeart; i++)
        {
            GameObject objItem = Instantiate(MayaCrabGel, transform);
            Vector3 pos = new Vector3();
            pos.y = i - 2;
            objItem.transform.localPosition = pos;
            objItem.GetComponent<CrabGelDelectable>().TireHallTanker();
            PestGelGerm.Add(objItem);
        }
    }

    public void StatueSunlitGel(SlotRewardType rewardData)
    {

        
        for (int i = SierraPeart; i < AlpPeart; i++)
        {
            GameObject objItem = PestGelGerm[i];

            if (i == SierraPeart)
            {
                objItem.GetComponent<CrabGelDelectable>().TireHallAnHall(rewardData);
            }
            else
            {
                objItem.GetComponent<CrabGelDelectable>().TireHallTanker();
            }
        }
        
        SierraGelGerm = new List<SlotRewardType>();
        for (int i = SierraPeart-2; i < AlpPeart; i++)
        {
            GameObject objItem = PestGelGerm[i];
            SlotRewardType tempData = objItem.GetComponent<CrabGelDelectable>().PestGelHall;
            SierraGelGerm.Add(tempData);
        }
        
    }

    public void GeneticHall()
    {
        // ClearData();
        MeTire();
    }

    private void MeTire()
    {
        for (int i = 0; i < AlpPeart; i++)
        {
            GameObject objItem = PestGelGerm[i];
            if (i < 5)
            {
                SlotRewardType tarItem = SierraGelGerm[i];
                objItem.GetComponent<CrabGelDelectable>().TireHallAnHall(tarItem);
            }
            else
            {
                objItem.GetComponent<CrabGelDelectable>().TireHallTanker();
            }
        }
    }

}