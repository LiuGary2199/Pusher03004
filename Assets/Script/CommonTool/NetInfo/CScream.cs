/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScream
{
    #region 常量字段
    //登录url
    public const string GrantSum= "/api/client/user/getId?gameCode=";
    //配置url
    public const string ScreamSum= "/api/client/config?gameCode=";
    //时间戳url
    public const string FastSum= "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string CosmosSum= "/api/client/user/setAdjustId?gameCode=";
    
    public const string Pig_Masthead= "sys_language";

    public const string Pig_BuySH= "sys_AppSH";
    #endregion

    #region 本地存储的字符串


    public const string If_IsTireHall= "sv_IsInitData";

    public const string If_Lys_Lip_Flap= "sv_big_win_cash";
    
    public const string Ask_Chain_Brawl_Toe_Loess= "msg_close_panel_and_start";

    public const string If_Trash_Rust_Surmise= "sv_fever_time_current";

    public const string If_Rancho_Fly_Wipe_Panel= "sv_finish_new_user_guide";

    public const string If_Period_Dapple_Plank= "sv_bigwin_weight_multi";
    
    
    
    
    
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string If_GrapeUserGo= "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string If_GrapeSourceGo= "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string If_HeRubObtain= "sv_IsNewPlayer";

    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string If_AloftSouthGetPupil= "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string If_AloftSouthPork= "sv_DailyBounsDate";
    /// <summary>
    /// 新手引导完成的步数
    /// </summary>
    public const string If_RubTiltSuck= "sv_NewUserStep";
    /// <summary>
    /// 金币余额
    /// </summary>
    public const string If_NeonKind= "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string If_PermanenceNeonKind= "sv_CumulativeGoldCoin";
    
    public const string If_Such= "sv_Cash";

    public const string If_PermanenceSuch= "sv_CumulativeCash";

    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string If_Either= "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string If_PermanenceEither= "sv_CumulativeAmazon";
    
    public const string If_Lease_Luce_Fox= "sv_steel_ball_num";

    public const string If_PermanenceLife= "sv_CumulativeBall";
    
    public const string If_Lease_Luce_Have= "sv_steel_ball_date";
    
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string If_AgreeUtahFast= "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string If_BloomYewPearl= "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string If_GutSinkDivaScore= "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string If_PermanenceConnect= "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string If_SeafoodPestPlunge= "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string If_RubTiltSuckExpose= "sv_NewUserStepFinish";
    public const string If_Lion_Awful_Giant= "sv_task_level_count";
    // 是否第一次使用过slot
    public const string If_BloomCrab= "sv_FirstSlot";
    /// <summary>
    /// adjust adid
    /// </summary>
    public const string If_CosmosEdge= "sv_AdjustAdid";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string If_It_trial_Fox= "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string If_Dutch_It_Fox= "sv_total_ad_num";


    public const string If_first_Roam_Lip_777= "sv_first_bing_win_777";
    
    public const string If_Loess_Roam_Lip_Sierra= "sv_first_bing_win_reward";
    public const string Ask_Hero_Flap_Fair= "msg_show_cash_mask";
    public const string If_Loess_Ere_Ant= "sv_start_fiy_box";
    public const string If_Loess_Flap_Shy= "sv_first_cash_out";
    public const string Ask_Hero_Tine_us= "msg_show_rate_us";
    public const string If_Loess_Pest_Aloof= "sv_first_slot_again";
    public const string If_Prompt_Lip_It_To= "sv_normal_win_ad_id";
    public const string If_Prompt_Lip_Stir= "sv_normal_win_type";
    public const string If_Twig_Stir= "sv_gems_type";
    public const string If_Mislead_Gel_Luce= "sv_first_add_ball";


    // 任务系统
    public const string HugeKilnCrustalHall_B = "LastTaskRefreshDate_B";
    public const string KilnSawyer_B = "TaskStatus_B_"; // TaskStatus_B_{taskId}
    public const string KilnExterior_B = "TaskProgress_B_"; // TaskProgress_B_{taskId}
    public const string ClickBroadcastHamper_B = "TodayCompletedLevels_B"; // 今天完成的关卡数

    // 时间领奖系统
    public const string HugeVagueCrustalHall_A = "LastTimerRefreshDate_A";
    public const string VagueSawyer_A = "TimerStatus_A_"; // TimerStatus_A_{timerId}
    public const string VagueThereFact_A = "TimerStartTime_A_"; // TimerStartTime_A_{timerId} 每个计时器的开始时间（累积在线时长，秒）
    public const string VagueHomogeneousFact_A = "TimerAccumulatedTime_A"; // 累积的在线时长（秒）
    public const string VagueHugeDefendFact_A = "TimerLastUpdateTime_A"; // 上次更新时间（Time.unscaledTime）   

    #endregion

    #region 监听发送的消息

    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string mg_HugelyDown= "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string So_HugelyPiano= "mg_WindowClose";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string So_ui_Hydroelectric= "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string So_If_Compare= "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string So_If_Freezing= "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string So_If_Prevalent= "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string So_UtahChannel= "mg_GameSuspend";

    #endregion

    #region 动态加载资源的路径

    // 金币图片
    public static string Epic_NeonKind_Humble= "Art/Tex/UI/jiangli1";
    // 钻石图片
    public static string Epic_Pearl_Humble_Eighty= "Art/Tex/UI/jiangli4";

    public static string Tie_Even= "Prefab/Tie_Even";
    public static string Tie_Zoo= "Prefab/Tie_Zoo";
    public static string Tie_Heroism= "Prefab/Tie_Heroism";
    public static string Tie_Concur= "Prefab/Concur";
    public static string Ail_10= "Art/Tex/Ail_10";
    public static string Ail_8= "Art/Tex/Ail_8";
    public static string PegPupil= "Art/Tex/BoxCount/x";

    #endregion
}

