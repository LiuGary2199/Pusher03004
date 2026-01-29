// Project: Plinko
// FileName: UtahFoil.cs
// Author: AX
// CreateDate: 20230427
// CreateTime: 10:10
// Description:

using UnityEngine;


// 金币 现金  石头  炸弹  分裂  抽奖  刮刮卡
public enum PillarObjType
{
    Gold, 
    Cash, 
    Stone,
    Bomb,
    Division,
    BigGold,
    BigCash,
    Lottery,
    Scratch
}

public enum BucketObjType
{
    Gold,
    Cash,
    Amazon
}

public enum SlotObjType
{
    Bomb,
    Cash,
    Ball,
    Division,
    BigWin,
    Thanks
}

public enum ScratchObjType
{
    Gold,
    Cash,
    Amazon
}

public enum LuckyObjType
{
    Gold,
    Cash,
    Amazon
}

public enum BubbleObjType
{
    Gold,
    Cash,
    Amazon
}



public enum BigRewardType {
    Gold,
    Cash,
    Amazon

}

public enum BigWinType
{
    BigWin,
    HugeWin,
    MegaWin
}

public class BubbleDataItem
{
    public string type;
    public double weight;
    public double reward_num;
}



