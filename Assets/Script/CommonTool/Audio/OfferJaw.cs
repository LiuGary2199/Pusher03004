/***
 * 
 * 音乐管理器
 * 
 * **/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferJaw : MonoWeightily<OfferJaw>
{
    //音频组件管理队列的对象
    private ScentKernelPlain ScentPlain;
    // 用于播放背景音乐的音乐源
    private AudioSource m_bgOffer= null;
    //播放音效的音频组件管理列表
    private List<AudioSource> BillScentKernelGerm;
    //检查已经播放的音频组件列表中没有播放的组件的更新频率
    private float ScantSmoothly= 2f;
    //背景音乐开关
    private bool _ByOfferRelate;
    //音效开关
    private bool _PurifyOfferRelate;
    //音乐音量
    private float _ByUnbind= 1f;
    //音效音量
    private float _PurifyUnbind= 1f;
    string BGM_Claw= "";

    public Dictionary<string, AudioModel> ScentUnclearFoil;
    public Dictionary<string, AudioClip> ScentVastFoil;

    public List<string> BronzeClawCreep;
    // 控制背景音乐音量大小
    public float ByUnbind    {
        get
        {
            return ByOfferRelate ? EraUnbind(BGM_Claw) : 0f;
        }
        set
        {
            _ByUnbind = value;
            //背景音乐开的状态下，声音随控制调节
        }
    }

    //控制音效音量的大小
    public float PurifyHardly    {
        get { return _PurifyUnbind; }
        set
        {
            _PurifyUnbind = value;
            HubDotPurifyUnbind();
        }
    }
    //控制背景音乐开关
    public bool ByOfferRelate    {
        get
        {

            _ByOfferRelate = ToilHallWrapper.YewShop("_BgMusicSwitch");
            return _ByOfferRelate;
        }
        set
        {
            if (m_bgOffer)
            {
                _ByOfferRelate = value;
                ToilHallWrapper.HubShop("_BgMusicSwitch", _ByOfferRelate);
                m_bgOffer.volume = ByUnbind;
            }
        }
    }
    public void LopEkePianoYouFast()
    {
        m_bgOffer.volume = 0;
    }
    public void LopEkePetioleYouFast()
    {
        m_bgOffer.volume = ByUnbind;
    }
    //控制音效开关
    public bool PurifyOfferRelate    {
        get
        {
            _PurifyOfferRelate = ToilHallWrapper.YewShop("_EffectMusicSwitch");
            return _PurifyOfferRelate;
        }
        set
        {
            _PurifyOfferRelate = value;
            ToilHallWrapper.HubShop("_EffectMusicSwitch", _PurifyOfferRelate);

        }
    }
    public OfferJaw()
    {
        BillScentKernelGerm = new List<AudioSource>();
    }
    protected override void Awake()
    {
        BronzeClawCreep = new List<string>();
        if (!PlayerPrefs.HasKey("first_music_setBool") || !ToilHallWrapper.YewShop("first_music_set"))
        {
            ToilHallWrapper.HubShop("first_music_set", true);
            ToilHallWrapper.HubShop("_BgMusicSwitch", true);
            ToilHallWrapper.HubShop("_EffectMusicSwitch", true);
        }
        ScentPlain = new ScentKernelPlain(this);

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        ScentUnclearFoil = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
    }
    private void Start()
    {
        StartCoroutine(nameof(ScantToBagScentReexamine));
    }
    public void TireOfferJaw()
    {
        ScentVastFoil = new Dictionary<string, AudioClip>();
        foreach (string key in ScentUnclearFoil.Keys)
        {
            ScentVastFoil.Add(key, Resources.Load<AudioClip>(ScentUnclearFoil[key].filePath));
        }

    }
    /// <summary>
    /// 定时检查没有使用的音频组件并回收
    /// </summary>
    /// <returns></returns>
    IEnumerator ScantToBagScentReexamine()
    {
        while (true)
        {
            //定时更新
            yield return new WaitForSeconds(ScantSmoothly);
            for (int i = 0; i < BillScentKernelGerm.Count; i++)
            {
                //防止数据越界
                if (i < BillScentKernelGerm.Count)
                {
                    //确保物体存在
                    if (BillScentKernelGerm[i])
                    {
                        //音频为空或者没有播放为返回队列条件
                        if ((BillScentKernelGerm[i].clip == null || !BillScentKernelGerm[i].isPlaying))
                        {
                            //返回队列
                            ScentPlain.UnBagScentReexamine(BillScentKernelGerm[i]);
                            //从播放列表中删除
                            BillScentKernelGerm.Remove(BillScentKernelGerm[i]);
                        }
                    }
                    else
                    {
                        //移除在队列中被销毁但是是在list中存在的垃圾数据
                        BillScentKernelGerm.Remove(BillScentKernelGerm[i]);
                    }
                }

            }
        }
    }
    /// <summary>
    /// 设置当前播放的所有音效的音量
    /// </summary>
    private void HubDotPurifyUnbind()
    {
        for (int i = 0; i < BillScentKernelGerm.Count; i++)
        {
            if (BillScentKernelGerm[i] && BillScentKernelGerm[i].isPlaying)
            {
                BillScentKernelGerm[i].volume = _PurifyOfferRelate ? _PurifyUnbind : 0f;
            }
        }
    }
    /// <summary>
    /// 播放背景音乐，传进一个音频剪辑的name
    /// </summary>
    /// <param name="bgName"></param>
    /// <param name="restart"></param>
    private void BillByLast(object bgName, bool restart = false)
    {

        BGM_Claw = bgName.ToString();
        if (m_bgOffer == null)
        {
            //拿到一个音频组件  背景音乐组件在某一时间段唯一存在
            m_bgOffer = ScentPlain.YewScentReexamine();
            //开启循环
            m_bgOffer.loop = true;
            //开始播放
            m_bgOffer.playOnAwake = false;
            //加入播放列表
            //PlayAudioSourceList.Add(m_bgMusic);
        }

        if (!ByOfferRelate)
        {
            m_bgOffer.volume = 0;
        }

        //定义一个空的字符串
        string curBgName = string.Empty;
        //如果这个音乐源的音频剪辑不为空的话
        if (m_bgOffer.clip != null)
        {
            //得到这个音频剪辑的name
            curBgName = m_bgOffer.clip.name;
        }

        // 根据用户的音频片段名称, 找到AuioClip, 然后播放,
        //ResourcesMgr是提前定义好的查找音频剪辑对应路径的单例脚本，并动态加载出来
        //AudioClip clip = Resources.Load<AudioClip>(AudioSettingDict[BGM_Name].filePath);
        AudioClip clip = ScentVastFoil[BGM_Claw];

        //如果找到了，不为空
        if (clip != null)
        {
            //如果这个音频剪辑已经复制给类音频源，切正在播放，那么直接跳出
            if (clip.name == curBgName && !restart)
            {
                return;
            }
            //否则，把改音频剪辑赋值给音频源，然后播放
            m_bgOffer.clip = clip;
            m_bgOffer.volume = ByUnbind;
            m_bgOffer.Play();
        }
        else
        {
            //没找到直接报错
            // 异常, 调用写日志的工具类.
            //UnityEngine.Debug.Log("没有找到音频片段");
            if (m_bgOffer.isPlaying)
            {
                m_bgOffer.Stop();
            }
            m_bgOffer.clip = null;
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="defAudio"></param>
    /// <param name="volume"></param>
    private void BillPurifyLast(object effectName, bool defAudio = true, float volume = 1f)
    {
        if (!PurifyOfferRelate)
        {
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = ScentPlain.YewScentReexamine();
        if (m_effectMusic.isPlaying)
        {
            Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = EraUnbind(effectName.ToString());
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        Debug.Log(ScentUnclearFoil[effectName.ToString()].filePath);
        //AudioClip clip = Resources.Load<AudioClip>(AudioSettingDict[effectName.ToString()].filePath);
        AudioClip clip = ScentVastFoil[effectName.ToString()];
        //如果为空的话，直接报错，然后跳出
        if (clip == null)
        {
            UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            ScentPlain.UnBagScentReexamine(m_effectMusic);
            return;
        }
        m_effectMusic.clip = clip;
        //加入播放列表
        BillScentKernelGerm.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            Debug.Log("音效播放");
            m_effectMusic.PlayOneShot(clip, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
    private void BillPurifyLast(object effectName, float start, float end)
    {
        bool defAudio = true;
        float volume = 1f;
        if (!PurifyOfferRelate)
        {
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = ScentPlain.YewScentReexamine();
        if (m_effectMusic.isPlaying)
        {
            Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = EraUnbind(effectName.ToString());
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        //AudioClip clip = Resources.Load<AudioClip>(AudioSettingDict[effectName.ToString()].filePath);
        AudioClip clip = ScentVastFoil[effectName.ToString()];
        //如果为空的话，直接报错，然后跳出
        if (clip == null)
        {
            UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            ScentPlain.UnBagScentReexamine(m_effectMusic);
            return;
        }
        m_effectMusic.clip = clip;
        //加入播放列表
        BillScentKernelGerm.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            Debug.Log("音效播放");
            m_effectMusic.Stop();
            m_effectMusic.SetScheduledStartTime(start);
            m_effectMusic.SetScheduledEndTime(end);
            m_effectMusic.PlayOneShot(clip, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void BillBy(OfferFist.UIMusic bgName, bool restart = false)
    {
        BillByLast(bgName, restart);
    }

    public void BillBy(OfferFist.SceneMusic bgName, bool restart = false)
    {
        BillByLast(bgName, restart);
    }

    public void BillPurify(OfferFist.UIMusic bgName, float limit, System.Action finish = null)
    {
        BillPurifyLast(bgName, limit, finish);
    }

    public void BillPurify(OfferFist.SceneMusic bgName, float limit, System.Action finish = null)
    {
        BillPurifyLast(bgName, limit, finish);
    }


    private void BillPurifyLast(object effectName, float limit, System.Action finish = null)
    {
        if (!BronzeClawCreep.Contains(effectName.ToString()))
        {
            if (finish != null)
            {
                finish();
            }
            BillPurifyLast(effectName, true, 1);
            BronzeClawCreep.Add(effectName.ToString());
            StartCoroutine(ArrivePurifyClaw(effectName.ToString(), limit));
        }
    }
    IEnumerator ArrivePurifyClaw(string name, float limit)
    {
        yield return new WaitForSeconds(limit);
        if (BronzeClawCreep.Contains(name))
        {
            BronzeClawCreep.Remove(name);
        }
    }
    public void BillPurify(OfferFist.UIMusic effectName, float start, float end)
    {
        BillPurifyLast(effectName, start, end);
    }
    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void BillPurify(OfferFist.UIMusic effectName, bool defAudio = true, float volume = 1f)
    {
        BillPurifyLast(effectName, defAudio, volume);
    }

    public void BillPurify(OfferFist.SceneMusic effectName, bool defAudio = true, float volume = 1f)
    {
        BillPurifyLast(effectName, defAudio, volume);
    }
    float EraUnbind(string name)
    {
        if (ScentUnclearFoil == null)
        {
            TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
            ScentUnclearFoil = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
        }

        if (ScentUnclearFoil.ContainsKey(name))
        {
            return (float)ScentUnclearFoil[name].volume;

        }
        else
        {
            return 1;
        }
    }

}