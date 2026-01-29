using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCrabPegCharcoal : MonoBehaviour
{
    public static RevealCrabPegCharcoal Instance;
[UnityEngine.Serialization.FormerlySerializedAs("slotCount")]
    public int PestPupil;
[UnityEngine.Serialization.FormerlySerializedAs("isSlotFlag")]    public bool WeCrabMust;

    private void Awake()
    {
        Instance = this;
        PestPupil = 0;
        WeCrabMust = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_enter_box);
        PusherManager.Instance.getDropReward(other.transform.parent.GetComponent<PusherRewardItem>().rewardType,
            other.transform.parent.GetComponent<PusherRewardItem>().rewardNum);

        BillYouCrab();
        other.transform.parent.gameObject.SetActive(false);
    }

    public void BillYouCrab()
    {
        YewCrabPupil();
        DoCrab();
    }

    public void YewCrabPupil()
    {
        PestPupil++;
        CourtWrapper.Instance.SinkCrabBed(true, PestPupil);
    }


    private void DoCrab()
    {
        if (WeCrabMust) return;
        CourtWrapper.Instance.SinkCrabBed(true, PestPupil);
        WeCrabMust = true;
        PestPupil--;
        PusherManager.Instance.startSlot();
    }

    public void MeAxCrab()
    {
        if (PestPupil < 1)
        {
            CourtWrapper.Instance.SinkCrabBed(false, PestPupil);
            return;
        }

        DoCrab();
        // Invoke("DoSlot", 1f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            BillYouCrab();
        }
    }
}