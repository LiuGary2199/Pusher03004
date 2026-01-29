using System;
using System.Collections;
using com.adjust.sdk;
using UnityEngine;
using Random = UnityEngine.Random;

public class CosmosTireWrapper : MonoBehaviour
{
    public static CosmosTireWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string VoyageID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string If_ADGoalTireFist= "sv_ADJustInitType";

    //adjust 时间戳
    private string If_ADGoalFast= "sv_ADJustTime";

    //adjust行为计数器
    public int _SurmisePupil{ get; private set; }


    private void Awake()
    {
        Instance = this;
        ToilHallWrapper.HubCarpet(If_ADGoalFast, PorkSure.Ghostly().ToString());

#if UNITY_IOS
        ToilHallWrapper.HubCarpet(If_ADGoalTireFist, AdjustStatus.OpenAsAct.ToString());
        CosmosTire();
#endif
    }

    private void Start()
    {
        _SurmisePupil = 0;
    }


    void CosmosTire()
    {
        AdjustConfig adjustConfig = new AdjustConfig(VoyageID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        adjustConfig.setEventBufferingEnabled(false);
        adjustConfig.setLaunchDeferredDeeplink(true);
        Adjust.start(adjustConfig);

        StartCoroutine(ToilCosmosEdge());
    }

    private IEnumerator ToilCosmosEdge()
    {
        while (true)
        {
            string adjustAdid = Adjust.getAdid();
            if (string.IsNullOrEmpty(adjustAdid))
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                ToilHallWrapper.HubCarpet(CScream.If_CosmosEdge, adjustAdid);
                MudHourJaw.instance.PoolCosmosEdge();
                yield break;
            }
        }
    }

    public string YewCosmosEdge()
    {
        return ToilHallWrapper.YewCarpet(CScream.If_CosmosEdge);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string YewCosmosExport()
    {
        return ToilHallWrapper.YewCarpet(If_ADGoalTireFist);
    }

    /*
     *  API
     *  标记老用户
     */
    public void LysTiltHub()
    {
        
        print("old user add adjust status");
        ToilHallWrapper.HubCarpet(If_ADGoalTireFist, AdjustStatus.OldUser.ToString());
        DaleBulgeScript.YewVocation().PoolBulge("1093", YewCosmosFast());
    }


    /*
     *  API
     *  Adjust 初始化
     */
    public void TireCosmosHall(bool isOldUser = false)
    {
        #if UNITY_IOS
            return;
        #endif
        if (ToilHallWrapper.YewCarpet(If_ADGoalTireFist) == "" && isOldUser)
        {
            LysTiltHub();
        }
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(MudHourJaw.instance.ScreamHall.adjust_init_act_position) || int.Parse(MudHourJaw.instance.ScreamHall.adjust_init_act_position) <= 0)
        {
            ToilHallWrapper.HubCarpet(If_ADGoalTireFist, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + ToilHallWrapper.YewCarpet(If_ADGoalTireFist));
        //用户二次登录 根据标签初始化
        if (ToilHallWrapper.YewCarpet(If_ADGoalTireFist) == AdjustStatus.OldUser.ToString() || ToilHallWrapper.YewCarpet(If_ADGoalTireFist) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            CosmosTire();
        }
    }



    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void YewAilPupil(string param2 = "")
    {
#if UNITY_IOS
            return;
#endif
        if (ToilHallWrapper.YewCarpet(If_ADGoalTireFist) != "") return;
        _SurmisePupil++;
        print(" add up to :" + _SurmisePupil);
        if (string.IsNullOrEmpty(MudHourJaw.instance.ScreamHall.adjust_init_act_position) || _SurmisePupil == int.Parse(MudHourJaw.instance.ScreamHall.adjust_init_act_position))
        {
            FeelCosmosHeAil(param2);
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void FeelCosmosHeAil(string param2 = "")
    {
        if (ToilHallWrapper.YewCarpet(If_ADGoalTireFist) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(MudHourJaw.instance.ScreamHall.adjust_init_rate_act) || int.Parse(MudHourJaw.instance.ScreamHall.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            ToilHallWrapper.HubCarpet(If_ADGoalTireFist, AdjustStatus.OpenAsAct.ToString());
            CosmosTire();

            // 上报点位 新用户达成 且 初始化
            DaleBulgeScript.YewVocation().PoolBulge("1091", YewCosmosFast(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            ToilHallWrapper.HubCarpet(If_ADGoalTireFist, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            DaleBulgeScript.YewVocation().PoolBulge("1092", YewCosmosFast(), param2);
        }
    }

    
    /*
     * API
     *  重置当前次数
     */
    public void NylonAilPupil()
    {
        print("clear current ");
        _SurmisePupil = 0;
    }


    // 获取启动时间
    private string YewCosmosFast()
    {
        return PorkSure.Ghostly() - long.Parse(ToilHallWrapper.YewCarpet(If_ADGoalFast)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}