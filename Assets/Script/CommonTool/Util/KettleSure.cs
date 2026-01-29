using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleSure
{
    [HideInInspector] public static string Cosmos_SurpassClaw; //归因渠道名称 由NetInfoMgr的CheckAdjustNetwork方法赋值
    static string Toil_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string DemiseKeelClaw= "pie"; //正常模式名称
    static string Intervene; //距离黑名单位置的距离 打点用
    static string Attire; //进审理由 打点用
    [HideInInspector] public static string SuckIcy= ""; //判断流程 打点用

    public static bool HeYield()
    {
        //测试
         //return true;
        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Toil_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Toil_AP)) //无本地存档 读取网络数据
            ScantAssistHall();

        if (Toil_AP != "P")
            return true;
        else
            return false;
    }

    static void ScantAssistHall() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Toil_AP = "P";
        if (MudHourJaw.instance.ScreamHall.apple_pie != DemiseKeelClaw) //审模式 
        {
            OtherChance = "YES";
            Toil_AP = "A";
            if (string.IsNullOrEmpty(Attire))
                Attire = "ApplePie";
        }
        SuckIcy = "0:" + Toil_AP;
        //判断地理位置
        if (!string.IsNullOrEmpty(MudHourJaw.instance.ScreamHall.LocationList) && MudHourJaw.instance.TiltHall != null)
        {
            //判断运营商信息
            if (MudHourJaw.instance.TiltHall.IsHaveApple)
            {
                Toil_AP = "A";
                if (string.IsNullOrEmpty(Attire))
                    Attire = "HaveApple";
            }
            SuckIcy += "  1:" + Toil_AP;
            //判断经纬度
            LocationData[] LocationDatas = LitJson.JsonMapper.ToObject<LocationData[]>(MudHourJaw.instance.ScreamHall.LocationList);
            if (LocationDatas != null && LocationDatas.Length > 0 && MudHourJaw.instance.TiltHall.lat != 0 && MudHourJaw.instance.TiltHall.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = YewMultiply((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)MudHourJaw.instance.TiltHall.lat, (float)MudHourJaw.instance.TiltHall.lon);
                    Intervene += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Toil_AP = "A";
                        if (string.IsNullOrEmpty(Attire))
                            Attire = "Location";
                        break;
                    }
                }
            }
            SuckIcy += "  2:" + Toil_AP;
            //判断城市
            string[] HeiCityList = LitJson.JsonMapper.ToObject<string[]>(MudHourJaw.instance.ScreamHall.HeiCity);
            if (!string.IsNullOrEmpty(MudHourJaw.instance.TiltHall.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == MudHourJaw.instance.TiltHall.regionName
                    || HeiCityList[i] == MudHourJaw.instance.TiltHall.city)
                    {
                        Toil_AP = "A";
                        if (string.IsNullOrEmpty(Attire))
                            Attire = "City";
                        break;
                    }
                }
            }
            SuckIcy += "  3:" + Toil_AP;
            //判断黑名单
            string[] HeiIPs = LitJson.JsonMapper.ToObject<string[]>(MudHourJaw.instance.ScreamHall.HeiNameList);
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(MudHourJaw.instance.TiltHall.query))
            {
                string[] IpNums = MudHourJaw.instance.TiltHall.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Toil_AP = "A";
                        if (string.IsNullOrEmpty(Attire))
                            Attire = "IP";
                        break;
                    }
                }
            }
            SuckIcy += "  4:" + Toil_AP;
        }
        SuckIcy += "  5:" + Toil_AP;
        //判断自然量
        if (!string.IsNullOrEmpty(MudHourJaw.instance.ScreamHall.fall_down))
        {
            if (MudHourJaw.instance.ScreamHall.fall_down == "bottom") //仅判断Organic
            {
                if (Cosmos_SurpassClaw == "Organic") //打开自然量 且 归因渠道是Organic 审模式
                {
                    Toil_AP = "A";
                    if (string.IsNullOrEmpty(Attire))
                        Attire = "FallDown";
                }
            }
            else if (MudHourJaw.instance.ScreamHall.fall_down == "down") //判断Organic + NoUserConsent
            {
                if (Cosmos_SurpassClaw == "Organic" || Cosmos_SurpassClaw == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
                {
                    Toil_AP = "A";
                    if (string.IsNullOrEmpty(Attire))
                        Attire = "FallDown";
                }
            }
        }
        SuckIcy += "  6:" + Toil_AP;

        PlayerPrefs.SetString("Save_AP", Toil_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);
        //打点
        if (!string.IsNullOrEmpty(ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo)))
            PoolBulge();


        //本地log
        Debug.Log("++++++判断流程： " + SuckIcy);
        if (MudHourJaw.instance.TiltHall != null)
        {
            string Hour= "游戏模式：" + (Toil_AP == "A" ? "审" : "正常")
                       + "\n进审理由：" + Attire
                       + "\n开关： " + MudHourJaw.instance.ScreamHall.apple_pie
                       + "\n是否包含苹果： " + MudHourJaw.instance.TiltHall.IsHaveApple
                       + "\n位置黑名单： " + MudHourJaw.instance.ScreamHall.LocationList?.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("[", "").Replace("]", "")
                       + "\n用户位置： " + MudHourJaw.instance.TiltHall.lat + "," + MudHourJaw.instance.TiltHall.lon
                       + "\n黑名单城市： " + MudHourJaw.instance.ScreamHall.HeiCity?.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("[", "").Replace("]", "")
                       + "\n用户城市: " + MudHourJaw.instance.TiltHall.regionName
                       + "\n与黑名单地点距离： " + Intervene
                       + "\nIP黑名单： " + MudHourJaw.instance.ScreamHall.HeiNameList?.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("[", "").Replace("]", "")
                       + "\n用户IP： " + MudHourJaw.instance.TiltHall.query
                       + "\n自然量开关： " + MudHourJaw.instance.ScreamHall.fall_down
                       + "\n归因渠道： " + Cosmos_SurpassClaw
                       + "\n接口返回信息： " + MudHourJaw.instance.TiltHallLap;
            Debug.Log("++++++" + Hour);
        }
    }
    static float YewMultiply(float lat1, float lon1, float lat2, float lon2)
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void PoolBulge()
    {
        //打点
        if (MudHourJaw.instance.TiltHall != null)
        {
            string Info1 = "[" + (Toil_AP == "A" ? "审" : "正常")
                                       + "] [" + Attire + "]";
            string Info2 = "[" + MudHourJaw.instance.TiltHall.lat + "," + MudHourJaw.instance.TiltHall.lon
                           + "] [" + MudHourJaw.instance.TiltHall.regionName
                           + "] [" + Intervene + "]";
            string Info3 = "[" + MudHourJaw.instance.TiltHall.query
                           + "] [" + Cosmos_SurpassClaw + "]";
            DaleBulgeScript.YewVocation().PoolBulge("3000", Info1, Info2, Info3);
        }
        else
            DaleBulgeScript.YewVocation().PoolBulge("3000", "No UserData");
        DaleBulgeScript.YewVocation().PoolBulge("3001", (Toil_AP == "A" ? "审" : "正常"), SuckIcy, MudHourJaw.instance.HallSort);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }

    public static bool HePointe()
    {
#if UNITY_EDITOR
        return true;
#else
            return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool HeOffering()
    {
        return Screen.height > Screen.width;
    }


}
