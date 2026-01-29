using UnityEngine;
using UnityEngine.UI;

public class ATaskItem_B : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mCompleted")]    public GameObject mBroadcast;
[UnityEngine.Serialization.FormerlySerializedAs("mReady")]    public GameObject mVital;
[UnityEngine.Serialization.FormerlySerializedAs("mIncomplete")]    public GameObject mMonogamous;
[UnityEngine.Serialization.FormerlySerializedAs("BtnReady")]    public Button DigVital;
[UnityEngine.Serialization.FormerlySerializedAs("TaskText")]    public Text KilnPlow;
    
    private int _WakeIt= -1;
    private int _Soviet;
    private int _Burden;
    
    private TaskStatus_B _Flower;
    public TaskStatus_B Sawyer    {
        get => _Flower;
        set
        {
            if (_Flower == value)
                return;
                
            _Flower = value;
            DefendSawyerUI();
            // 保存状态（只有在taskId已初始化时才保存）
            if (_WakeIt >= 0)
            {
                UtahHallWrapper.YewVocation().KeyKilnSawyer(_WakeIt, _Flower);
            }
        }
    }
    
    private void Awake()
    {
        if (DigVital != null)
        {
            DigVital.onClick.AddListener(OnClaimReward);
        }
    }
    
    /// <summary>
    /// 初始化任务项
    /// </summary>
    public void Mote(int taskId, int progress, int target, int reward, TaskStatus_B status)
    {
        _WakeIt = taskId;
        _Soviet = target;
        _Burden = reward;
        _Flower = status;
        
        DefendKilnCite(progress, target, status);
    }
    
    /// <summary>
    /// 更新任务数据
    /// </summary>
    public void DefendKilnCite(int progress, int target, TaskStatus_B status)
    {
        _Soviet = target;
        // 使用属性设置状态，确保状态同步保存
        Sawyer = status;
        
        // 更新任务文本
        if (KilnPlow != null)
        {
            KilnPlow.text = $"Toss Gold {target} times";
        }
        DefendSawyerUI();
    }
    
    /// <summary>
    /// 更新状态UI显示
    /// </summary>
    private void DefendSawyerUI()
    {
        if (mBroadcast != null)
            mBroadcast.SetActive(_Flower == TaskStatus_B.Completed);
        if (mVital != null)
            mVital.SetActive(_Flower == TaskStatus_B.Ready);
        if (mMonogamous != null)
            mMonogamous.SetActive(_Flower == TaskStatus_B.Incomplete);
        
        // 只有Ready状态时按钮可点击
        if (DigVital != null)
            DigVital.interactable = (_Flower == TaskStatus_B.Ready);
    }
    
    /// <summary>
    /// 领取奖励
    /// </summary>
    private void OnClaimReward()
    {
        if (_Flower != TaskStatus_B.Ready)
            return;

        // 增加金币
        UtahHallWrapper.YewVocation().PeskyVagueCustom(_Burden);
        
        // 更新状态为已完成
        Sawyer = TaskStatus_B.Completed;
        
        Debug.Log($"任务 {_WakeIt} 领取成功，获得 {_Burden} 金币");
    }
}

public enum TaskStatus_B
{
    Incomplete,  // 未完成
    Ready,       // 已完成，可领取
    Completed,   // 已领取
}
