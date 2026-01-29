/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMiteJaw : MonoBehaviour
{
    private static UIMiteJaw _Vocation= null;
    //ui根节点对象
    private GameObject _AtChurchDuke= null;
    //ui脚本节点对象
    private Transform _KeaUIDraperyYork= null;
    //顶层面板
    private GameObject _AtMeScore;
    //遮罩面板
    private GameObject _AtMiteScore;
    //ui摄像机
    private Camera _UIUpwind;
    //ui摄像机原始的层深
    private float _DominantUIUpwindPhoto;
    //获取实例
    public static UIMiteJaw YewVocation()
    {
        if (_Vocation == null)
        {
            _Vocation = new GameObject("_UIMaskMgr").AddComponent<UIMiteJaw>();
        }
        return _Vocation;
    }
    private void Awake()
    {
        _AtChurchDuke = GameObject.FindGameObjectWithTag(SheDefine.SYS_TAG_CANVAS);
        _KeaUIDraperyYork = SinceCanyon.WickRobChildYork(_AtChurchDuke, SheDefine.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        SinceCanyon.YewScopeYorkMeQuenchYork(_KeaUIDraperyYork, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _AtMeScore = _AtChurchDuke;
        _AtMiteScore = SinceCanyon.WickRobChildYork(_AtChurchDuke, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UIUpwind = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UIUpwind != null)
        {
            //得到ui相机原始的层深
            _DominantUIUpwindPhoto = _UIUpwind.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void HubMiteHugely(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _AtMeScore.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _AtMiteScore.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _AtMiteScore.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _AtMiteScore.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _AtMiteScore.GetComponent<Image>().color = newColor2;
                CorrectFingerSpoil.YewVocation().Pool(CScream.mg_HugelyDown);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _AtMiteScore.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _AtMiteScore.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_AtMiteScore.activeInHierarchy)
                {
                    _AtMiteScore.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _AtMiteScore.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UIUpwind != null)
        {
            _UIUpwind.depth = _UIUpwind.depth + 100;
        }
    }
    public void WeakMiteHugely()
    {
        if (UIManager.YewVocation().IronUITruck.Count > 0 || UIManager.YewVocation().YewGhostlyAridUncle().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_AtMiteScore.GetComponent<Image>().color.r, _AtMiteScore.GetComponent<Image>().color.g, _AtMiteScore.GetComponent<Image>().color.b,0);
        _AtMiteScore.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void RecentMiteHugely()
    {
        if (UIManager.YewVocation().IronUITruck.Count > 0 || UIManager.YewVocation().YewGhostlyAridUncle().Count > 0)
        {
            return;
        }
        //顶层窗体上移
        _AtMeScore.transform.SetAsFirstSibling();
        //禁用遮罩窗体
        if (_AtMiteScore.activeInHierarchy)
        {
            _AtMiteScore.SetActive(false);
            CorrectFingerSpoil.YewVocation().Pool(CScream.So_HugelyPiano);
        }
        //恢复当前ui摄像机的层深
        if (_UIUpwind != null)
        {
            _UIUpwind.depth = _DominantUIUpwindPhoto;
        }
    }
}
