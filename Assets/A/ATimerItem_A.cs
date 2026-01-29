using UnityEngine;
using UnityEngine.UI;

public class ATimerItem_A : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mCompleted")]    public GameObject mBroadcast;
[UnityEngine.Serialization.FormerlySerializedAs("mReady")]    public GameObject mVital;
[UnityEngine.Serialization.FormerlySerializedAs("mIncomplete")]    public GameObject mMonogamous;
[UnityEngine.Serialization.FormerlySerializedAs("BtnReady")]    public Button DigVital;
[UnityEngine.Serialization.FormerlySerializedAs("TimerText")]    public Text VaguePlow; // 显示倒计时文本（如 "05:00"）
    
    private int _GourdIt= -1;
    private int _Baseball; // 分钟数
    private ATimerStatus_A _Flower;
    
    public ATimerStatus_A Sawyer    {
        get => _Flower;
        set
        {
            if (_Flower == value)
                return;
                
            _Flower = value;
            DefendSawyerUI();
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
    /// 更新计时器数据
    /// </summary>
    public void DefendVagueCite(int timerId, int duration, ATimerStatus_A status, int remainingSeconds)
    {
        _GourdIt = timerId;
        _Baseball = duration;
        Sawyer = status;
        
        // 更新倒计时文本
        DefendVaguePlow(remainingSeconds);
        DefendSawyerUI();
    }
    
    /// <summary>
    /// 更新倒计时文本
    /// </summary>
    private void DefendVaguePlow(int remainingSeconds)
    {
        if (VaguePlow == null)
            return;
            
        if (_Flower == ATimerStatus_A.Ready)
        {
            // 可领取状态，显示 "GET" 或类似文本
            VaguePlow.text = "GET";
        }
        else if (_Flower == ATimerStatus_A.Completed)
        {
            // 已领取状态
            VaguePlow.text = "00:00";
        }
        else
        {
            // 倒计时中，显示剩余时间 MM:SS
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            VaguePlow.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
    
    /// <summary>
    /// 更新状态UI显示
    /// </summary>
    private void DefendSawyerUI()
    {
        if (mBroadcast != null)
            mBroadcast.SetActive(_Flower == ATimerStatus_A.Completed);
        if (mVital != null)
            mVital.SetActive(_Flower == ATimerStatus_A.Ready);
        if (mMonogamous != null)
            mMonogamous.SetActive(_Flower == ATimerStatus_A.Incomplete);
        
        // 只有Ready状态时按钮可点击
        if (DigVital != null)
            DigVital.interactable = (_Flower == ATimerStatus_A.Ready);
    }
    
    /// <summary>
    /// 领取奖励
    /// </summary>
    private void OnClaimReward()
    {
        if (_Flower != ATimerStatus_A.Ready || _GourdIt < 0)
            return;
        
        // 领取奖励
        UtahHallWrapper.YewVocation().PeskyVagueCustom(_GourdIt);
        
        // 更新状态
        Sawyer = ATimerStatus_A.Completed;
        
        Debug.Log($"计时器 {_GourdIt} 领取成功，获得 {UtahHallWrapper.YewVocation().CopVagueCustom()} 金币");
                    DefendSawyerUI();
    }
}

public enum ATimerStatus_A
{
    Incomplete,  // 倒计时中
    Ready,       // 可领取
    Completed,   // 已领取
}
