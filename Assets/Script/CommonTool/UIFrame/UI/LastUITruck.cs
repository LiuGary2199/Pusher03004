using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 基础UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class LastUITruck : MonoBehaviour
{
    public UIFist _CurrentUIType= new UIFist();
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("close_button")]    public Button Chain_Watery;
    //属性，当前ui窗体类型
    internal UIFist GhostlyUIFist    {
        set
        {
            _CurrentUIType = value;
        }
        get
        {
            return _CurrentUIType;
        }
    }
    protected virtual void Awake()
    {
        WickScopeYewReexamine(gameObject);
        if (transform.Find("Window/Content/CloseBtn"))
        {
            Chain_Watery = transform.Find("Window/Content/CloseBtn").GetComponent<Button>();
            Chain_Watery.onClick.AddListener(() => {
                UIManager.YewVocation().PianoOrCampusUITruck(this.GetType().Name);
            });
        }
        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.name = GetType().Name;
    }


    public static void WickScopeYewReexamine(GameObject goParent)
    {
        Transform parent = goParent.transform;
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform chile = parent.GetChild(i);
            if (chile.GetComponent<Button>())
            {
                chile.GetComponent<Button>().onClick.AddListener(() => {

                    OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.Sound_UIButton);
                });
            }
            
            if (chile.childCount > 0)
            {
                WickScopeYewReexamine(chile.gameObject);
            }
        }
    }

    //页面显示
    public virtual void Display()
    {
        //Debug.Log(this.GetType().Name);
        this.gameObject.SetActive(true);
        // 设置模态窗体调用(必须是弹出窗体)
        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UIMiteJaw.YewVocation().HubMiteHugely(this.gameObject, _CurrentUIType.UIForm_LucencyType);
        }
        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
        {

            //动画添加
            switch (_CurrentUIType.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    LandslideDelectable.PaySink(gameObject, () =>
                    {

                    });
                    break;

            }
            
        }
        //NewUserManager.GetInstance().TriggerEvent(TriggerType.panel_display);
    }
    //页面隐藏（不在栈集合中）
    public virtual void Hidding(System.Action finish = null)
    {
        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UIMiteJaw.YewVocation().WeakMiteHugely();
        }

        //取消模态窗体调用

        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
        {
            switch (_CurrentUIType.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    LandslideDelectable.PayWeak(gameObject, () =>
                    {
                        this.gameObject.SetActive(false);
                        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
                        {
                            UIMiteJaw.YewVocation().RecentMiteHugely();
                        }
                        UIManager.YewVocation().SinkCardPaySo();
                        finish?.Invoke();
                    });
                    break;
                case UIFormShowAnimationType.none:
                    this.gameObject.SetActive(false);
                    if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
                    {
                        UIMiteJaw.YewVocation().RecentMiteHugely();
                    }
                    UIManager.YewVocation().SinkCardPaySo();
                    finish?.Invoke();
                    break;

            }

        }
        else
        {
            this.gameObject.SetActive(false);
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
            {
                UIMiteJaw.YewVocation().RecentMiteHugely();
            }
            finish?.Invoke();
        }
    }

    public virtual void Hidding()
    {
        Hidding(null);
    }

    //页面重新显示
    public virtual void Redisplay()
    {
        this.gameObject.SetActive(true);
        if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
        {
            UIMiteJaw.YewVocation().HubMiteHugely(this.gameObject, _CurrentUIType.UIForm_LucencyType); 
        }
    }
    //页面冻结（还在栈集合中）
    public virtual void Russia()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    /// <param name="buttonName">按钮节点名称</param>
    /// <param name="delHandle">委托，需要注册的方法</param>
    protected void NovelistHandleOutletBulge(string buttonName,BulgeOverlapEducable.VoidDelegate delHandle)
    {
        GameObject goButton = SinceCanyon.WickRobChildYork(this.gameObject, buttonName).gameObject;
        //给按钮注册事件方法
        if (goButton != null)
        {
            BulgeOverlapEducable.Yew(goButton).OxForge = delHandle;
        }
    }

    /// <summary>
    /// 打开ui窗体
    /// </summary>
    /// <param name="uiFormName"></param>
    protected void DownUIArid(string uiFormName)
    {
        UIManager.YewVocation().SinkUITruck(uiFormName);
    }

    /// <summary>
    /// 关闭当前ui窗体
    /// </summary>
    protected void PianoUIArid(string uiFormName)
    {
        //处理后的uiform名称
        UIManager.YewVocation().PianoOrCampusUITruck(uiFormName);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgType">消息的类型</param>
    /// <param name="msgName">消息名称</param>
    /// <param name="msgContent">消息内容</param>
    protected void PoolCorrect(string msgType,string msgName,object msgContent)
    {
        KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
        CorrectFinger.PoolCorrect(msgType, kvs);
    }

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public void IndulgeCorrect(string messageType,CorrectFinger.DelMessageDelivery handler)
    {
        CorrectFinger.YewSixEducable(messageType, handler);
    }

    /// <summary>
    /// 显示语言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string Sink(string id)
    {
        string strResult = string.Empty;
        strResult = ObstructJaw.YewVocation().SinkCent(id);
        return strResult;
    }
}
