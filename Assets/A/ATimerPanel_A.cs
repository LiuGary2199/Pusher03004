using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATimerPanel_A : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("BtnClose")]    public Button DigAdopt;
    
    [Header("计时器项列表（可直接拖拽）")]
[UnityEngine.Serialization.FormerlySerializedAs("TimerItemList")]    public List<ATimerItem_A> VagueWeltHunt= new List<ATimerItem_A>();
    
    private List<ATimerItem_A> GourdKarst= new List<ATimerItem_A>();
    private Coroutine BestowColumbian;
    
    public override void Display()
    {
        base.Display();
        DigAdopt.onClick.AddListener(() => { PianoUIArid(GetType().Name); });
        // 检查并刷新每日计时器
        UtahHallWrapper.YewVocation().ScrubDieCrustalValveCensus();
        UtahHallWrapper.YewVocation().DefendVagueHomogeneousFact();
        // 初始化计时器列表
        MoteVagueHunt();
        
        // 开始更新倒计时
        if (BestowColumbian != null)
        {
            StopCoroutine(BestowColumbian);
        }
        BestowColumbian = StartCoroutine(DefendCensusColumbian());
    }
    
    public override void Hidding()
    {
        base.Hidding();
        // 停止更新协程
        if (BestowColumbian != null)
        {
            StopCoroutine(BestowColumbian);
            BestowColumbian = null;
        }
        // 保存当前的累积在线时长，确保关闭界面后时间继续计算
        UtahHallWrapper.YewVocation().DefendVagueHomogeneousFact();
    }
    
    public override void Redisplay()
    {
        base.Redisplay();
        // 刷新计时器列表
        CrustalVagueHunt();
    }
    
    /// <summary>
    /// 初始化计时器列表
    /// </summary>
    private void MoteVagueHunt()
    {
        GourdKarst.Clear();
        
        // 优先使用直接拖拽的列表
        if (VagueWeltHunt != null && VagueWeltHunt.Count > 0)
        {
            foreach (var item in VagueWeltHunt)
            {
                if (item != null)
                {
                    GourdKarst.Add(item);
                }
            }
        }
        
        // 如果列表为空，尝试从子对象中收集
        if (GourdKarst.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                ATimerItem_A timerItem = child.GetComponent<ATimerItem_A>();
                if (timerItem != null)
                {
                    GourdKarst.Add(timerItem);
                }
            }
        }
        
        // 初始化所有计时器项
        CrustalVagueHunt();
    }
    
    /// <summary>
    /// 刷新计时器列表
    /// </summary>
    private void CrustalVagueHunt()
    {
        for (int i = 0; i < GourdKarst.Count; i++)
        {
            if (GourdKarst[i] != null)
            {
                int GourdIt= i;
                int duration = UtahHallWrapper.YewVocation().CopVagueSecurely(GourdIt);
                ATimerStatus_A status = UtahHallWrapper.YewVocation().CopVagueSawyer(GourdIt);
                int remainingSeconds = UtahHallWrapper.YewVocation().CopVaguePrivatelyReceive(GourdIt);
                bool isReady = UtahHallWrapper.YewVocation().GoVagueVital(GourdIt);
                
                if (isReady && status != ATimerStatus_A.Ready)
                {
                    status = ATimerStatus_A.Ready;
                }
                
                GourdKarst[i].DefendVagueCite(GourdIt, duration, status, remainingSeconds);
            }
        }
    }
    
    /// <summary>
    /// 更新倒计时的协程
    /// </summary>
    private IEnumerator DefendCensusColumbian()
    {
        while (true)
        {
            // 更新累积在线时长
            UtahHallWrapper.YewVocation().DefendVagueHomogeneousFact();
            
            yield return new WaitForSeconds(1f); // 每秒更新一次
            CrustalVagueHunt();
        }
    }
}