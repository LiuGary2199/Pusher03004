/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using com.adjust.sdk;
//using MoreMountains.NiceVibrations;

public class MudHourJaw : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("CashOut_Data")]    public CashOutData SuchWay_Hall; //提现相关后台数据
    public static MudHourJaw instance;
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("BaseUrl")]    //base
    public string LastSum;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string LastGrantSum;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string LastScreamSum;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string LastFastSum;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string LastCosmosSum;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string UtahTone= "20000";
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string HallSort; //数据来源 打点用
[UnityEngine.Serialization.FormerlySerializedAs("Channel")]    //channel渠道平台
#if UNITY_IOS
    public string Legally= "iOS";
#elif UNITY_ANDROID
    public string Channel = "GooglePlay";
#else
    public string Channel = "Other";
#endif
    //工程包名
    private string ServantClaw{ get { return Application.identifier; } }
    //登录url
    private string GrantSum= "";
    //配置url
    private string ScreamSum= "";
    //更新AdjustId url
    private string CosmosSum= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Restore= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public ServerData ScreamHall;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init TireHall;
[UnityEngine.Serialization.FormerlySerializedAs("GameData")]    
    public GameData UtahHall;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    
    //ADWrapper
    public GameObject ItWrapper;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Hiss;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Ere;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Tray;
    int Study_Giant= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    public bool Study= false;

   public double[] Exchange = new double[] { 0,0};
    //ios 获取idfa函数声明
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void getIDFA();
#endif
    void Awake()
    {
        instance = this;
        GrantSum = LastGrantSum + UtahTone + "&channel=" + Legally + "&version=" + Application.version;
        ScreamSum = LastScreamSum + UtahTone + "&channel=" + Legally + "&version=" + Application.version;
        CosmosSum = LastCosmosSum + UtahTone;
    }
    private void Start()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            ToilHallWrapper.HubCarpet("idfv", idfv);
#endif
        }
        else
        {
            Grant();           //编辑器登录
        }
        //获取config数据
        YewScreamHall();
        CashOutManager.YewVocation().Login();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void gaidAction(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Hiss = gaid_str; 
        if (Hiss == null || Hiss == "")
        {
            Hiss = ToilHallWrapper.YewCarpet("gaid");
        }
        else
        {
            ToilHallWrapper.HubCarpet("gaid", Hiss);
        }
        Study_Giant++;
        if (Study_Giant == 2)
        {
            Grant();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void aidAction(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Ere = aid_str;
        if (Ere == null || Ere == "")
        {
            Ere = ToilHallWrapper.YewCarpet("aid");
        }
        else
        {
            ToilHallWrapper.HubCarpet("aid", Ere);
        }
        Study_Giant++;
        if (Study_Giant == 2)
        {
            Grant();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void idfaSuccess(string message)
    {
        Debug.Log("idfa success:" + message);
        Tray = message;
        ToilHallWrapper.HubCarpet("idfa", Tray);
        Grant();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void idfaFail(string message)
    {
        Debug.Log("idfa fail");
        Tray = ToilHallWrapper.YewCarpet("idfa");
        Grant();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Grant()
    {
        //提现登录
        CashOutManager.YewVocation().Login();
        //获取本地缓存的Local用户ID
        string localId = ToilHallWrapper.YewCarpet(CScream.If_GrapeUserGo);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            ToilHallWrapper.HubCarpet(CScream.If_GrapeUserGo, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = GrantSum + "&" + "randomKey" + "=" + localId + "&idfa=" + Tray + "&packageName=" + ServantClaw;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = GrantSum + "&" + "randomKey" + "=" + localId + "&gaid=" + Hiss + "&androidId=" + Ere + "&packageName=" + ServantClaw;
        }
        else //编辑器
        {
            url = GrantSum + "&" + "randomKey" + "=" + localId + "&packageName=" + ServantClaw;
        }

        //获取国家信息
        EraCertain(() => {
            url += "&country=" + Restore;
            //登录请求
            MudFailWrapper.YewVocation().KillYew(url,
                (data) => {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    ToilHallWrapper.HubCarpet("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    ToilHallWrapper.HubCarpet(CScream.If_GrapeSourceGo, serverUserData.data.ToString());

                    PoolCosmosEdge();
                    if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(KettleSure.SuckIcy))
                        KettleSure.PoolBulge();

                },
                () => {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void EraCertain(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Restore))
        {
            ////获取国家超时返回
            //StartCoroutine(NetWorkTimeOut(() =>
            //{
            //    if (!callBackReady)
            //    {
            //        country = "";
            //        callBackReady = true;
            //        cb?.Invoke();
            //    }
            //}));
            MudFailWrapper.YewVocation().KillYew("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Restore = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Restore);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
            },
            () => {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Restore = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void YewScreamHall()
    {
        Debug.Log("GetConfigData:" + ScreamSum);
        //StartCoroutine(NetWorkTimeOut(() =>
        //{
        //    GetLoactionData();
        //}));

        //获取并存入Config
        MudFailWrapper.YewVocation().KillYew(ScreamSum,
        (data) => {
            HallSort = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            ToilHallWrapper.HubCarpet("OnlineData", data.downloadHandler.text);
            HubScreamHall(data.downloadHandler.text);
        },
        () => {
            YewHandmadeHall();
            Debug.Log("ConfigData 失败");
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void YewHandmadeHall()
    {
        //是否有缓存
        if (ToilHallWrapper.YewCarpet("OnlineData") == "" || ToilHallWrapper.YewCarpet("OnlineData").Length == 0)
        {
            HallSort = "LocalData_Updated"; //已联网更新过的数据
            Debug.Log("本地数据");
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            HubScreamHall(json.text);
        }
        else
        {
            HallSort = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            HubScreamHall(ToilHallWrapper.YewCarpet("OnlineData"));
        }
    }


    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void HubScreamHall(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (ScreamHall == null)
        {
            
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            ScreamHall = rootData.data;
            if (!string.IsNullOrEmpty(ScreamHall.CashOut_Data))
                SuchWay_Hall = JsonMapper.ToObject<CashOutData>(ScreamHall.CashOut_Data);
            switch (ToilHallWrapper.YewCarpet(CScream.Pig_Masthead))
            {
                case "Russian":
                    TireHall = JsonMapper.ToObject<Init>(ScreamHall.init_ru);
                    UtahHall = JsonMapper.ToObject<GameData>(ScreamHall.game_data_ru);
                    break;
                case "Portuguese (Brazil)":
                    TireHall = JsonMapper.ToObject<Init>(ScreamHall.init_br);
                    UtahHall = JsonMapper.ToObject<GameData>(ScreamHall.game_data_br);
                    break;
                case "English":
                    TireHall = JsonMapper.ToObject<Init>(ScreamHall.init_us);
                    UtahHall = JsonMapper.ToObject<GameData>(ScreamHall.game_data_us);
                    break;
                case "Japanese":
                    TireHall = JsonMapper.ToObject<Init>(ScreamHall.init_jp);
                    UtahHall = JsonMapper.ToObject<GameData>(ScreamHall.game_data_jp);
                    break;
                default:
                    TireHall = JsonMapper.ToObject<Init>(ScreamHall.init);
                    UtahHall = JsonMapper.ToObject<GameData>(ScreamHall.game_data);
                    break;
            }
   
            TireHall.cash_group_real = new MultiGroup[TireHall.cash_group.Length];
            for (int i = 0; i < TireHall.cash_group.Length; i++)
            {
                MultiGroup multiGroup = new MultiGroup();
                multiGroup.max = TireHall.cash_group[i].max;
                multiGroup.multi = double.Parse(TireHall.cash_group[i].multi);
                multiGroup.weight_multi = TireHall.cash_group[i].weight_multi;
                TireHall.cash_group_real[i] = multiGroup;
            }

            if (!string.IsNullOrEmpty(ScreamHall.Exchange))
                Exchange = JsonMapper.ToObject<double[]>(ScreamHall.Exchange);

            YewTiltHour();
            if (!PlayerPrefs.HasKey(CScream.Pig_BuySH))
            {
                if (ScreamHall.apple_pie != "apple")
                {
                    Debug.Log("sys_AppSH_______________Pass");
                    PlayerPrefs.SetInt(CScream.Pig_BuySH, 1);
                }
            }
        }
        // if (ConfigData == null)
        // {
        //     RootData rootData = JsonMapper.ToObject<RootData>(configJson);
        //     ConfigData = rootData.data;
        //     InitData = JsonMapper.ToObject<Init>(ConfigData.init);
        //     GameData = JsonMapper.ToObject<GameData>(ConfigData.game_data);
        //     GetUserInfo();
        // }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void UtahXenon()
    {
        //打开admanager
        // adManager.SetActive(true);
        //进度条可以继续
        Study = true;
    }



    /// <summary>
    /// 超时处理
    /// </summary>
    /// <param name="finish"></param>
    /// <returns></returns>
    IEnumerator MudFailFastWay(Action finish)
    {
        yield return new WaitForSeconds(TIMEOUT);
        finish();
    }

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void PoolCosmosEdge()
    {
        string serverId = ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo);
        string adjustId = CosmosTireWrapper.Instance.YewCosmosEdge();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = CosmosSum + "&serverId=" + serverId + "&adid=" + adjustId;
        MudFailWrapper.YewVocation().KillYew(url,
            (data) => {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () => {
                Debug.Log("服务器更新adjust adid 失败");
            });
        CashOutManager.YewVocation().ReportAdjustID();
    }
    //轮询检查Adjust归因信息
    int ScantPupil= 0;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("Event_TrackerName")]public string Bulge_SurpassClaw; //打点用参数
    bool _ScantAx= false;
    [HideInInspector]
    public bool CosmosSurpass_Xenon    {
        get
        {
            if (Application.isEditor) //编译器跳过检查
                return true;
            return _ScantAx;
        }
    }
    public void ScantCosmosPredate() //检查Adjust归因信息
    {
        if (Application.isEditor) //编译器跳过检查
            return;
        if (!string.IsNullOrEmpty(Bulge_SurpassClaw)) //已经拿到归因信息
            return;

        CancelInvoke(nameof(ScantCosmosPredate));
        if (!string.IsNullOrEmpty(ScreamHall.fall_down) && ScreamHall.fall_down == "fall")
        {
            print("Adjust 无归因相关配置或未联网 跳过检查");
            _ScantAx = true;
        }
        try
        {
            AdjustAttribution Hour= Adjust.getAttribution();
            print("Adjust 获取信息成功 归因渠道：" + Hour.trackerName);
            Bulge_SurpassClaw = "TrackerName: " + Hour.trackerName;
            KettleSure.Cosmos_SurpassClaw = Hour.trackerName;
            _ScantAx = true;
        }
        catch (System.Exception e)
        {
            ScantPupil++;
            Debug.Log("Adjust 获取信息失败：" + e.Message + " 重试次数：" + ScantPupil);
            if (ScantPupil >= 10)
                _ScantAx = true;
            Invoke(nameof(ScantCosmosPredate), 1);
        }
    }
[UnityEngine.Serialization.FormerlySerializedAs("UserDataStr")]
    //获取用户信息
    public string TiltHallLap= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData TiltHall;
    int YewTiltHourPupil= 0;
    void YewTiltHour()
    {
        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES")
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            UtahXenon();
            return;
        }

        //检查归因渠道信息
        ScantCosmosPredate();
        //获取用户信息
        string CheckUrl = LastSum + "/api/client/user/checkUser";
        MudFailWrapper.YewVocation().KillYew(CheckUrl,
        (data) =>
        {
            TiltHallLap = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + TiltHallLap);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(TiltHallLap);
            TiltHall = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (TiltHallLap.Contains("apple")
            || TiltHallLap.Contains("Apple")
            || TiltHallLap.Contains("APPLE"))
                TiltHall.IsHaveApple = true;
            UtahXenon();
        }, () => { });
        Invoke(nameof(MeYewTiltHour), 1);
    }
    void MeYewTiltHour()
    {
        if (!Study)
        {
            YewTiltHourPupil++;
            if (YewTiltHourPupil < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + YewTiltHourPupil);
                YewTiltHour();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                UtahXenon();
            }
        }
    }

}
