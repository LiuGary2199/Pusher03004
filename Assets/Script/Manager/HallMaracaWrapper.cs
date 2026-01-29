using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PusherRewardType
{
    CoinGold,
    CoinCash,
    RollCash,
    GemBlue,
    GemRed,
    GemDiamond,
    Golden,
    ScratchCard,
    LuckyCard,
    BigCoin
}

public enum SlotRewardType
{
    BigWin = 0,
    Cash1 = 1,
    Cash2 = 2,
    Cash3 = 3,
    SkillWall = 4,
    SkillBigCoin = 5,
    SkillLong = 6,
    GemBlue = 7,
    GemRed = 8,
    GemDiamond = 9,
    Golden = 10,
    Null = 11
}

public class HallMaracaWrapper : MonoWeightily<HallMaracaWrapper>
{
    /// <summary>
    /// 获得pusher掉落奖励
    /// </summary>
    /// <param name="item"></param>
    public void GelRevealSunlit(PusherRewardType type, double rewardNum)
    {
        switch (type)
        {
            case PusherRewardType.CoinCash:
                UtahScore.Instance.YewSuch(rewardNum);
                break;
            case PusherRewardType.CoinGold:
                UtahScore.Instance.YewNeon(rewardNum);
                break;
            case PusherRewardType.RollCash:
                SunlitScoreWrapper.Instance.SinkSuchSodaSunlit();
                break;
            case PusherRewardType.GemDiamond:
                UtahHallWrapper.YewVocation().YewTie(GemsType.Silver);
                break;
            case PusherRewardType.GemBlue:
                UtahHallWrapper.YewVocation().YewTie(GemsType.Blue);
                break;
            case PusherRewardType.GemRed:
                UtahHallWrapper.YewVocation().YewTie(GemsType.Yellow);
                break;
            case PusherRewardType.Golden:
                UtahHallWrapper.YewVocation().YewTie(GemsType.GoldBar);

                break;
            case PusherRewardType.ScratchCard:
                DemisePrimeWrapper.Instance.SinkExecuteDeedScore();
                break;
            case PusherRewardType.LuckyCard:
                DemisePrimeWrapper.Instance.SinkPeskyDeedScore();
                break;
            case PusherRewardType.BigCoin:
                UtahScore.Instance.YewNeon(1);
                break;
        }
    }

    /// <summary>
    /// 获取plinko格子创建金币的数量
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int EraNeedleKindPupil(int index)
    {
        return GameUtil.GetBoxNum();
    }

    /// <summary>
    /// 获取自动掉落物体类型
    /// </summary>
    /// <returns></returns>
    public PusherRewardType EraSendCordMyFist()
    {
        int typeIndex = Random.Range(0, 3);
        PusherRewardType type = PusherRewardType.RollCash;
        switch (typeIndex)
        {
            case 0:
                type = PusherRewardType.RollCash;
                break;
            case 1:
                type = PusherRewardType.ScratchCard;
                break;
            case 2:
                type = PusherRewardType.LuckyCard;
                break;
        }

        return type;
    }

    /// <summary>
    /// 获取slot中奖项(从此函数中调用slot动画)
    /// </summary>
    public void EraCrabSunlitHall(System.Action<SlotRewardType> rewardAction)
    {
        SlotRewardType slotRewardType = GameUtil.GetSlotObjData();
        if (KettleSure.HeYield())
        {
            while (slotRewardType == SlotRewardType.Null && RubTenthFastWrapper.Instance.WeTenthFast)
            {
                slotRewardType = GameUtil.GetSlotObjData();
            }
        }
        else
        {
            while (slotRewardType == SlotRewardType.Null && TenthFastWrapper.Instance.WeTenthFast)
            {
                slotRewardType = GameUtil.GetSlotObjData();
            }
        }
        rewardAction(slotRewardType);
    }

    /// <summary>
    /// 墙技能触发
    /// </summary>
    /// <param name="needShow">是否需要UI滑出动画,如果为false则只需要增加显示时长</param>
    /// <param name="time">单次增加的时长</param>
    public void HeroCourtLakeFast(bool needShow, int time)
    {
        CourtWrapper.Instance.AloneCourtLake(needShow,time);
    }

    /// <summary>
    /// 加长技能触发
    /// </summary>
    /// <param name="needShow">是否需要UI滑出动画,如果为false则只需要增加显示时长</param>
    /// <param name="time">单次增加的时长</param>
    public void HeroCourtFallFast(bool needShow, int time)
    {
        CourtWrapper.Instance.AloneCourtFall(needShow,time);
    }
    /// <summary>
    /// 刷新剩余未掉落绿币显示个数
    /// </summary>
    public void HeroCordSuchKindPupil(bool needShow, int count)
    {
        CourtWrapper.Instance.SinkSuchKindBed(needShow,count);
    }

    /// <summary>
    /// 777结束
    /// </summary>
    public void LysVasEnd()
    {

    }
    /// <summary>
    /// fever结束
    /// </summary>
    public void TrashSow()
    {

    }

    /// <summary>
    /// 获取金币面额
    /// </summary>
    /// <returns></returns>
    public int EraNeonKindBed()
    {
        double coinValues = GameUtil.GetPusherGoldReward();
        return int.Parse(coinValues.ToString());
    }

    /// <summary>
    /// 获取绿币面额
    /// </summary>
    /// <returns></returns>
    public int EraSuchKindBed()
    {
        double coinValues = GameUtil.GetPusherCashReward();
        return int.Parse(coinValues.ToString());
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