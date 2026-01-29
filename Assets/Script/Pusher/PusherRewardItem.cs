using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class RewardItemPerfabs
{
    public GameObject goldCoinPerfab_1;
    public GameObject goldCoinPerfab_5;
    public GameObject goldCoinPerfab_10;
    public GameObject goldCoinPerfab_50;
    public GameObject goldCoinPerfab_100;
    public GameObject goldCoinPerfab_200;
    public GameObject goldCoinPerfab_500;
    public GameObject cashCoinPerfab_1;
    public GameObject cashCoinPerfab_5;
    public GameObject cashCoinPerfab_10;
    public GameObject cashCoinPerfab_50;
    public GameObject cashCoinPerfab_100;
    public GameObject cashCoinPerfab_200;
    public GameObject cashCoinPerfab_500;
    public GameObject rollCashPerfab;
    public GameObject gemDiamondPerfab;
    public GameObject gemBluePerfab;
    public GameObject gemRedPerfab;
    public GameObject goldenPerfab;
    public GameObject scratchCardPerfab;
    public GameObject luckyCardPerfab;
    public GameObject bigCoinPerfab;
    public GameObject applePerfab;

}
public class PusherRewardItem : MonoBehaviour
{
    public PusherRewardType rewardType;
    public double rewardNum;
    public RewardItemPerfabs rewardItemPerfabs;
    bool canPlaySound = false;
    public void initRewardItem(PusherRewardType type, bool canPlay = true)
    {
        canPlaySound = canPlay;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        rewardType = type;
        if (KettleSure.HeYield() && type == PusherRewardType.CoinCash)
        {
            type = PusherRewardType.CoinGold;
            rewardType = PusherRewardType.CoinGold;
        }
        switch (type)
        {
            case PusherRewardType.CoinGold:
                initGoldCoin();
                break;
            case PusherRewardType.CoinCash:
                initCashCoin();
                break;
            case PusherRewardType.RollCash:
                rewardItemPerfabs.rollCashPerfab.SetActive(true);
                break;
            case PusherRewardType.LuckyCard:
                rewardItemPerfabs.luckyCardPerfab.SetActive(true);
                break;
            case PusherRewardType.ScratchCard:
                rewardItemPerfabs.scratchCardPerfab.SetActive(true);
                break;
            case PusherRewardType.GemDiamond:
                rewardItemPerfabs.gemDiamondPerfab.SetActive(true);
                break;
            case PusherRewardType.GemBlue:
                rewardItemPerfabs.gemBluePerfab.SetActive(true);
                break;
            case PusherRewardType.GemRed:
                rewardItemPerfabs.gemRedPerfab.SetActive(true);
                break;
            case PusherRewardType.Golden:
                rewardItemPerfabs.goldenPerfab.SetActive(true);
                break;
            case PusherRewardType.BigCoin:
                rewardItemPerfabs.bigCoinPerfab.SetActive(true);
                break;
        }

    }
    public void initGoldCoin()
    {
        int num = HallMaracaWrapper.YewVocation().EraNeonKindBed();
        if (KettleSure.HeYield())
        {
            rewardItemPerfabs.applePerfab.SetActive(true);
        }
        else
        {
            switch (num)
            {
                case 1:
                    rewardItemPerfabs.goldCoinPerfab_1.SetActive(true);
                    break;
                case 5:
                    rewardItemPerfabs.goldCoinPerfab_5.SetActive(true);
                    break;
                case 10:
                    rewardItemPerfabs.goldCoinPerfab_10.SetActive(true);
                    break;
                case 50:
                    rewardItemPerfabs.goldCoinPerfab_50.SetActive(true);
                    break;
                case 100:
                    rewardItemPerfabs.goldCoinPerfab_100.SetActive(true);
                    break;
                case 200:
                    rewardItemPerfabs.goldCoinPerfab_200.SetActive(true);
                    break;
                case 500:
                    rewardItemPerfabs.goldCoinPerfab_500.SetActive(true);
                    break;
            }
        }
        
        rewardNum = num;
    }
    public void initCashCoin()
    {
        int num = HallMaracaWrapper.YewVocation().EraSuchKindBed();
        if (KettleSure.HeYield())
        {
            rewardItemPerfabs.applePerfab.SetActive(true);
        }
        else
        {
            switch (num)
            {
                case 1:
                    rewardItemPerfabs.cashCoinPerfab_1.SetActive(true);
                    break;
                case 5:
                    rewardItemPerfabs.cashCoinPerfab_5.SetActive(true);
                    break;
                case 10:
                    rewardItemPerfabs.cashCoinPerfab_10.SetActive(true);
                    break;
                case 50:
                    rewardItemPerfabs.cashCoinPerfab_50.SetActive(true);
                    break;
                case 100:
                    rewardItemPerfabs.cashCoinPerfab_100.SetActive(true);
                    break;
                case 200:
                    rewardItemPerfabs.cashCoinPerfab_200.SetActive(true);
                    break;
                case 500:
                    rewardItemPerfabs.cashCoinPerfab_500.SetActive(true);
                    break;
            }
        }
        rewardNum = num / 100f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (canPlaySound)
        {
            if (GetComponent<Rigidbody>() != null)
            {
                if (rewardType == PusherRewardType.CoinCash || rewardType == PusherRewardType.CoinGold)
                {
                    if (transform.position.y < 1.269)
                    {
                        canPlaySound = false;
                        OfferFist.SceneMusic type = (OfferFist.SceneMusic)Enum.Parse(typeof(OfferFist.SceneMusic), "sound_coin_collide_" + UnityEngine.Random.Range(1,5));
                        OfferJaw.YewVocation().BillPurify(type, 0.1f);
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
