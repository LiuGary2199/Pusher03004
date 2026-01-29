/*
*
*   功能：整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能。  
*           功能1：关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
*                 入栈状态：
*                     Freeze();   （上一个UI窗体）冻结
*                     Display();  （本UI窗体）显示
*                 出栈状态： 
*                     Hiding();    (本UI窗体) 隐藏
*                     Redisplay(); (上一个UI窗体) 重新显示
*          功能2：增加“非栈”缓存集合。 
* 
* 
* ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// 主要负责UI窗体的加载、缓存、以及对于“UI窗体基类”的各种生命周期的操作（显示、隐藏、重新显示、冻结）。
/// </summary>
public class UIManager : MonoBehaviour
{
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("MainCanvas")]    public Canvas BeauChurch;
    private static UIManager _Vocation= null;
    //ui窗体预设路径（参数1，窗体预设名称，2，表示窗体预设路径）
    private Dictionary<string, string> _LogTruckSandy;
    //缓存所有的ui窗体
    private Dictionary<string, LastUITruck> _LogALLUITruck;
    //栈结构标识当前ui窗体的集合
    private Stack<LastUITruck> _DigGhostlyUITruck;
    //当前显示的ui窗体
    private Dictionary<string, LastUITruck> _LogGhostlySinkUITruck;
    //临时关闭窗口
    private List<string> _IronUITruck;
    //ui根节点
    private Transform _KeaChurchChildhood= null;
    //全屏幕显示的节点
    private Transform _KeaDemise= null;
    //固定显示的节点
    private Transform _KeaWeave= null;
    //弹出节点
    private Transform _KeaPaySo= null;
    //ui特效节点
    private Transform _Mob= null;
    //ui管理脚本的节点
    private Transform _KeaUIDrapery= null;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("PanelName")]    public string ScoreClaw;
    List<string> ScoreClawGerm;
    public List<string> IronUITruck    {
        get
        {
            return _IronUITruck;
        }
    }
    //得到实例
    public static UIManager YewVocation()
    {
        if (_Vocation == null)
        {
            _Vocation = new GameObject("_UIManager").AddComponent<UIManager>();
            
        }
        return _Vocation;
    }
    //初始化核心数据，加载ui窗体路径到集合中
    public void Awake()
    {
        ScoreClawGerm = new List<string>();
        //字段初始化
        _LogALLUITruck = new Dictionary<string, LastUITruck>();
        _LogGhostlySinkUITruck = new Dictionary<string, LastUITruck>();
        _IronUITruck = new List<string>();
        _LogTruckSandy = new Dictionary<string, string>();
        _DigGhostlyUITruck = new Stack<LastUITruck>();
        //初始化加载（根ui窗体）canvas预设
        TireDukeChurchCompost();
        //得到UI根节点，全屏节点，固定节点，弹出节点
        //Debug.Log("this.gameobject" + this.gameObject.name);
        _KeaChurchChildhood = GameObject.FindGameObjectWithTag(SheDefine.SYS_TAG_CANVAS).transform;
        _KeaDemise = SinceCanyon.WickRobChildYork(_KeaChurchChildhood.gameObject,SheDefine.SYS_NORMAL_NODE);
        _KeaWeave = SinceCanyon.WickRobChildYork(_KeaChurchChildhood.gameObject, SheDefine.SYS_FIXED_NODE);
        _KeaPaySo = SinceCanyon.WickRobChildYork(_KeaChurchChildhood.gameObject,SheDefine.SYS_POPUP_NODE);
        _Mob = SinceCanyon.WickRobChildYork(_KeaChurchChildhood.gameObject, SheDefine.SYS_TOP_NODE);
        _KeaUIDrapery = SinceCanyon.WickRobChildYork(_KeaChurchChildhood.gameObject,SheDefine.SYS_SCRIPTMANAGER_NODE);
        //把本脚本作为“根ui窗体”的子节点
        SinceCanyon.YewScopeYorkMeQuenchYork(_KeaUIDrapery, this.gameObject.transform);
        //根UI窗体在场景转换的时候，不允许销毁
        DontDestroyOnLoad(_KeaChurchChildhood);
        //初始化ui窗体预设路径数据
        TireUITruckSandyHall();
    }
    private void YewScore(string name)
    {
        if (!ScoreClawGerm.Contains(name))
        {
            ScoreClawGerm.Add(name);
            ScoreClaw = name;
        }
    }
    private void RayScore(string name)
    {
        if (ScoreClawGerm.Contains(name))
        {
            ScoreClawGerm.Remove(name);
        }
        if (ScoreClawGerm.Count == 0)
        {
            ScoreClaw = "";
        }
        else
        {
            ScoreClaw = ScoreClawGerm[0];
        }
    }
    //初始化加载（根ui窗体）canvas预设
    private void TireDukeChurchCompost()
    {
        BeauChurch = RoutinelyJaw.YewVocation().FeelAsset(SheDefine.SYS_PATH_CANVAS, false).GetComponent<Canvas>();
    }
    /// <summary>
    /// 显示ui窗体
    /// 功能：1根据ui窗体的名称，加载到所有ui窗体缓存集合中
    /// 2,根据不同的ui窗体的显示模式，分别做不同的加载处理
    /// </summary>
    /// <param name="uiFormName">ui窗体预设的名称</param>
    public GameObject SinkUITruck(string uiFormName)
    {
        //参数的检查
        if (string.IsNullOrEmpty(uiFormName)) return null;
        //根据ui窗体的名称，把加载到所有ui窗体缓存集合中
        //ui窗体的基类
        LastUITruck baseUIForms = FeelTruckMeALLUITruckMeter(uiFormName);
        if (baseUIForms == null) return null;

        YewScore(uiFormName);
        
        //判断是否清空“栈”结构体集合
        if (baseUIForms.GhostlyUIFist.HeRomanBiologyBaltic)
        {
            RomanUncleDense();
        }
        //根据不同的ui窗体的显示模式，分别做不同的加载处理
        switch (baseUIForms.GhostlyUIFist.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                MetalUITruckPlain(uiFormName);
                break;
            case UIFormShowMode.ReverseChange:
                JuryUITruck(uiFormName);
                break;
            case UIFormShowMode.HideOther:
                MetalUIRadiumMePlainWeakOther(uiFormName);
                break;
            case UIFormShowMode.Wait:
                MetalUITruckPlainIronPiano(uiFormName);
                break;
            default:
                break;
        }
        return baseUIForms.gameObject;
    }

    /// <summary>
    /// 关闭或返回上一个ui窗体（关闭当前ui窗体）
    /// </summary>
    /// <param name="strUIFormsName"></param>
    public void PianoOrCampusUITruck(string strUIFormsName)
    {
        RayScore(strUIFormsName);
        //Debug.Log("关闭窗体的名字是" + strUIFormsName);
        //ui窗体的基类
        LastUITruck baseUIForms = null;
        if (string.IsNullOrEmpty(strUIFormsName)) return;
        _LogALLUITruck.TryGetValue(strUIFormsName,out baseUIForms);
        //所有窗体缓存中没有记录，则直接返回
        if (baseUIForms == null) return;
        //判断不同的窗体显示模式，分别处理
        switch (baseUIForms.GhostlyUIFist.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                MuleUITruckPlain(strUIFormsName);
                break;
            
            case UIFormShowMode.ReverseChange:
                PayUITruck();
                break;
            case UIFormShowMode.HideOther:
                MuleUITruckSortPlainRimSinkBleak(strUIFormsName);
                break;
            case UIFormShowMode.Wait:
                MuleUITruckPlain(strUIFormsName);
                break;
            default:
                break;
        }
        
    }
    /// <summary>
    /// 显示下一个弹窗如果有的话
    /// </summary>
    public void SinkCardPaySo()
    {
        if (_IronUITruck.Count > 0)
        {
            SinkUITruck(_IronUITruck[0]);
            _IronUITruck.RemoveAt(0);
        }
    }

    /// <summary>
    /// 清空当前等待中的UI
    /// </summary>
    public void RomanIronUITruck()
    {
        if (_IronUITruck.Count > 0)
        {
            _IronUITruck = new List<string>();
        }
    }
     /// <summary>
     /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
      /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
      /// </summary>
      /// <param name="uiFormsName">UI窗体（预设）的名称</param>
      /// <returns></returns>
    private LastUITruck FeelTruckMeALLUITruckMeter(string uiFormName)
    {
        //加载的返回ui窗体基类
        LastUITruck baseUIResult = null;
        _LogALLUITruck.TryGetValue(uiFormName, out baseUIResult);
        if (baseUIResult == null)
        {
            //加载指定名称ui窗体
            baseUIResult = FeelUIArid(uiFormName);

        }
        return baseUIResult;
    }
    /// <summary>
    /// 加载指定名称的“UI窗体”
    /// 功能：
    ///    1：根据“UI窗体名称”，加载预设克隆体。
    ///    2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点。
    ///    3：隐藏刚创建的UI克隆体。
    ///    4：把克隆体，加入到“所有UI窗体”（缓存）集合中。
    /// 
    /// </summary>
    /// <param name="uiFormName">UI窗体名称</param>
    private LastUITruck FeelUIArid(string uiFormName)
    {
        string strUIFormPaths = null;
        GameObject goCloneUIPrefabs = null;
        LastUITruck baseUIForm = null;
        //根据ui窗体名称，得到对应的加载路径
        _LogTruckSandy.TryGetValue(uiFormName, out strUIFormPaths);
        if (!string.IsNullOrEmpty(strUIFormPaths))
        {
            //加载预制体
           goCloneUIPrefabs= RoutinelyJaw.YewVocation().FeelAsset(strUIFormPaths, false);
        }
        //设置ui克隆体的父节点（根据克隆体中带的脚本中不同的信息位置信息）
        if(_KeaChurchChildhood!=null && goCloneUIPrefabs != null)
        {
            baseUIForm = goCloneUIPrefabs.GetComponent<LastUITruck>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 uiFormName="+uiFormName);
                return null;
            }
            switch (baseUIForm.GhostlyUIFist.UIForms_Type)
            {
                case UIFormType.Normal:
                    goCloneUIPrefabs.transform.SetParent(_KeaDemise, false);
                    break;
                case UIFormType.Fixed:
                    goCloneUIPrefabs.transform.SetParent(_KeaWeave, false);
                    break;
                case UIFormType.PopUp:
                    goCloneUIPrefabs.transform.SetParent(_KeaPaySo, false);
                    break;
                case UIFormType.Top:
                    goCloneUIPrefabs.transform.SetParent(_Mob, false);
                    break;
                default:
                    break;
            }
            //设置隐藏
            goCloneUIPrefabs.SetActive(false);
            //把克隆体，加入到所有ui窗体缓存集合中
            _LogALLUITruck.Add(uiFormName, baseUIForm);
            return baseUIForm;
        }
        else
        {
            Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数uiFormName=" + uiFormName);
        }
        Debug.Log("出现不可以预估的错误，请检查，参数 uiFormName=" + uiFormName);
        return null;
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void MetalUITruckPlain(string uiFormName)
    {
        //ui窗体基类
        LastUITruck baseUIForm;
        //从所有窗体集合中得到的窗体
        LastUITruck baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _LogGhostlySinkUITruck.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        //把当前窗体，加载到正在显示集合中
        _LogALLUITruck.TryGetValue(uiFormName, out baseUIFormFromAllCache);
        if (baseUIFormFromAllCache != null)
        {
            _LogGhostlySinkUITruck.Add(uiFormName, baseUIFormFromAllCache);
            //显示当前窗体
            baseUIFormFromAllCache.Display();
            
        }
    }

    /// <summary>
    /// 卸载ui窗体从当前显示的集合缓存中
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void MuleUITruckPlain(string strUIFormsName)
    {
        //ui窗体基类
        LastUITruck baseUIForms;
        //正在显示ui窗体缓存集合没有记录，则直接返回
        _LogGhostlySinkUITruck.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体，运行隐藏，且从正在显示ui窗体缓存集合中移除
        baseUIForms.Hidding();
        _LogGhostlySinkUITruck.Remove(strUIFormsName);
    }

    /// <summary>
    /// 加载ui窗体到当前显示窗体集合，且，隐藏其他正在显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void MetalUIRadiumMePlainWeakOther(string strUIFormsName)
    {
        //窗体基类
        LastUITruck baseUIForms;
        //所有窗体集合中的窗体基类
        LastUITruck baseUIFormsFromAllCache;
        _LogGhostlySinkUITruck.TryGetValue(strUIFormsName, out baseUIForms);
        //正在显示ui窗体缓存集合里有记录，直接返回
        if (baseUIForms != null) return;
        Debug.Log("关闭其他窗体");
        //正在显示ui窗体缓存 与栈缓存集合里所有的窗体进行隐藏处理
        List<LastUITruck> ShowUIFormsList = new List<LastUITruck>(_LogGhostlySinkUITruck.Values);
        foreach (LastUITruck baseUIFormsItem in ShowUIFormsList)
        {
            //Debug.Log("_DicCurrentShowUIForms---------" + baseUIFormsItem.transform.name);
            if (baseUIFormsItem.GhostlyUIFist.UIForms_Type == UIFormType.PopUp)
            {
                //baseUIFormsItem.Hidding();
                MuleUITruckSortPlainRimSinkBleak(baseUIFormsItem.GetType().Name);
            }
        }
        List<LastUITruck> CurrentUIFormsList = new List<LastUITruck>(_DigGhostlyUITruck);
        foreach (LastUITruck baseUIFormsItem in CurrentUIFormsList)
        {
            //Debug.Log("_StaCurrentUIForms---------"+baseUIFormsItem.transform.name);
            //baseUIFormsItem.Hidding();
            MuleUITruckSortPlainRimSinkBleak(baseUIFormsItem.GetType().Name);
        }
        //把当前窗体，加载到正在显示ui窗体缓存集合中 
        _LogALLUITruck.TryGetValue(strUIFormsName, out baseUIFormsFromAllCache);
        if (baseUIFormsFromAllCache != null)
        {
            _LogGhostlySinkUITruck.Add(strUIFormsName, baseUIFormsFromAllCache);
            baseUIFormsFromAllCache.Display();
        }
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void MetalUITruckPlainIronPiano(string uiFormName)
    {
        //ui窗体基类
        LastUITruck baseUIForm;
        //从所有窗体集合中得到的窗体
        LastUITruck baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _LogGhostlySinkUITruck.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        bool havePopUp = false;
        foreach (LastUITruck uiforms in _LogGhostlySinkUITruck.Values)
        {
            if (uiforms.GhostlyUIFist.UIForms_Type == UIFormType.PopUp)
            {
                havePopUp = true;
                break;
            }
        }
        if (!havePopUp)
        {
            //把当前窗体，加载到正在显示集合中
            _LogALLUITruck.TryGetValue(uiFormName, out baseUIFormFromAllCache);
            if (baseUIFormFromAllCache != null)
            {
                _LogGhostlySinkUITruck.Add(uiFormName, baseUIFormFromAllCache);
                //显示当前窗体
                baseUIFormFromAllCache.Display();

            }
        }
        else
        {
            _IronUITruck.Add(uiFormName);
        }
        
    }
    /// <summary>
    /// 卸载ui窗体从当前显示窗体集合缓存中，且显示其他原本需要显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void MuleUITruckSortPlainRimSinkBleak(string strUIFormsName)
    {
        //ui窗体基类
        LastUITruck baseUIForms;
        _LogGhostlySinkUITruck.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体 ，运行隐藏状态，且从正在显示ui窗体缓存集合中删除
        baseUIForms.Hidding();
        _LogGhostlySinkUITruck.Remove(strUIFormsName);
        //正在显示ui窗体缓存与栈缓存集合里素有窗体进行再次显示
        //foreach (LastUITruck baseUIFormsItem in _DicCurrentShowUIForms.Values)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
        //foreach (LastUITruck baseUIFormsItem in _StaCurrentUIForms)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
    }
    /// <summary>
    /// ui窗体入栈
    /// 功能：1判断栈里是否已经有窗体，有则冻结
    ///   2先判断ui预设缓存集合是否有指定的ui窗体，有则处理
    ///   3指定ui窗体入栈
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void JuryUITruck(string strUIFormsName)
    {
        //ui预设窗体
        LastUITruck baseUI;
        //判断栈里是否已经有窗体,有则冻结
        if (_DigGhostlyUITruck.Count > 0)
        {
            LastUITruck topUIForms = _DigGhostlyUITruck.Peek();
            topUIForms.Russia();
            //Debug.Log("topUIForms是" + topUIForms.name);
        }
        //先判断ui预设缓存集合是否有指定ui窗体，有则处理
        _LogALLUITruck.TryGetValue(strUIFormsName, out baseUI);
        if (baseUI != null)
        {
            baseUI.Display();
        }
        else
        {
            Debug.Log(string.Format("/PushUIForms()/ baseUI==null! 核心错误，请检查 strUIFormsName={0} ", strUIFormsName));
        }
        //指定ui窗体入栈
        _DigGhostlyUITruck.Push(baseUI);
       
    }

    /// <summary>
    /// ui窗体出栈逻辑
    /// </summary>
    private void PayUITruck()
    {

        if (_DigGhostlyUITruck.Count >= 2)
        {
            //出栈逻辑
            LastUITruck topUIForms = _DigGhostlyUITruck.Pop();
            //出栈的窗体进行隐藏
            topUIForms.Hidding(() => {
                //出栈窗体的下一个窗体逻辑
                LastUITruck nextUIForms = _DigGhostlyUITruck.Peek();
                //下一个窗体重新显示处理
                nextUIForms.Redisplay();
            });
        }
        else if (_DigGhostlyUITruck.Count == 1)
        {
            LastUITruck topUIForms = _DigGhostlyUITruck.Pop();
            //出栈的窗体进行隐藏处理
            topUIForms.Hidding();
        }
    }


    /// <summary>
    /// 初始化ui窗体预设路径数据
    /// </summary>
    private void TireUITruckSandyHall()
    {
        IScreamWrapper configMgr = new ScreamWrapperAnGain(SheDefine.SYS_PATH_UIFORMS_CONFIG_INFO);
        if (_LogTruckSandy != null)
        {
            _LogTruckSandy = configMgr.BuyUnclear;
        }
    }

    /// <summary>
    /// 清空栈结构体集合
    /// </summary>
    /// <returns></returns>
    private bool RomanUncleDense()
    {
        if(_DigGhostlyUITruck!=null && _DigGhostlyUITruck.Count >= 1)
        {
            _DigGhostlyUITruck.Clear();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前弹框ui的栈
    /// </summary>
    /// <returns></returns>
    public Stack<LastUITruck> YewGhostlyAridUncle()
    {
        return _DigGhostlyUITruck;
    }


    /// <summary>
    /// 根据panel名称获取panel gameObject
    /// </summary>
    /// <param name="uiFormName"></param>
    /// <returns></returns>
    public GameObject YewScoreAnClaw(string uiFormName)
    {
        //ui窗体基类
        LastUITruck baseUIForm;
        //如果正在显示的集合中存在该窗体，直接返回
        _LogALLUITruck.TryGetValue(uiFormName, out baseUIForm);
        return baseUIForm?.gameObject;
    }

    /// <summary>
    /// 获取所有打开的panel（不包括Normal）
    /// </summary>
    /// <returns></returns>
    public List<GameObject> YewOntarioMaroon(bool containNormal = false)
    {
        List<GameObject> openingPanels = new List<GameObject>();
        List<LastUITruck> allUIFormsList = new List<LastUITruck>(_LogALLUITruck.Values);
        foreach(LastUITruck panel in allUIFormsList)
        {
            if (panel.gameObject.activeInHierarchy)
            {
                if (containNormal || panel._CurrentUIType.UIForms_Type != UIFormType.Normal)
                {
                    openingPanels.Add(panel.gameObject);
                }
            }
        }

        return openingPanels;
    }
}
