/***
 * 
 * AudioSource组件管理(音效，背景音乐除外)
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScentKernelPlain 
{
    //音乐的管理者
    private GameObject ScentJaw;
    //音乐组件管理队列
    private List<AudioSource> ScentReexaminePlain;
    //音乐组件默认容器最大值  
    private int ViePupil= 25;
    public ScentKernelPlain(OfferJaw audioMgr)
    {
        ScentJaw = audioMgr.gameObject;
        TireScentKernelPlain();
    }
  
    /// <summary>
    /// 初始化队列
    /// </summary>
    private void TireScentKernelPlain()
    {
        ScentReexaminePlain = new List<AudioSource>();
        for(int i = 0; i < ViePupil; i++)
        {
            YewScentKernelRimDashJaw();
        }
    }
    /// <summary>
    /// 给音乐的管理者添加音频组件，同时组件加入队列
    /// </summary>
    private AudioSource YewScentKernelRimDashJaw()
    {
        AudioSource audio = ScentJaw.AddComponent<AudioSource>();
        ScentReexaminePlain.Add(audio);
        return audio;
    }
    /// <summary>
    /// 获取一个音频组件
    /// </summary>
    /// <param name="audioMgr"></param>
    /// <returns></returns>
    public AudioSource YewScentReexamine()
    {
        if (ScentReexaminePlain.Count > 0)
        {
            AudioSource audio = ScentReexaminePlain.Find(t => !t.isPlaying);
            if (audio)
            {
                ScentReexaminePlain.Remove(audio);
                return audio;
            }
            //队列中没有了，需额外添加
            return YewScentKernelRimDashJaw();
            //直接返回队列中存在的组件
            //return AudioComponentQueue.Dequeue();
        }
        else
        {
            //队列中没有了，需额外添加
            return  YewScentKernelRimDashJaw();
        }
    }
    /// <summary>
    /// 没有被使用的音频组件返回给队列
    /// </summary>
    /// <param name="audio"></param>
    public void UnBagScentReexamine(AudioSource audio)
    {
        if (ScentReexaminePlain.Contains(audio)) return;
        if (ScentReexaminePlain.Count >= ViePupil)
        {
            GameObject.Destroy(audio);
            //Debug.Log("删除组件");
        }
        else
        {
            audio.clip = null;
            ScentReexaminePlain.Add(audio);
        }

        //Debug.Log("队列长度是" + AudioComponentQueue.Count);
    }
    
}
