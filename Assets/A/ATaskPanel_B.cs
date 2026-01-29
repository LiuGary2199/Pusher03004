using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATaskPanel_B : LastUITruck
{
[UnityEngine.Serialization.FormerlySerializedAs("BtnClose")]    public Button DigAdopt;
[UnityEngine.Serialization.FormerlySerializedAs("TaskItemPrefab")]    public GameObject KilnWeltGypsum;
[UnityEngine.Serialization.FormerlySerializedAs("TaskItemParent")]    public Transform KilnWeltSpiral;
    
    [Header("任务项列表（可直接拖拽）")]
[UnityEngine.Serialization.FormerlySerializedAs("TaskItemList")]    public List<ATaskItem_B> KilnWeltHunt= new List<ATaskItem_B>();

    private List<ATaskItem_B> WakeKarst= new List<ATaskItem_B>();
    
    // 四个任务：完成2、4、6、8关，每个奖励200金币
    private readonly int[] WakePetiole = { 50, 100, 200, 300 };
    private readonly int WakeCustom= 1000;

    public override void Display()
    {
        base.Display();
        DigAdopt.onClick.AddListener(() => { PianoUIArid(GetType().Name); });

        // 检查并刷新每日任务
        UtahHallWrapper.YewVocation().ScrubDieCrustalValveForge();
        
        // 初始化任务列表
        MoteKilnHunt();
    }

    public override void Redisplay()
    {
        base.Redisplay();
        // 刷新任务列表
        CrustalKilnHunt();
    }
    
    /// <summary>
    /// 初始化任务列表
    /// </summary>
    private void MoteKilnHunt()
    {
        WakeKarst.Clear();
        
        // 优先使用直接拖拽的列表
        if (KilnWeltHunt != null && KilnWeltHunt.Count > 0)
        {
            // 过滤掉空引用，只添加有效的任务项
            foreach (var item in KilnWeltHunt)
            {
                if (item != null)
                {
                    WakeKarst.Add(item);
                }
            }
        }
        
        // 如果列表为空，尝试从 TaskItemParent 中收集
        if (WakeKarst.Count == 0 && KilnWeltSpiral != null)
        {
            for (int i = 0; i < KilnWeltSpiral.childCount; i++)
            {
                Transform child = KilnWeltSpiral.GetChild(i);
                ATaskItem_B taskItem = child.GetComponent<ATaskItem_B>();
                if (taskItem != null)
                {
                    WakeKarst.Add(taskItem);
                }
            }
        }
        
        // 如果任务项数量不够，则动态生成补充
        while (WakeKarst.Count < WakePetiole.Length)
        {
            ATaskItem_B taskItem = ShareKilnWelt();
            if (taskItem != null)
            {
                WakeKarst.Add(taskItem);
            }
            else
            {
                break; // 如果生成失败，退出循环
            }
        }
        
        // 初始化所有任务项
        for (int i = 0; i < WakeKarst.Count && i < WakePetiole.Length; i++)
        {
            if (WakeKarst[i] != null)
            {
                int taskId = i;
                int target = WakePetiole[i];
                int progress = UtahHallWrapper.YewVocation().CopKilnExterior(taskId);
                TaskStatus_B status = UtahHallWrapper.YewVocation().CopKilnSawyer(taskId);
                
                WakeKarst[i].Mote(taskId, progress, target, WakeCustom, status);
            }
        }
    }
    
    /// <summary>
    /// 刷新任务列表
    /// </summary>
    private void CrustalKilnHunt()
    {
        for (int i = 0; i < WakeKarst.Count && i < WakePetiole.Length; i++)
        {
            if (WakeKarst[i] != null)
            {
                int taskId = i;
                int target = WakePetiole[i];
                int progress = UtahHallWrapper.YewVocation().CopKilnExterior(taskId);
                TaskStatus_B status = UtahHallWrapper.YewVocation().CopKilnSawyer(taskId);
                
                WakeKarst[i].DefendKilnCite(progress, target, status);
            }
        }
    }
    
    private ATaskItem_B ShareKilnWelt()
    {
        if (KilnWeltGypsum == null || KilnWeltSpiral == null)
            return null;
            
        var go = Instantiate(KilnWeltGypsum, KilnWeltSpiral);
        go.transform.localScale = Vector3.one;
        go.SetActive(true);
        return go.GetComponent<ATaskItem_B>();
    }
}