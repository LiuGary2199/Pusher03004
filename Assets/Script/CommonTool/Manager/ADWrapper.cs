using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.adjust.sdk;
using LitJson;

public class ADWrapper : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool WeCoil= false;
    public static ADWrapper Vocation{ get; private set; }

    private int SwampDiscuss;   // 广告加载失败后，重新加载广告次数
    private bool WeAnxiousMy;     // 是否正在播放广告，用于判断切换前后台时是否增加计数

    public int WindBillFastDynasty{ get; private set; }   // 距离上次广告的时间间隔
    public int Liberty101{ get; private set; }     // 定时插屏(101)计数器
    public int Liberty102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Liberty103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string SierraPredateClaw;
    private Action<bool> SierraKierRearEnough;    // 激励视频回调
    private bool SierraSlander;     // 激励视频是否成功收到奖励
    private string SierraPeart;     // 激励视频的打点

    private string FruitfulnessPredateClaw;
    private int FruitfulnessFist;      // 当前播放的插屏类型，101/102/103
    private string FruitfulnessPeart;     // 插屏广告的的打点
    public bool WearyFastHelplessness{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> ItOverrunInterlock;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long GeometricalDecayExcursion;     // 切后台时的时间戳
    private Ad_CustomData SunlitMyRarityHall; //激励视频自定义数据
    private Ad_CustomData HelplessnessMyRarityHall; //插屏自定义数据

    private void Awake()
    {
        Vocation = this;
    }

    private void OnEnable()
    {
        WearyFastHelplessness = false;
        WeAnxiousMy = false;
        WindBillFastDynasty = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        SierraSlander = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
#if UNITY_ANDROID
        MaxSdk.SetSdkKey(YewMortarHall.DecryptDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = ToilHallWrapper.GetString(CScream.sv_AdjustAdid);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            ToilHallWrapper.SetString(CScream.sv_AdjustAdid, adjustId);
        }
        else
        {
            StartCoroutine(setAdjustAdid());
        }
#else
        MaxSdk.SetSdkKey(YewMortarHall.UnaidedDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(ToilHallWrapper.YewCarpet(CScream.If_GrapeUserGo));
        MaxSdk.InitializeSdk();
#endif

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            PowerfullyAppetiteRoe();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(WanderOption), 1, 1);
        };
    }

    IEnumerator LopCosmosEdge()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (KettleSure.HePointe())
            {
                MaxSdk.SetUserId(ToilHallWrapper.YewCarpet(CScream.If_GrapeUserGo));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                string adjustId = Adjust.getAdid();
                if (!string.IsNullOrEmpty(adjustId))
                {
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    ToilHallWrapper.HubCarpet(CScream.If_CosmosEdge, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(ToilHallWrapper.YewCarpet(CScream.If_GrapeUserGo));
            MaxSdk.InitializeSdk();
        }
    }

    public void PowerfullyAppetiteRoe()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        FeelAppetiteMy();

        // Load the first interstitial
        FeelHelplessness();
    }

    private void FeelAppetiteMy()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void FeelHelplessness()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        SwampDiscuss = 0;
        SierraPredateClaw = adInfo.NetworkName;

        SunlitMyRarityHall = new Ad_CustomData();
        SunlitMyRarityHall.user_id = CashOutManager.YewVocation().Data.UserID;
        SunlitMyRarityHall.version = Application.version;
        SunlitMyRarityHall.request_id = CashOutManager.YewVocation().EcpmRequestID();
        SunlitMyRarityHall.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        SwampDiscuss++;
        double retryDelay = Math.Pow(2, Math.Min(6, SwampDiscuss));

        Invoke(nameof(FeelAppetiteMy), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        OfferJaw.YewVocation().ByOfferRelate = !OfferJaw.YewVocation().ByOfferRelate;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        FeelAppetiteMy();
        WeAnxiousMy = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        OfferJaw.YewVocation().ByOfferRelate = !OfferJaw.YewVocation().ByOfferRelate;
#endif

        WeAnxiousMy = false;
        FeelAppetiteMy();
        if (SierraSlander)
        {
            SierraSlander = false;
            SierraKierRearEnough?.Invoke(true);

            AnvilMyBillSlander(ADType.Rewarded);
            DaleBulgeScript.YewVocation().PoolBulge("9007", SierraPeart);
        }
        else
        {
            SierraKierRearEnough?.Invoke(false);
        }

        // 上报ecpm
        CashOutManager.YewVocation().ReportEcpm(adInfo, SunlitMyRarityHall.request_id, "REWARD");
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        SierraSlander = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        DaleBulgeScript.YewVocation().PoolBulge("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //CosmosTireWrapper.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        string adjustAdid = CosmosTireWrapper.Instance.YewCosmosEdge();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        SwampDiscuss = 0;
        FruitfulnessPredateClaw = adInfo.NetworkName;

        HelplessnessMyRarityHall = new Ad_CustomData();
        HelplessnessMyRarityHall.user_id = CashOutManager.YewVocation().Data.UserID;
        HelplessnessMyRarityHall.version = Application.version;
        HelplessnessMyRarityHall.request_id = CashOutManager.YewVocation().EcpmRequestID();
        HelplessnessMyRarityHall.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        SwampDiscuss++;
        double retryDelay = Math.Pow(2, Math.Min(6, SwampDiscuss));

        Invoke(nameof(FeelHelplessness), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        OfferJaw.YewVocation().ByOfferRelate = !OfferJaw.YewVocation().ByOfferRelate;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        FeelHelplessness();
        WeAnxiousMy = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        DaleBulgeScript.YewVocation().PoolBulge("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //CosmosTireWrapper.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(CosmosTireWrapper.Instance.YewCosmosEdge()))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = CosmosTireWrapper.Instance.YewCosmosEdge();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        OfferJaw.YewVocation().ByOfferRelate = !OfferJaw.YewVocation().ByOfferRelate;
#endif
        FeelHelplessness();

        AnvilMyBillSlander(ADType.Interstitial);
        DaleBulgeScript.YewVocation().PoolBulge("9107", FruitfulnessPeart);
        // 上报ecpm
        CashOutManager.YewVocation().ReportEcpm(adInfo, HelplessnessMyRarityHall.request_id, "INTER");
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void DeepSunlitBleak(Action<bool> callBack, string index)
    {
        if (WeCoil)
        {
            callBack(true);
            AnvilMyBillSlander(ADType.Rewarded);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        SierraKierRearEnough = callBack;
        if (rewardVideoReady)
        {
            // 打点
            SierraPeart = index;
            DaleBulgeScript.YewVocation().PoolBulge("9002", index);
            WeAnxiousMy = true;
            SierraSlander = false;
            string placement = index + "_" + SierraPredateClaw;
            SunlitMyRarityHall.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(SunlitMyRarityHall));
        }
        else
        {
            CedarWrapper.YewVocation().SinkCedar("No ads right now, please try it later.");
            SierraKierRearEnough(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void DeepHelplessnessMy(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        DeepHelplessness(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void DeepHelplessness(int index, int customIndex = 0)
    {
        FruitfulnessFist = index;

        if (WeAnxiousMy)
        {
            return;
        }

        //这个参数很少有游戏会用 需要的时候自己再打开
        // 当用户过关数 < trial_MaxNum时，不弹插屏广告
        // int sv_trialNum = ToilHallWrapper.GetInt(CScream.sv_ad_trial_num);
        // int trial_MaxNum = int.Parse(MudHourJaw.instance.ConfigData.trial_MaxNum);
        // if (sv_trialNum < trial_MaxNum)
        // {
        //     return;
        // }

        // 时间间隔低于阈值，不播放广告
        if (WindBillFastDynasty < int.Parse(MudHourJaw.instance.ScreamHall.inter_freq))
        {
            return;
        }

        if (WeCoil)
        {
            AnvilMyBillSlander(ADType.Interstitial);
            return;
        }

        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            WeAnxiousMy = true;
            // 打点
            string point = index.ToString();
            if (customIndex > 0)
            {
                point += customIndex.ToString().PadLeft(2, '0');
            }
            FruitfulnessPeart = point;
            DaleBulgeScript.YewVocation().PoolBulge("9102", point);
            string placement = point + "_" + FruitfulnessPredateClaw;
            HelplessnessMyRarityHall.placement_id = placement;
            MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(HelplessnessMyRarityHall));
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void WanderOption()
    {
        WindBillFastDynasty++;

        int relax_interval = int.Parse(MudHourJaw.instance.ScreamHall.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || WeAnxiousMy)
        {
            return;
        }
        else
        {
            Liberty101++;
            if (Liberty101 >= relax_interval && !WearyFastHelplessness)
            {
                DeepHelplessness(101);
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void WeLaunchYewPupil(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(MudHourJaw.instance.ScreamHall.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Liberty102 = ToilHallWrapper.YewSow("NoThanksCount") + 1;
            ToilHallWrapper.HubSow("NoThanksCount", Liberty102);
            if (Liberty102 >= nextlevel_interval)
            {
                DeepHelplessness(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!WeAnxiousMy)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (GeometricalDecayExcursion > 0)
                {
                    WindBillFastDynasty += (int)(PorkSure.Ghostly() - GeometricalDecayExcursion);
                    GeometricalDecayExcursion = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(MudHourJaw.instance.ScreamHall.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Liberty103++;
                    if (Liberty103 >= inter_b2f_count)
                    {
                        DeepHelplessness(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            GeometricalDecayExcursion = PorkSure.Ghostly();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void DecayFastHelplessness()
    {
        WearyFastHelplessness = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void InventFastHelplessness()
    {
        WearyFastHelplessness = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void VirtueLooseBed(int num)
    {
        ToilHallWrapper.HubSow(CScream.If_It_trial_Fox, num);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void MagneticBillGravitas(Action<ADType> callback)
    {
        if (ItOverrunInterlock == null)
        {
            ItOverrunInterlock = new List<Action<ADType>>();
        }

        if (!ItOverrunInterlock.Contains(callback))
        {
            ItOverrunInterlock.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void AnvilMyBillSlander(ADType adType)
    {
        WeAnxiousMy = false;
        // 播放间隔计数器清零
        WindBillFastDynasty = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (FruitfulnessFist == 101)
            {
                Liberty101 = 0;
            }
            else if (FruitfulnessFist == 102)
            {
                Liberty102 = 0;
                ToilHallWrapper.HubSow("NoThanksCount", 0);
            }
            else if (FruitfulnessFist == 103)
            {
                Liberty103 = 0;
            }
        }

        // 看广告总数+1
        ToilHallWrapper.HubSow(CScream.If_Dutch_It_Fox + adType.ToString(), ToilHallWrapper.YewSow(CScream.If_Dutch_It_Fox + adType.ToString()) + 1);
        // 真提现任务 
        if (adType == ADType.Rewarded)
            CashOutManager.YewVocation().AddTaskValue("Ad",1);

        // 回调
        if (ItOverrunInterlock != null && ItOverrunInterlock.Count > 0)
        {
            foreach (Action<ADType> callback in ItOverrunInterlock)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int YewAgreeMyBed(ADType adType)
    {
        return ToilHallWrapper.YewSow(CScream.If_Dutch_It_Fox + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}