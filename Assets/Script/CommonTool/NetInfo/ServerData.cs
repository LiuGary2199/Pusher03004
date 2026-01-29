using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//登录服务器返回数据
public class RootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public ServerData data { get; set; }
}

//用户登录信息
public class ServerUserData
{
    public int code { get; set; }
    public string msg { get; set; }
    public int data { get; set; }
}

public class CashOutData //提现
{
    public string MoneyName; //货币名称
    public string Description; //玩法描述
    public string convert_goal; //兑换目标
    public List<CashOut_TaskData> TaskList; //任务列表
}

public class CashOut_TaskData
{
    public string Name; //任务名称
    public float NowValue; //当前值
    public double Target; //目标值
    public string Description; //任务描述
    public bool IsDefault; //是否默认（循环）任务
}


//服务器的数据
public class ServerData
{
    public string CashOut_Data { get; set; } //真提现数据
    public string init { get; set; }
    public string init_us { get; set; }
    public string init_ru { get; set; }
    public string init_br { get; set; }
    public string init_jp { get; set; }
    public string version { get; set; }

    public string apple_pie { get; set; }
    public string inter_b2f_count { get; set; }
    public string inter_freq { get; set; }
    public string relax_interval { get; set; }
    public string trial_MaxNum { get; set; }
    public string nextlevel_interval { get; set; }
    public string adjust_init_rate_act { get; set; }
    public string adjust_init_act_position { get; set; }
    public string soho_shop_us { get; set; }
    public string soho_shop_jp { get; set; }
    public string soho_shop_br { get; set; }
    public string soho_shop_ru { get; set; }
    public string soho_shop { get; set; }

    public string game_data { get; set; }
    
    public string game_data_ru { get; set; }
    
    public string game_data_us { get; set; }
    
    public string game_data_br { get; set; }
    public string game_data_jp { get; set; }
    public string fall_down { get; set; }
    public string HeiNameList { get; set; } //IP黑名单列表
    public string LocationList { get; set; } //黑位置列表
    public string HeiCity { get; set; } //城市黑名单列表
    public string CashOut_MoneyName { get; set; } //货币名称
    public string CashOut_Description { get; set; } //玩法描述
    public string convert_goal { get; set; } //兑换目标
    public string Exchange { get; set; } //金币兑换绿币

}

public class Init
{
    public List<RewardMultiItem> RewardMultiList { get; set; }

    public string[] cash_random { get; set; }
    public MultiGroup_2[] cash_group { get; set; }
    public MultiGroup[] cash_group_real { get; set; }
    public MultiGroup[] gold_group { get; set; }
    public MultiGroup[] amazon_group { get; set; }

    public List<double> coin_cash_reward_list;

    public List<double> coin_cash_weight_list;

    public List<CoinGoldDataItem> coin_gold_group;
}

public class GameData
{
    public List<ScratchDataItem> scratch_data_list { get; set; }
    public List<LuckyDataItem> lucky_card_data_list { get; set; }
    public List<BubbleDataItem> bubble_data_list { get; set; }
    public List<SlotDataItem> SlotDataList { get; set; }
    public List<GemsDataItem> Gem_Reward_list { get; set; }

    public List<InterstitialData> Interstitial_data_list { get; set; }
    public BaseConfig base_config { get; set; }

    public List<BoxDataItem> BoxDataList { get; set; }
}


public class BaseConfig
{
    public int ball_limit { get; set; }
    public double multiball_cd { get; set; }
    public int little_game_refresh { get; set; }
    public int lucky_card_win_max_count { get; set; }
    public int fever_time { get; set; }
    public int fever_limit { get; set; }
    public int scratch_win_max_count { get; set; }
    public int bubble_time { get; set; }

    public int cashroll_reward_num { get; set; }
    public double bigwin_cash { get; set; }

    public string bigwin_weight_multi { get; set; }
    public int little_game_time { get; set; }
    public int new_user_ball_count { get; set; }
    public string touch_cd { get; set; }
}


public class ScratchDataItem
{
    public string type;
    private double _weight;

    public double weight
    {
        get
        {
            if (type == "Cash")
            {
                return _weight * GameUtil.GetCashWeightMulti();
            }

            return _weight;
        }
        set { _weight = value; }
    }

    public double reward_num;
}


public class InterstitialData
{
    public string type;

    public double weight;

    public double reward_num;
}

public class LuckyDataItem
{
    public string type;

    public double weight;

    public double reward_num;
}

public class GemsDataItem
{
    public string reward_type;
    public string gem_type;
    public int gem_limit;
    public double reward_num;
}

public class RewardMultiItem
{
    public int multi { get; set; }
    public int weight { get; set; }
}

public class SlotDataItem
{
    public string type;
    public double weight;
}

public class MultiGroup_2
{
    public int max { get; set; }
    public string multi { get; set; }
    
    public double weight_multi { get; set; }
}

public class MultiGroup
{
    public int max { get; set; }
    public double multi { get; set; }

    public double weight_multi { get; set; }
}

public class CoinGoldDataItem
{
    public double max;
    public List<double> reward_list;
    public List<double> weight_list;
}

public class BoxDataItem
{
    public double weight;
    public int reward_num;
}
public class UserRootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public string data { get; set; }
}

public class LocationData
{
    public double X;
    public double Y;
    public double Radius;
}

public class UserInfoData
{
    public double lat;
    public double lon;
    public string query; //ip地址
    public string regionName; //地区名称
    public string city; //城市名称
    public bool IsHaveApple; //是否有苹果
}

