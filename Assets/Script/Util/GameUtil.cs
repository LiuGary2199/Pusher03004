using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameUtil
{
    public static double GetPusherCashReward()
    {
        List<double> rewardList = MudHourJaw.instance.TireHall.coin_cash_reward_list;
        List<double> weightList = MudHourJaw.instance.TireHall.coin_cash_weight_list;

        double weightMax = 0;
        foreach (double item in weightList)
        {
            weightMax += item;
        }

        int index = 0;
        double temp = 0;
        double num = Random.Range(0f, float.Parse(weightMax.ToString()));
        for (int i = 0; i < weightList.Count; i++)
        {
            temp += weightList[i];
            if (temp >= num)
            {
                index = i;
                break;
            }
        }

        return rewardList[index];
    }

    public static double GetPusherGoldReward()
    {
        List<CoinGoldDataItem> groupList = MudHourJaw.instance.TireHall.coin_gold_group;
        double goldAll = ToilHallWrapper.YewIndigo(CScream.If_PermanenceNeonKind);
        CoinGoldDataItem obj = new CoinGoldDataItem();
        double tempMax = 0;
        for (int i = 0; i < groupList.Count; i++)
        {
            tempMax += groupList[i].max;
            if (tempMax >= goldAll)
            {
                obj = groupList[i];
                break;
            }
        }

        List<double> rewardList = obj.reward_list;
        List<double> weightList = obj.weight_list;

        double weightMax = 0;
        foreach (double item in weightList)
        {
            weightMax += item;
        }

        int index = 0;
        double temp = 0;
        double num = Random.Range(0f, float.Parse(weightMax.ToString()));
        for (int i = 0; i < weightList.Count; i++)
        {
            temp += weightList[i];
            if (temp >= num)
            {
                index = i;
                break;
            }
        }

        return rewardList[index];
    }
    public static double GetInterstitialData()
    {
        double num = 0;
        InterstitialData interstitialData = MudHourJaw.instance.UtahHall.Interstitial_data_list[0];
        double cashReward = interstitialData.reward_num * GetCashMulti();
        num = Math.Round(cashReward, 2);
        return num;
    }



    public static BubbleObjData GetBubbleObjData()
    {
        BubbleObjData bubbleObjData = new BubbleObjData();
        List<BubbleDataItem> bubbleDataList = MudHourJaw.instance.UtahHall.bubble_data_list;
        double maxWeight = 0;
        foreach (BubbleDataItem item in bubbleDataList)
        {
            double weight = item.weight;
            if (item.type == "Cash")
            {
                weight *= GetCashWeightMulti();
                item.weight = weight;
            }

            maxWeight += weight;
        }

        float randomNum = Random.Range(0, (float) maxWeight);

        double tempNum = 0;

        foreach (BubbleDataItem item in bubbleDataList)
        {
            tempNum += item.weight;
            if (tempNum >= randomNum)
            {
                bubbleObjData.BubbleObjType = (BubbleObjType) Enum.Parse(typeof(BubbleObjType), item.type);
                bubbleObjData.RewardNum = item.reward_num;
                break;
            }
        }

        switch (bubbleObjData.BubbleObjType)
        {
            case BubbleObjType.Gold:
                bubbleObjData.RewardNum = bubbleObjData.RewardNum * GetGoldMulti();
                break;
            case BubbleObjType.Cash:
                double cashReward = bubbleObjData.RewardNum * GetCashMulti();
                bubbleObjData.RewardNum = Math.Round(cashReward, 2);
                break;
            case BubbleObjType.Amazon:
                bubbleObjData.RewardNum = bubbleObjData.RewardNum * GetAmazonMulti();
                break;
        }

        return bubbleObjData;
    }


    public static ScratchObjData GetScratchObjData()
    {
        ScratchObjData scratchObjData = new ScratchObjData();
        List<ScratchDataItem> scratchDataList = MudHourJaw.instance.UtahHall.scratch_data_list;
        double maxWeight = 0;
        foreach (ScratchDataItem item in scratchDataList)
        {
            double weight = item.weight;
            // if (item.type == "Cash")
            // {
            //     weight *= GetCashWeightMulti();
            //     item.weight = weight;
            // }

            maxWeight += weight;
        }

        float randomNum = Random.Range(0, (float) maxWeight);

        double tempNum = 0;
        foreach (ScratchDataItem item in scratchDataList)
        {
            tempNum += item.weight;
            if (tempNum >= randomNum)
            {
                scratchObjData.ScratchObjType = (ScratchObjType) Enum.Parse(typeof(ScratchObjType), item.type);
                scratchObjData.RewardNum = item.reward_num;
                break;
            }
        }

        return scratchObjData;
    }


    public static LuckyObjData GetLuckyCardObjData()
    {
        LuckyObjData luckyObjData = new LuckyObjData();
        List<LuckyDataItem> luckyDataListSource = MudHourJaw.instance.UtahHall.lucky_card_data_list;
        List<LuckyDataItem> luckyDataList = new List<LuckyDataItem>();

        foreach (LuckyDataItem item in luckyDataListSource)
        {
            LuckyDataItem obj = new LuckyDataItem();
            obj.reward_num = item.reward_num;
            obj.type = item.type;
            if (item.type == "Cash")
            {
                obj.weight = item.weight * GetCashWeightMulti();
                // obj.reward_num = Math.Round(item.reward_num * GetCashMulti(), 2);
            }
            else
            {
                obj.weight = item.weight;
            }

            luckyDataList.Add(obj);
        }

        double maxWeight = 0;

        foreach (LuckyDataItem item in luckyDataList)
        {
            double weight = item.weight;
            maxWeight += weight;
        }

        float randomNum = Random.Range(0, (float) maxWeight);

        double tempNum = 0;
        foreach (LuckyDataItem item in luckyDataList)
        {
            tempNum += item.weight;
            if (tempNum >= randomNum)
            {
                luckyObjData.LuckyObjType = (LuckyObjType) Enum.Parse(typeof(LuckyObjType), item.type);
                luckyObjData.RewardNum = item.reward_num;
                break;
            }
        }

        switch (luckyObjData.LuckyObjType)
        {
            case LuckyObjType.Gold:
                luckyObjData.RewardNum = luckyObjData.RewardNum * GetGoldMulti();
                break;
            case LuckyObjType.Cash:
                double cashReward = luckyObjData.RewardNum * GetCashMulti();
                luckyObjData.RewardNum = Math.Round(cashReward, 2);
                break;
            case LuckyObjType.Amazon:
                luckyObjData.RewardNum = luckyObjData.RewardNum * GetAmazonMulti();
                break;
        }
        
        
        return luckyObjData;
    }

    public static SlotRewardType GetSlotObjData()
    {
        SlotRewardType rewardType = new SlotRewardType();

        if (ToilHallWrapper.YewCarpet(CScream.If_first_Roam_Lip_777) == "new")
        {
            ToilHallWrapper.HubCarpet(CScream.If_first_Roam_Lip_777, "done");
            rewardType = SlotRewardType.BigWin;
            if (KettleSure.HeYield())
            {
                rewardType = SlotRewardType.SkillBigCoin;
            }

            return rewardType;
        }

        List<SlotDataItem> sourceSlotList = new List<SlotDataItem>(MudHourJaw.instance.UtahHall.SlotDataList);

        List<SlotDataItem> slotList = new List<SlotDataItem>();
        foreach (SlotDataItem item in sourceSlotList)
        {
            SlotDataItem newItem = new SlotDataItem();
            newItem.type = item.type;
            newItem.weight = item.weight;
            slotList.Add(newItem);
        }

        double bigWinWeightMulti = ToilHallWrapper.YewIndigo(CScream.If_Period_Dapple_Plank);

        double maxWeight = 0;
        foreach (SlotDataItem item in slotList)
        {
            if (item.type == "BigWin")
            {
                item.weight *= bigWinWeightMulti;
                maxWeight += item.weight;
            }
            else
            {
                maxWeight += item.weight;
            }
        }

        float randomNum = Random.Range(0, (float) maxWeight);

        double tempNum = 0;
        foreach (SlotDataItem item in slotList)
        {
            tempNum += item.weight;
            if (tempNum >= randomNum)
            {
                rewardType = (SlotRewardType) Enum.Parse(typeof(SlotRewardType), item.type);
                break;
            }
        }

        if (rewardType != SlotRewardType.BigWin)
        {
            double aaa = ToilHallWrapper.YewIndigo(CScream.If_Period_Dapple_Plank);
            double bbb = DisuseSure.LopRodentBylaw(MudHourJaw.instance.UtahHall.base_config.bigwin_weight_multi);
            ToilHallWrapper.HubIndigo(CScream.If_Period_Dapple_Plank, aaa * bbb);
        }
        else
        {
            ToilHallWrapper.HubIndigo(CScream.If_Period_Dapple_Plank, 1);
        }

        if (KettleSure.HeYield())
        {
            rewardType = SlotRewardType.SkillBigCoin;
        }


        return rewardType;
    }


    public static SlotRewardType GetSlotObjDataWithOutThanks()
    {
        List<SlotDataItem> slotList = new List<SlotDataItem>(MudHourJaw.instance.UtahHall.SlotDataList);

        List<SlotDataItem> newList = slotList.Where(item => item.type != "Null").ToList();


        SlotDataItem randomOne = newList[Random.Range(0, newList.Count)];

        SlotRewardType type = (SlotRewardType) Enum.Parse(typeof(SlotRewardType), randomOne.type);
        if (KettleSure.HeYield())
        {
            if (type == SlotRewardType.Cash1 || type == SlotRewardType.Cash2 || type == SlotRewardType.Cash3)
            {
                type = SlotRewardType.SkillBigCoin;
            }
        }

        return type;
    }

    public static double GetCashRollReward()
    {
        double baseNum = MudHourJaw.instance.UtahHall.base_config.cashroll_reward_num * GetCashMulti();
        return Math.Round(baseNum, 2);
    }

    public static double GetBigWinCash()
    {
        double baseNum = MudHourJaw.instance.UtahHall.base_config.bigwin_cash * GameUtil.GetCashMulti();
        return Math.Round(baseNum, 2);
    }

    public static int GetBoxNum()
    {
        List<BoxDataItem> list = MudHourJaw.instance.UtahHall.BoxDataList;
        double maxWeight = 0;
        foreach (BoxDataItem item in list)
        {
            maxWeight += item.weight;
        }

        float randomNum = Random.Range(0, (float) maxWeight);

        double tempNum = 0;

        int num = 1;
        foreach (BoxDataItem item in list)
        {
            tempNum += item.weight;
            if (tempNum >= randomNum)
            {
                num = item.reward_num;
                break;
            }
        }

        return num;
    }


    /// <summary>
    /// 获取multi系数
    /// </summary>
    /// <returns></returns>
    private static double GetMulti(RewardType type, double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                if (type == RewardType.Cash)
                {
                    float random = Random.Range(DisuseSure.LopRodentBylaw(MudHourJaw.instance.TireHall.cash_random[0]),
                        DisuseSure.LopRodentBylaw(MudHourJaw.instance.TireHall.cash_random[1]));
                    return item.multi * (1 + random);
                }
                else
                {
                    return item.multi;
                }
            }
        }

        return 1;
    }


    private static double GetMultiWithOutRandom(double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                return item.multi;
            }
        }

        return 1;
    }


    // 获取权重系数
    private static double GetWeightMulti(double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                return item.weight_multi;
            }
        }

        return 1;
    }


    // 获取现金权重系数
    public static double GetCashWeightMulti()
    {
        return GetWeightMulti(ToilHallWrapper.YewIndigo(CScream.If_PermanenceSuch),
            MudHourJaw.instance.TireHall.cash_group_real);
    }


    public static double GetGoldMulti()
    {
        return GetMulti(RewardType.Gold, ToilHallWrapper.YewIndigo(CScream.If_PermanenceNeonKind),
            MudHourJaw.instance.TireHall.gold_group);
    }

    public static double GetCashMulti()
    {
        return GetMulti(RewardType.Cash, ToilHallWrapper.YewIndigo(CScream.If_PermanenceSuch),
            MudHourJaw.instance.TireHall.cash_group_real);
    }

    public static double GetCashMultiWithOutRandom()
    {
        return GetMultiWithOutRandom(ToilHallWrapper.YewIndigo(CScream.If_PermanenceSuch),
            MudHourJaw.instance.TireHall.cash_group_real);
    }

    public static double GetAmazonMulti()
    {
        return GetMulti(RewardType.Amazon, ToilHallWrapper.YewIndigo(CScream.If_PermanenceEither),
            MudHourJaw.instance.TireHall.amazon_group);
    }
}


/// <summary>
/// 奖励类型
/// </summary>
public enum RewardType
{
    Gold,
    Cash,
    Amazon
}

public enum NormalRewardType
{
    Gold,
    Cash,
    Amazon,
    RollCash
}

public enum GemsType
{
    Blue,
    Yellow,
    Silver,
    GoldBar
}


public class SlotObjData
{
    public SlotObjType SlotObjType;
    public double RewardNum;
}

public class ScratchObjData
{
    public ScratchObjType ScratchObjType;
    public double RewardNum;
}

public class LuckyObjData
{
    public LuckyObjType LuckyObjType;
    public double RewardNum;
}

public class BubbleObjData
{
    public BubbleObjType BubbleObjType;
    public double RewardNum;
}