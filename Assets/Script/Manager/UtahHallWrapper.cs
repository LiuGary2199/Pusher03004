using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtahHallWrapper : MonoWeightily<UtahHallWrapper>
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void TireUtahHall()
    {
        TireRubHall();

    }


    private void TireRubHall()
    {
        if (ToilHallWrapper.YewCarpet(CScream.If_IsTireHall) != "done")
        {
            // 新用户 初始化数据
            ToilHallWrapper.HubCarpet(CScream.If_IsTireHall, "done");
            // 新手引导
            ToilHallWrapper.HubCarpet(CScream.If_Rancho_Fly_Wipe_Panel, "new");
            ToilHallWrapper.HubCarpet(CScream.If_first_Roam_Lip_777, "new");
            ToilHallWrapper.HubCarpet(CScream.If_BloomCrab, "new");
            ToilHallWrapper.HubCarpet(CScream.If_Loess_Roam_Lip_Sierra, "new");
            ToilHallWrapper.HubCarpet(CScream.If_Loess_Ere_Ant, "new");
            ToilHallWrapper.HubCarpet(CScream.If_Loess_Flap_Shy, "new");
            ToilHallWrapper.HubCarpet(CScream.Ask_Hero_Tine_us, "new");
            ToilHallWrapper.HubCarpet(CScream.If_Loess_Pest_Aloof, "new");
            

            
            //收集物初始化
            ToilHallWrapper.HubSow(GemsType.Blue.ToString(), 0);
            ToilHallWrapper.HubSow(GemsType.Blue + "All", 0);
            ToilHallWrapper.HubSow(GemsType.Yellow.ToString(), 0);
            ToilHallWrapper.HubSow(GemsType.Yellow + "All", 0);
            ToilHallWrapper.HubSow(GemsType.Silver.ToString(), 0);
            ToilHallWrapper.HubSow(GemsType.Silver + "All", 0);
            ToilHallWrapper.HubSow(GemsType.GoldBar.ToString(), 0);
            ToilHallWrapper.HubSow(GemsType.GoldBar + "All", 0);
            
            // 余额初始化
            ToilHallWrapper.HubIndigo(CScream.If_Such, 0);
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceSuch, 0);
            ToilHallWrapper.HubIndigo(CScream.If_NeonKind, 0);
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceNeonKind, 0);
            ToilHallWrapper.HubIndigo(CScream.If_Either, 0);
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceEither, 0);
            ToilHallWrapper.HubSow(CScream.If_Lease_Luce_Fox, MudHourJaw.instance.UtahHall.base_config.new_user_ball_count);
            ToilHallWrapper.HubSow(CScream.If_PermanenceLife, 30);
            
            ToilHallWrapper.HubIndigo(CScream.If_Period_Dapple_Plank, 1);
            
        }

        // 
        List<GemsDataItem> JobHallGerm= MudHourJaw.instance.UtahHall.Gem_Reward_list;
        foreach (GemsDataItem item in JobHallGerm)
        {
            string gemType = item.gem_type;
            int gemMax = item.gem_limit;
            ToilHallWrapper.HubSow(gemType + "Max", gemMax);
        }
    }

    // 金币
    public double YewNeon()
    {
        return ToilHallWrapper.YewIndigo(CScream.If_NeonKind);
    }

    public double YewPermanenceNeonKind()
    {
        return ToilHallWrapper.YewIndigo(CScream.If_PermanenceNeonKind);
    }

    public void YewNeon(double gold)
    {
        YewNeon(gold, BeauWrapper.Instance.transform);
    }

    public void YewNeon(double gold, Transform startTransform)
    {
        double oldGold = ToilHallWrapper.YewIndigo(CScream.If_NeonKind);
        ToilHallWrapper.HubIndigo(CScream.If_NeonKind, oldGold + gold);
        if (gold > 0)
        {
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceNeonKind,
                ToilHallWrapper.YewIndigo(CScream.If_PermanenceNeonKind) + gold);
        }

        // CorrectHall md = new CorrectHall(oldGold);
        // md.valueTransform = startTransform;
        // CorrectFingerSpoil.GetInstance().Send(CScream.mg_ui_addgold, md);
    }

    // 现金
    public double YewSuch()
    {
       // return ToilHallWrapper.GetDouble(CScream.sv_Cash);
        return CashOutManager.YewVocation().Money;
    }
    
    public double YewPermanenceSuch()
    {
        return ToilHallWrapper.YewIndigo(CScream.If_PermanenceSuch);
    }

    public void YewSuch(double cash)
    {
        //AddCash(cash, BeauWrapper.Instance.transform);
        CashOutManager.YewVocation().AddMoney((float)cash);
    }

    public void YewSuch(double cash, Transform startTransform)
    {
        double oldCash = ToilHallWrapper.YewIndigo(CScream.If_Such);
        double newCash = oldCash + cash;
        ToilHallWrapper.HubIndigo(CScream.If_Such, newCash);
        if (cash > 0)
        {
            double allCash = ToilHallWrapper.YewIndigo(CScream.If_PermanenceSuch);
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceSuch, allCash + cash);
        }
//#if SOHOShop
//        SOHOShopManager.instance.UpdateCash();
//#endif
        // CorrectHall md = new CorrectHall(oldCash);
        // md.valueTransform = startTransform;
        // CorrectFingerSpoil.GetInstance().Send(CScream.mg_ui_addtoken, md);
    }

    //Amazon卡
    public double YewEither()
    {
        return ToilHallWrapper.YewIndigo(CScream.If_Either);
    }
    
    public double YewPermanenceEither()
    {
        return ToilHallWrapper.YewIndigo(CScream.If_PermanenceEither);
    }

    public void YewEither(double amazon)
    {
        YewEither(amazon, BeauWrapper.Instance.transform);
    }

    public void YewEither(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CScream.If_Either)
            ? double.Parse(ToilHallWrapper.YewCarpet(CScream.If_Either))
            : 0;
        double newAmazon = oldAmazon + amazon;
        ToilHallWrapper.HubIndigo(CScream.If_Either, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = ToilHallWrapper.YewIndigo(CScream.If_PermanenceEither);
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceEither, allAmazon + amazon);
        }

        CorrectHall md = new CorrectHall(oldAmazon);
        md.ClothPolitical = startTransform;
        CorrectFingerSpoil.YewVocation().Pool(CScream.So_If_Prevalent, md);
    }


    public int YewLife()
    {
        return ToilHallWrapper.YewSow(CScream.If_Lease_Luce_Fox);
    }

    public void YewLife(int num)
    {
        // ToilHallWrapper.SetInt(CScream.sv_steel_ball_num, ToilHallWrapper.GetInt(CScream.sv_steel_ball_num) + num);
        ToilHallWrapper.HubSow(CScream.If_PermanenceLife, ToilHallWrapper.YewSow(CScream.If_PermanenceLife) + num);
    }


    public void YewTie(GemsType gemsType)
    {
        ToilHallWrapper.HubSow(gemsType.ToString(), ToilHallWrapper.YewSow(gemsType.ToString()) + 1);
        ToilHallWrapper.HubSow(gemsType + "All", ToilHallWrapper.YewSow(gemsType + "All") + 1);
        if (ToilHallWrapper.YewSow(gemsType.ToString()) == ToilHallWrapper.YewSow(gemsType + "Max"))
        {
            DemisePrimeWrapper.Instance.SinkNonstopCaputScore();
        }

    }


    // 四个计时器：5、10、15、20分钟
    private readonly int[] GourdHerculean = { 1, 10, 15, 20 }; // 每个计时器的分钟数
    private readonly int GourdCustom = 200; // 每个奖励200金币
    private float _RimeDefendFact = 0f; // 上次更新时间（Time.unscaledTime）
    private float _TransactionFact = 0f; // 累积的在线时长（秒）
    /// <summary>
    /// 检查并刷新每日时间领奖
    /// </summary>
    public void ScrubDieCrustalValveCensus()
    {
        string lastRefreshDate = PlayerPrefs.GetString(CScream.HugeVagueCrustalHall_A, "");
        string today = DateTime.Now.ToString("yyyy-MM-dd");

        if (lastRefreshDate != today)
        {
            // 新的一天，重置所有计时器
            CrustalValveCensus();
            PlayerPrefs.SetString(CScream.HugeVagueCrustalHall_A, today);
        }
        else
        {
            // 恢复累积的在线时长和上次更新时间
            _TransactionFact = PlayerPrefs.GetFloat(CScream.VagueHomogeneousFact_A, 0f);
            float lastUpdateTime = PlayerPrefs.GetFloat(CScream.VagueHugeDefendFact_A, 0f);
            
            // 如果上次更新时间有效，计算从上次保存到现在的时间差并加到累积时长上
            if (lastUpdateTime > 0)
            {
                float deltaTime = Time.unscaledTime - lastUpdateTime;
                if (deltaTime > 0)
                {
                    _TransactionFact += deltaTime;
                    // 保存更新后的累积时长
                    PlayerPrefs.SetFloat(CScream.VagueHomogeneousFact_A, _TransactionFact);
                }
            }
            
            _RimeDefendFact = Time.unscaledTime;
            // 保存当前更新时间
            PlayerPrefs.SetFloat(CScream.VagueHugeDefendFact_A, _RimeDefendFact);

            // 检查第一个计时器是否已启动，如果没有则启动
            if (CopVagueThereFact(0) < 0)
            {
                ThereVague(0);
            }
        }

        // 确保_lastUpdateTime已初始化
        if (_RimeDefendFact <= 0)
        {
            _RimeDefendFact = Time.unscaledTime;
        }
    }
    /// <summary>
    /// 刷新每日计时器（重置所有计时器状态）
    /// </summary>
    private void CrustalValveCensus()
    {
        for (int i = 0; i < GourdHerculean.Length; i++)
        {
            int GourdIt = i;
            KeyVagueSawyer(GourdIt, ATimerStatus_A.Incomplete);
            KeyVagueThereFact(GourdIt, -1f); // -1表示未启动
        }

        // 重置累积时长
        _TransactionFact = 0f;
        _RimeDefendFact = Time.unscaledTime;
        PlayerPrefs.SetFloat(CScream.VagueHomogeneousFact_A, 0f);
        PlayerPrefs.SetFloat(CScream.VagueHugeDefendFact_A, _RimeDefendFact);

        // 启动第一个计时器
        ThereVague(0);
    }
    /// <summary>
    /// 设置计时器开始时间（累积在线时长，秒）- 每个计时器独立
    /// </summary>
    public void KeyVagueThereFact(int timerId, float accumulatedTime)
    {
        string key = CScream.VagueThereFact_A + timerId;
        PlayerPrefs.SetFloat(key, accumulatedTime);
    }
    /// <summary>
    /// 启动计时器（使用当前的累积在线时长作为开始时间）
    /// </summary>
    public void ThereVague(int timerId)
    {
        if (timerId < 0 || timerId >= GourdHerculean.Length)
            return;

        // 确保累积时长已更新
        DefendVagueHomogeneousFact();

        KeyVagueThereFact(timerId, _TransactionFact);
        KeyVagueSawyer(timerId, ATimerStatus_A.Incomplete);
    }
    /// <summary>
    /// 获取计时器时长（分钟）- 显示用
    /// </summary>
    public int CopVagueSecurely(int timerId)
    {
        if (timerId < 0 || timerId >= GourdHerculean.Length)
            return 0;
        return GourdHerculean[timerId];
    }
    /// <summary>
    /// 获取计时器状态
    /// </summary>
    public ATimerStatus_A CopVagueSawyer(int timerId)
    {
        string key = CScream.VagueSawyer_A + timerId;
        return (ATimerStatus_A)PlayerPrefs.GetInt(key, (int)ATimerStatus_A.Incomplete);
    }
    void OnApplicationQuit()
    {
        // 保存累积在线时长
        DefendVagueHomogeneousFact();
    }
    /// <summary>
    /// 获取计时器剩余时间（秒）
    /// </summary>
    public int CopVaguePrivatelyReceive(int timerId)
    {
        if (timerId < 0 || timerId >= GourdHerculean.Length)
            return 0;

        ATimerStatus_A status = CopVagueSawyer(timerId);
        if (status == ATimerStatus_A.Ready || status == ATimerStatus_A.Completed)
            return 0; // 已完成或已领取

        // 检查前一个是否已领取
        if (timerId > 0)
        {
            ATimerStatus_A prevStatus = CopVagueSawyer(timerId - 1);
            if (prevStatus != ATimerStatus_A.Completed)
            {
                // 前一个未领取，这个计时器未启动，返回总时长
                return GourdHerculean[timerId] * 60;
            }
        }

        float startTime = CopVagueThereFact(timerId);
        if (startTime < 0)
        {
            // 未启动，返回总时长
            return GourdHerculean[timerId] * 60;
        }

        // 更新累积时长
        DefendVagueHomogeneousFact();

        float elapsedTime = _TransactionFact - startTime;
        int requiredSeconds = GourdHerculean[timerId] * 60;
        int remaining = requiredSeconds - (int)elapsedTime;

        return Mathf.Max(0, remaining);
    }
    /// <summary>
    /// 获取计时器开始时间（累积在线时长，秒）- 每个计时器独立
    /// </summary>
    public float CopVagueThereFact(int timerId)
    {
        string key = CScream.VagueThereFact_A + timerId;
        return PlayerPrefs.GetFloat(key, -1f); // -1表示未启动
    }
    /// <summary>
    /// 设置计时器状态
    /// </summary>
    public void KeyVagueSawyer(int timerId, ATimerStatus_A status)
    {
        string key = CScream.VagueSawyer_A + timerId;
        PlayerPrefs.SetInt(key, (int)status);
    }
    /// <summary>
    /// 更新累积在线时长（需要在Update中调用）
    /// </summary>
    public void DefendVagueHomogeneousFact()
    {
        if (_RimeDefendFact <= 0)
        {
            _RimeDefendFact = Time.unscaledTime;
            // 保存更新时间
            PlayerPrefs.SetFloat(CScream.VagueHugeDefendFact_A, _RimeDefendFact);
            return;
        }

        float deltaTime = Time.unscaledTime - _RimeDefendFact;
        if (deltaTime > 0)
        {
            _TransactionFact += deltaTime;
            _RimeDefendFact = Time.unscaledTime;

            // 保存累积时长和更新时间
            PlayerPrefs.SetFloat(CScream.VagueHomogeneousFact_A, _TransactionFact);
            PlayerPrefs.SetFloat(CScream.VagueHugeDefendFact_A, _RimeDefendFact);
        }
    }
         /// <summary>
         /// 检查计时器是否完成
         /// </summary>
         
    public bool GoVagueVital(int timerId)
    {
        if (timerId < 0 || timerId >= GourdHerculean.Length)
            return false;

        ATimerStatus_A status = CopVagueSawyer(timerId);
        if (status == ATimerStatus_A.Completed)
            return false; // 已领取

        if (status == ATimerStatus_A.Ready)
            return true; // 已完成，可领取

        // 检查前一个是否已领取（必须按顺序领取）
        if (timerId > 0)
        {
            ATimerStatus_A prevStatus = CopVagueSawyer(timerId - 1);
            if (prevStatus != ATimerStatus_A.Completed)
            {
                return false; // 前一个未领取，这个不能完成
            }
        }

        // 检查计时器是否已启动
        float startTime = CopVagueThereFact(timerId);
        if (startTime < 0)
            return false; // 未启动

        // 更新累积时长
        DefendVagueHomogeneousFact();

        // 检查是否达到目标时长
        float elapsedTime = _TransactionFact - startTime;
        int requiredSeconds = GourdHerculean[timerId] * 60;

        if (elapsedTime >= requiredSeconds)
        {
            // 达到目标时长，设置为可领取状态
            KeyVagueSawyer(timerId, ATimerStatus_A.Ready);
            return true;
        }

        return false;
    }
    /// <summary>
    /// 领取计时器奖励
    /// </summary>
    public void PeskyVagueCustom(int timerId)
    {
        if (timerId < 0 || timerId >= GourdHerculean.Length)
            return;

        ATimerStatus_A status = CopVagueSawyer(timerId);
        if (status != ATimerStatus_A.Ready)
            return; // 不可领取

        // 检查前一个是否已领取（必须按顺序领取）
        if (timerId > 0)
        {
            ATimerStatus_A prevStatus = CopVagueSawyer(timerId - 1);
            if (prevStatus != ATimerStatus_A.Completed)
            {
                return; // 前一个未领取，不能领取这个
            }
        }

        // 增加金币
        UtahHallWrapper.YewVocation().YewNeon(GourdCustom);

        // 更新状态为已领取
        KeyVagueSawyer(timerId, ATimerStatus_A.Completed);

        // 启动下一个计时器
        int nextTimerId = timerId + 1;
        if (nextTimerId < GourdHerculean.Length)
        {
            float nextStartTime = CopVagueThereFact(nextTimerId);
            if (nextStartTime < 0) // 如果下一个未启动
            {
                ThereVague(nextTimerId);
            }
        }

        Debug.Log($"计时器 {timerId} 领取成功，获得 {GourdCustom} 金币");
    }
    /// <summary>
    /// 获取计时器奖励金额
    /// </summary>
    public int CopVagueCustom()
    {
        return GourdCustom;
    }




    /// <summary>
    /// 刷新每日任务（重置所有任务状态和进度）
    /// </summary>
    private void CrustalValveForge()
    {
        // 四个任务：完成2、4、6、8关
        int[] WakePetiole = { 50, 100, 200, 300 };
        for (int i = 0; i < WakePetiole.Length; i++)
        {
            int taskId = i;
            KeyKilnSawyer(taskId, TaskStatus_B.Incomplete);
            KeyKilnExterior(taskId, 0);
        }
    }
    /// <summary>
    /// 设置任务状态
    /// </summary>
    public void KeyKilnSawyer(int taskId, TaskStatus_B status)
    {
        string key = CScream.KilnSawyer_B + taskId;
        PlayerPrefs.SetInt(key, (int)status);
    }

    /// <summary>
    /// 设置任务进度
    /// </summary>
    public void KeyKilnExterior(int taskId, int progress)
    {
        string key = CScream.KilnExterior_B + taskId;
        PlayerPrefs.SetInt(key, progress);
    }
    /// <summary>
    /// 检查并刷新每日任务
    /// </summary>
    public void ScrubDieCrustalValveForge()
    {
        string lastRefreshDate = PlayerPrefs.GetString(CScream.HugeKilnCrustalHall_B, "");
        string today = DateTime.Now.ToString("yyyy-MM-dd");

        if (lastRefreshDate != today)
        {
            // 新的一天，重置所有任务
            CrustalValveForge();
            PlayerPrefs.SetString(CScream.HugeKilnCrustalHall_B, today);
            // 重置今天完成的关卡数
            PlayerPrefs.SetInt(CScream.ClickBroadcastHamper_B, 0);
        }
    }
    /// <summary>
    /// 增加今天完成的关卡数
    /// </summary>
    private void PresidentClickBroadcastHamper()
    {
        ScrubDieCrustalValveForge(); // 确保日期检查
        int todayLevels = CopClickBroadcastHamper();
        todayLevels++;
        PlayerPrefs.SetInt(CScream.ClickBroadcastHamper_B, todayLevels);
    }
    /// <summary>
    /// 获取今天完成的关卡数
    /// </summary>
    public int CopClickBroadcastHamper()
    {
        ScrubDieCrustalValveForge(); // 确保日期检查
        return PlayerPrefs.GetInt(CScream.ClickBroadcastHamper_B, 0);
    }

    /// <summary>
    /// 更新任务进度（当关卡完成时调用）
    /// </summary>
    public void DefendKilnExterior()
    {
        ScrubDieCrustalValveForge();

        // 增加今天完成的关卡数
        PresidentClickBroadcastHamper();
        int todayCompletedLevels = CopClickBroadcastHamper();

        // 四个任务：完成2、4、6、8关
        int[] WakePetiole = { 50, 100, 200, 300 };
        for (int i = 0; i < WakePetiole.Length; i++)
        {
            int taskId = i;
            int target = WakePetiole[i];

            // 只更新未完成且未领取的任务
            TaskStatus_B status = CopKilnSawyer(taskId);
            if (status == TaskStatus_B.Incomplete || status == TaskStatus_B.Ready)
            {
                // 如果今天完成的关卡数达到目标，更新进度并设置为可领取状态
                if (todayCompletedLevels >= target)
                {
                    KeyKilnExterior(taskId, target);
                    if (status == TaskStatus_B.Incomplete)
                    {
                        KeyKilnSawyer(taskId, TaskStatus_B.Ready);
                    }
                }
                else
                {
                    // 更新当前进度
                    int currentProgress = Mathf.Min(todayCompletedLevels, target);
                    KeyKilnExterior(taskId, currentProgress);
                }
            }
        }
    }

    /// <summary>
    /// 获取任务进度
    /// </summary>
    public int CopKilnExterior(int taskId)
    {
        string key = CScream.KilnExterior_B + taskId;
        return PlayerPrefs.GetInt(key, 0);
    }
    /// <summary>
    /// 获取任务状态
    /// </summary>
    public TaskStatus_B CopKilnSawyer(int taskId)
    {
        string key = CScream.KilnSawyer_B + taskId;
        return (TaskStatus_B)PlayerPrefs.GetInt(key, (int)TaskStatus_B.Incomplete);
    }
}