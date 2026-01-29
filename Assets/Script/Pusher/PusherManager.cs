using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using LitJson;
using Lofelt.NiceVibrations;
public class PusherManager : MonoBehaviour
{
    static public PusherManager Instance;

    public GameObject fx_Pool;
    public GameObject fx_Pool_1;
    public GameObject Text_Pool;
    public GameObject rewardItemPerfab;
    public Transform rewardItemGroup;
    public TombWrapper fxPool;
    public TombWrapper fxPool_1;
    public TombWrapper TextPool;
    private int maxBucketNum;
    public int currentBucketNum;
    public GameObject ColumnGroup;
    public GameObject centerDoor;
    public GameObject coinPagodaPerfab;
    public GameObject fX_Fever;
    public GameObject fX_BigWin;
    public GameObject fX_BoxGroup;
    public bool haveLittleGame = false;
    public bool isPause = false;
    /// <summary>
    /// 是否进入fever
    /// </summary>
    public bool isPushFever = false;
    /// <summary>
    /// 是否正在777
    /// </summary>
    public bool isPushBigWin = false;
    int waitingDropCoinCount;

    public DownIDPianoGel DownIDPianoGel;

    private void OnApplicationPause(bool focus)
    {
        if (focus)
        {
            Debug.Log("进入后台");
            saveAllRewardItem();
        }
        else
        {
            Debug.Log("进入前台");
        }
    }


    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        DownIDPianoGel.ScantGelChimp();
        maxBucketNum = 26;
        currentBucketNum = ToilHallWrapper.YewSow(CScream.If_Trash_Rust_Surmise);
        rewardItemGroup.gameObject.AddComponent<TombWrapper>().TireTombWrapper(rewardItemPerfab,rewardItemGroup,300,"RewardItem");
        fxPool.TireTombWrapper(fx_Pool, fxPool.transform, 50, "fxPool");
        fxPool_1.TireTombWrapper(fx_Pool_1, fxPool_1.transform, 20, "fxPool_1");
        TextPool.TireTombWrapper(Text_Pool, TextPool.transform, 50, "TextPool");
        loadAllRewardItem();
        startPusher();
        if (KettleSure.HeYield())
        {
            CrabWrapper.Instance.PianoCrabBG();
        }
    }


    /// <summary>
    /// 推币机启动
    /// </summary>
    public void startPusher()
    {
        RevealLandslideWrapper.Instance.StemAloneHerb();
        if (KettleSure.HeYield())//新报更改该 审核期间去掉slot显示
        {
            RevealLandslideWrapper.Instance.PianoCrabPeg();
        }
        else
        {
            RevealLandslideWrapper.Instance.AntAloneHerb();
        }
        autoDropAdReward();
    }


    /// <summary>
    /// 推币机暂停
    /// </summary>
    public void pausePusher()
    {
        if(!isPause)
        {
            isPause = true;
            //推板移动
            RevealLandslideWrapper.Instance.StemDecayHerb();
            //小球停止运动
            NeedleWrapper.Instance.WearyDotLife();
            //rewarditem停止运动
            pauseRewardItem();
            //slot暂停
            CrabWrapper.Instance.CrabPlow();
            //暂停自动掉落物品
            pauseAutoDropAdReward();
            //fever暂停
            if (isPushFever)
            {
                if (KettleSure.HeYield())
                {
                    RubTenthFastWrapper.Instance.PlowTenth();
                }
                else
                {
                    TenthFastWrapper.Instance.PlowTenth();
                }
                StopCoroutine(nameof(feverEndWaitTime));
            }
            if (isPushBigWin && bigWinEndTime > 0)
            {
                StopCoroutine(nameof(bigWinEndWaitTime));
            }
            if (waitingDropCoinCount > 0)
            {
                StopCoroutine(nameof(dropFiveFromUpWaitTime));
            }
        }
    }
    /// <summary>
    /// 推币机恢复
    /// </summary>
    public void resumePusher()
    {
        if (isPause)
        {
            isPause = false;
            //推板恢复
            RevealLandslideWrapper.Instance.StemInventHerb();
            //小球恢复
            NeedleWrapper.Instance.BudgetDotLife();
            //rewarditem恢复
            resumeRewardItem();
            //slot恢复
            CrabWrapper.Instance.CrabMeAlone();
            //恢复自动掉落物品
            resumeAutoDropAdReward();
            //fever恢复
            if (isPushFever)
            {
                if (KettleSure.HeYield())
                {
                    RubTenthFastWrapper.Instance.MeAloneTenthFast();
                }
                else
                {
                    TenthFastWrapper.Instance.MeAloneTenthFast();
                }
                StartCoroutine(nameof(feverEndWaitTime));
            }
            if (isPushBigWin && bigWinEndTime > 0)
            {
                StartCoroutine(nameof(bigWinEndWaitTime));
            }
            if (waitingDropCoinCount > 0)
            {
                StartCoroutine(nameof(dropFiveFromUpWaitTime));
            }
        }
    }
    /// <summary>
    /// 暂停奖励物体
    /// </summary>
    void pauseRewardItem()
    {
        if (rewardItemGroup.GetComponent<TombWrapper>() != null)
        {
            List<GameObject> list = rewardItemGroup.GetComponent<TombWrapper>().Crew;
            foreach (GameObject rewardItem in list)
            {
                rewardItem.GetComponent<VictimizeDecay>().WearyVictimize();
            }
        }
    }
    /// <summary>
    /// 恢复奖励物体
    /// </summary>
    void resumeRewardItem()
    {
        List<GameObject> list = rewardItemGroup.GetComponent<TombWrapper>().Crew;
        foreach (GameObject rewardItem in list)
        {
            rewardItem.GetComponent<VictimizeDecay>().BudgetVictimize();
        }
    }


    /// <summary>
    /// pusher奖励掉落台下
    /// </summary>
    public void getDropReward(PusherRewardType type, double rewardNum)
    {
        if (isPushFever)
        {
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_getReward,0.1f);
        }
        else
        {
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_getReward,0.1f);
        }
        AddBucketNum();
        HallMaracaWrapper.YewVocation().GelRevealSunlit(type,rewardNum);
        if (type == PusherRewardType.RollCash || type == PusherRewardType.ScratchCard || type == PusherRewardType.LuckyCard)
        {
            haveLittleGame = false;
        }
    }


    /// <summary>
    /// 触发slot
    /// </summary>
    public void startSlot()
    {
        if (isPause)
        {
            return;
        }
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Success);
        HallMaracaWrapper.YewVocation().EraCrabSunlitHall((slotRewardType)=> {
            CrabWrapper.Instance.BillCrab(slotRewardType, () =>
            {
                Debug.Log("finish");
                if (slotRewardType != SlotRewardType.Null)
                {
                    OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_slot_reward);
                    HapticPatterns.PlayPreset(HapticPatterns.PresetType.Success);
                }

                switch (slotRewardType)
                {
                    case SlotRewardType.BigWin:
                      //  SOHOShopManager.instance.AddTaskValue("777", 1);
                        BigWin();
                        break;
                    case SlotRewardType.Cash1:
                        dropFiveCashFromUp(25);
                        break;
                    case SlotRewardType.Cash2:
                        dropFiveCashFromUp(50);
                        break;
                    case SlotRewardType.Cash3:
                        dropFiveCashFromUp(100);
                        break;
                    case SlotRewardType.SkillWall:
                        setWallUp();
                        break;
                    case SlotRewardType.SkillBigCoin:
                        bigCoinDrop();
                        break;
                    case SlotRewardType.SkillLong:
                        pushAddLong();
                        break;
                    case SlotRewardType.GemBlue:
                        dropFromUp(PusherRewardType.GemBlue);
                        break;
                    case SlotRewardType.GemRed:
                        dropFromUp(PusherRewardType.GemRed);
                        break;
                    case SlotRewardType.GemDiamond:
                        dropFromUp(PusherRewardType.GemDiamond);
                        break;
                    case SlotRewardType.Golden:
                        dropFromUp(PusherRewardType.Golden);
                        break;
                    case SlotRewardType.Null:
                        break;
                }
            });
        });
    }


    /// <summary>
    /// 自动掉落间隔时间
    /// </summary>
    float adRewardCDTime = 0;
    /// <summary>
    /// 自动掉落广告奖励(现金卷/刮刮卡/翻牌)
    /// </summary>
    public void autoDropAdReward()
    {
        adRewardCDTime = MudHourJaw.instance.UtahHall.base_config.little_game_time;
        StartCoroutine(nameof(autoDropAdRewardWaitTime));
    }
    /// <summary>
    /// 暂停自动掉落等时
    /// </summary>
    public void pauseAutoDropAdReward()
    {
        StopCoroutine(nameof(autoDropAdRewardWaitTime));
    }
    /// <summary>
    /// 恢复自动掉落等时
    /// </summary>
    public void resumeAutoDropAdReward()
    {
        StartCoroutine(nameof(autoDropAdRewardWaitTime));
    }
    /// <summary>
    /// 自动掉落等时
    /// </summary>
    /// <returns></returns>
    IEnumerator autoDropAdRewardWaitTime()
    {
        while(adRewardCDTime > 0 || haveLittleGame || ToilHallWrapper.YewCarpet(CScream.Ask_Hero_Tine_us) == "new")
        {
            yield return new WaitForSeconds(1);
            adRewardCDTime--;
        }
        if (!KettleSure.HeYield())
        {
            PusherRewardType type = HallMaracaWrapper.YewVocation().EraSendCordMyFist();
            dropFromUp(type);
            haveLittleGame = true;
        }
        autoDropAdReward();
    }


    /// <summary>
    /// 技能-大金币-投掷
    /// </summary>
    public void bigCoinDrop()
    {
        dropFromUp(PusherRewardType.BigCoin, () => {
            
            bigCoinShake();
        });
    }
    /// <summary>
    /// 技能-大金币-震动
    /// </summary>
    public void bigCoinShake()
    {
        Debug.Log("大金币-震动");
        Vector3 startPos = Camera.main.transform.position;
        OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_column_bomb);
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);
        Camera.main.DOShakePosition(0.5f, 0.28f, 30, 2, true).SetEase(Ease.Linear).OnComplete(() =>
        {
            Camera.main.transform.localPosition = startPos;
        });
        for (int i = 0; i < rewardItemGroup.childCount; i++)
        {
            Transform rewardItem = rewardItemGroup.GetChild(i);
            if(rewardItem.GetComponent<Rigidbody>())
            {
                rewardItem.GetComponent<Rigidbody>().AddForce(new Vector3(0, 150, -80));
            }
        }
    }


    /// <summary>
    /// 技能-推板加长
    /// </summary>
    public void pushAddLong()
    {
        //单次推板加长时间
        float time = 10;
        RevealLandslideWrapper.Instance.StemYewFall(time);
    }


    /// <summary>
    /// 技能-墙
    /// </summary>
    public void setWallUp()
    {
        //单次升墙时间
        float time = 10;
        RevealLandslideWrapper.Instance.LopLakeSo(time);
    }


   
    /// <summary>
    /// 并排掉落多个
    /// </summary>
    /// <param name="count"></param>
    /// <param name="delay"></param>
    void dropFiveCashFromUp(int count)
    {
        waitingDropCoinCount += count;
        if (waitingDropCoinCount == count)
        {
            StartCoroutine(nameof(dropFiveFromUpWaitTime));
        }
    }

    
    /// <summary>
    /// 并排掉落延迟
    /// </summary>
    /// <param name="type"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    IEnumerator dropFiveFromUpWaitTime()
    {
        HallMaracaWrapper.YewVocation().HeroCordSuchKindPupil(true, waitingDropCoinCount);
        while (waitingDropCoinCount > 0)
        {
            HallMaracaWrapper.YewVocation().HeroCordSuchKindPupil(false,waitingDropCoinCount);
            waitingDropCoinCount--;
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_creat_coin, 0.1f);
            dropFromUp(PusherRewardType.CoinCash, null, (int)Mathf.PingPong(waitingDropCoinCount, 4) + 1);
            yield return new WaitForSeconds(0.1f);
        }
    }


    /// <summary>
    /// 从上空掉落物体
    /// </summary>
    /// <param name="dropObj"></param>
    void dropFromUp(PusherRewardType type, Action block = null, int index = 0)
    {
        GameObject rewardItemObj = getRewardItem(type);
        switch (type)
        {
            case PusherRewardType.CoinGold:
                rewardItemObj.transform.eulerAngles = getRandomEulerAngles();
                break;
            case PusherRewardType.CoinCash:
                rewardItemObj.transform.eulerAngles = getRandomEulerAngles();
                break;
            default:
                
                break;
            
        }
        if (rewardItemObj != null)
        {
            
            if (index == 0)
            {
                rewardItemObj.transform.position = new Vector3(UnityEngine.Random.Range(-1.5f,1.5f), 7, -1.6f);
            }
            else
            {
                float[] targetXArray = new float[] {-1.6f,-0.8f,0,0.8f,1.6f };
                rewardItemObj.transform.position = new Vector3(targetXArray[index - 1], 7, -1.6f);
            }
        }
        if (block != null)
        {
            rewardItemObj.AddComponent<CharcoalBadge>().LopBadgeEnough(block);
        }
    }


    /// <summary>
    /// 根据类型获得对应奖励物体
    /// </summary>
    /// <returns></returns>
    public GameObject getRewardItem(PusherRewardType type)
    {
        GameObject rewardItem = rewardItemGroup.GetComponent<TombWrapper>().YewOutlet();
        rewardItem.GetComponent<PusherRewardItem>().initRewardItem(type);
        rewardItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
        rewardItem.transform.eulerAngles = Vector3.zero;
        rewardItem.SetActive(true);
        return rewardItem;
    }

    bool isPagodaUnlock = false;
    /// <summary>
    /// 777
    /// </summary>
    void BigWin()
    {
        DaleBulgeScript.YewVocation().PoolBulge("1005");
        OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_slot_777);
        isPushBigWin = true;
        fX_BigWin.SetActive(true);
        RevealLandslideWrapper.Instance.StemDotHerb(()=> {
            centerDoor.GetComponent<Rigidbody>().DOMoveY(-3, 0.5f).OnComplete(() => {
                OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.sound_enter_allbox);
                GameObject pagodaGroup = creatCoinPagoda(20);
                centerDoor.transform.DOMoveY(0.664f, 0.5f);
                NeedleWrapper.Instance.SternVeilKind(10);
                isPagodaUnlock = false;
                pagodaGroup.transform.DOMoveY(0.74f,2f).OnComplete(()=> {
                    coinPagodaActive(pagodaGroup);
                });
            });
        });
        
    }
    /// <summary>
    /// 创建币塔
    /// </summary>
    /// <param name="heightCount">币塔层数</param>
    GameObject creatCoinPagoda(int heightCount, bool isLoad = false)
    {
        bool isUnlock = false;
        List<Vector3> pointList = new List<Vector3>();
        List<Vector3> eulerList = new List<Vector3>();
        for (int i = 0; i < coinPagodaPerfab.transform.childCount; i++)
        {
            Transform targetTrans = coinPagodaPerfab.transform.GetChild(i);
            pointList.Add(targetTrans.localPosition);
            eulerList.Add(targetTrans.eulerAngles);
        }
        GameObject pagodaGroup = new GameObject();
        pagodaGroup.AddComponent<AfloatCommon>().Table = () =>
        {
            if (!isUnlock)
            {
                isUnlock = true;
                pagodaGroup.GetComponent<AfloatCommon>().enabled = false;
                //Destroy(pagodaGroup.GetComponent<Rigidbody>());
                //for (int i = 0; i < pagodaGroup.transform.childCount; i++)
                //{
                //    GameObject cashCoin = pagodaGroup.transform.GetChild(i).gameObject;
                //    cashCoin.AddComponent<Rigidbody>();
                //    cashCoin.GetComponent<Rigidbody>().mass = 0.8f;
                //    cashCoin.GetComponent<Rigidbody>().angularDrag = 0;
                //}
            }
        };
        pagodaGroup.transform.position = new Vector3(0, centerDoor.transform.position.y + 0.076f, -3.671f);
        pagodaGroup.transform.SetParent(PusherManager.Instance.rewardItemGroup);
        for (int i = 0; i < heightCount; i++)
        {
            GameObject tempObject = new GameObject();
            for (int j = 0; j < 7; j++)
            {
                GameObject cashCoin = PusherManager.Instance.getRewardItem(PusherRewardType.CoinCash);
                cashCoin.transform.SetParent(tempObject.transform);
                cashCoin.transform.localPosition = pointList[j];
                cashCoin.transform.eulerAngles = eulerList[j];
                cashCoin.layer = 0;
                if (!isLoad)
                {
                    Destroy(cashCoin.GetComponent<Rigidbody>());
                }
            }
            tempObject.transform.position = pagodaGroup.transform.position + new Vector3(0, 0.1074f * i, 0);
            tempObject.transform.eulerAngles = new Vector3(0, i * 3, 0);
            for (int k = tempObject.transform.childCount - 1; k >= 0; k--)
            {
                tempObject.transform.GetChild(k).SetParent(pagodaGroup.transform);
            }
            Destroy(tempObject);
        }
        return pagodaGroup;
    }
    
    /// <summary>
    /// 币塔解封
    /// </summary>
    /// <param name="pagodaGroup"></param>
    void coinPagodaActive(GameObject pagodaGroup)
    {

        //for (int i = 0; i < pagodaGroup.transform.childCount; i++)
        //{
        //    GameObject cashCoin = pagodaGroup.transform.GetChild(i).gameObject;
        //    cashCoin.layer = 6;
        //}
        //pagodaGroup.layer = 6;
        //pagodaGroup.AddComponent<Rigidbody>().mass = 30;
        //isUnlock = true;
        //Destroy(pagodaGroup.GetComponent<Rigidbody>());
        isPagodaUnlock = true;
        for (int i = pagodaGroup.transform.childCount - 1; i >= 0; i--)
        {
            Debug.Log(i);
            GameObject cashCoin = pagodaGroup.transform.GetChild(i).gameObject;
            cashCoin.AddComponent<Rigidbody>();
            cashCoin.GetComponent<Rigidbody>().mass = 0.8f;
            cashCoin.GetComponent<Rigidbody>().angularDrag = 0;
            cashCoin.transform.SetParent(rewardItemGroup);
            if (isPause)
            {
                cashCoin.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        fX_BigWin.SetActive(false);
        bigWinEndTime = 5f;
        StartCoroutine(nameof(bigWinEndWaitTime));
    }
    float bigWinEndTime = 0;
    /// <summary>
    /// 777结算
    /// </summary>
    IEnumerator bigWinEndWaitTime()
    {
        while(bigWinEndTime > 0)
        {
            yield return new WaitForSeconds(1);
            bigWinEndTime--;
        }
        isPushBigWin = false;
        HallMaracaWrapper.YewVocation().LysVasEnd();
        if (!isPushFever)
        {
            //奖励弹窗
            SunlitScoreWrapper.Instance.SinkTinSunlitScore(GameUtil.GetBigWinCash());
        }
    }


    /// <summary>
    /// 开始fever
    /// </summary>
    public void feverStart()
    {
        OfferJaw.YewVocation().BillBy(OfferFist.UIMusic.sound_fever_bgm);
        PusherManager.Instance.isPushFever = true;
        RevealLandslideWrapper.Instance.StemAloneHerb(true);
        NeedleWrapper.Instance.TrashAlonePegGenetic(10);
        NeedleWrapper.Instance.TrashAloneSendCordLife();
        fX_Fever.SetActive(true);
        foreach (GameObject fx_Box in fX_BoxGroup.GetComponent<PegCreep>().Railroad)
        {
            fx_Box.GetComponent<Lifelike>().FX_Peace.SetActive(true);
        }
        feverTime = MudHourJaw.instance.UtahHall.base_config.fever_time;
        StartCoroutine(nameof(feverEndWaitTime));
    }
    /// <summary>
    /// fever剩余时间
    /// </summary>
    float feverTime = 0;
    /// <summary>
    /// 结束fever等时
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator feverEndWaitTime()
    {
        while (feverTime > 0)
        {
            yield return new WaitForSeconds(1);
            feverTime--;
        }
        fX_Fever.SetActive(false);
        foreach (GameObject fx_Box in fX_BoxGroup.GetComponent<PegCreep>().Railroad)
        {
            fx_Box.GetComponent<Lifelike>().FX_Peace.SetActive(false);
        }
        isPushFever = false;
        RevealLandslideWrapper.Instance.StemAloneHerb(true);
        NeedleWrapper.Instance.TrashSowPegGenetic();
        NeedleWrapper.Instance.TrashSowSendCordLife();
        feverEnd();
    }
    /// <summary>
    /// fever结算
    /// </summary>
    void feverEnd()
    {
        HallMaracaWrapper.YewVocation().TrashSow();
        OfferJaw.YewVocation().BillBy(OfferFist.UIMusic.sound_bgm);
        if (!isPushBigWin)
        {
            //结算弹窗
            SunlitScoreWrapper.Instance.SinkTinSunlitScore(GameUtil.GetBigWinCash());
        }
    }


    public void PlayFever() 
    {
        foreach (SpriteRenderer sr in ColumnGroup.GetComponent<IodineWrapper>().JungleGerm) 
        {
            sr.sprite = Resources.Load<Sprite>(CScream.Ail_8);
        }
        
    }

    /// <summary>
    /// fever累计次数
    /// </summary>
    public void AddBucketNum()
    {
        if (!isPushFever)
        {
            // 增加fever 数值
            if (KettleSure.HeYield())
            {
                RubTenthFastWrapper.Instance.YewTenthLife();
            }
            else
            {
                TenthFastWrapper.Instance.YewTenthLife();
            }
            currentBucketNum++;
            if (currentBucketNum >= MudHourJaw.instance.UtahHall.base_config.fever_limit)
            {
                currentBucketNum = 0;
                feverStart();
            }
        }
        
    }


    

    Vector3 getRandomEulerAngles()
    {
        Vector3 v3 = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
        return v3;
    }



    /// <summary>
    /// 保存全部物体
    /// </summary>
    public void saveAllRewardItem()
    {
        List<RewardItemSaveData> saveList = new List<RewardItemSaveData>();
        if (isPushBigWin && !isPagodaUnlock)
        {
            foreach (GameObject item in rewardItemGroup.GetComponent<TombWrapper>().Crew)
            {
                if (item.activeSelf && item.transform.parent == rewardItemGroup && item.GetComponent<PusherRewardItem>().rewardType != PusherRewardType.BigCoin)
                {
                    RewardItemSaveData saveData = new RewardItemSaveData();
                    saveData.type = item.GetComponent<PusherRewardItem>().rewardType;
                    saveData.num = item.GetComponent<PusherRewardItem>().rewardNum;
                    saveData.x = item.transform.position.x;
                    saveData.y = item.transform.position.y;
                    saveData.z = item.transform.position.z;
                    saveData.rx = item.transform.eulerAngles.x;
                    saveData.ry = item.transform.eulerAngles.y;
                    saveData.rz = item.transform.eulerAngles.z;
                    saveList.Add(saveData);
                }
            }
            ToilHallWrapper.HubShop("save_data_inbigwin", true);
        }
        else
        {
            foreach (GameObject item in rewardItemGroup.GetComponent<TombWrapper>().Crew)
            {
                if (item.activeSelf && item.GetComponent<PusherRewardItem>().rewardType != PusherRewardType.BigCoin)
                {
                    RewardItemSaveData saveData = new RewardItemSaveData();
                    saveData.type = item.GetComponent<PusherRewardItem>().rewardType;
                    saveData.num = item.GetComponent<PusherRewardItem>().rewardNum;
                    saveData.x = item.transform.position.x;
                    saveData.y = item.transform.position.y;
                    saveData.z = item.transform.position.z;
                    saveData.rx = item.transform.eulerAngles.x;
                    saveData.ry = item.transform.eulerAngles.y;
                    saveData.rz = item.transform.eulerAngles.z;
                    saveList.Add(saveData);
                }
            }
            ToilHallWrapper.HubShop("save_data_inbigwin", false);
        }
        //SaveData savedata = new SaveData();
        //savedata.saveList = saveList;
        string saveJson = JsonMapper.ToJson(saveList);
        ToilHallWrapper.HubCarpet("save_data",saveJson);
    }

    /// <summary>
    /// 读取全部物体
    /// </summary>
    public void loadAllRewardItem()
    {
        string saveJson = ToilHallWrapper.YewCarpet("save_data");
        if (saveJson != null && saveJson.Length > 0)
        {
            foreach (GameObject rewardItem in rewardItemGroup.GetComponent<TombWrapper>().Crew)
            {
                rewardItem.SetActive(false);
            }
            List<RewardItemSaveData> saveList = JsonMapper.ToObject<List<RewardItemSaveData>>(saveJson);
            if (ToilHallWrapper.YewShop("save_data_inbigwin"))
            {
                creatCoinPagoda(20,true);
            }
            foreach (RewardItemSaveData data in saveList)
            {
                if (data.type == PusherRewardType.ScratchCard || data.type == PusherRewardType.LuckyCard || data.type == PusherRewardType.RollCash)
                {
                    haveLittleGame = true;
                }
                GameObject rewardItem = rewardItemGroup.GetComponent<TombWrapper>().YewOutlet();
                rewardItem.transform.position = new Vector3((float)data.x, (float)data.y, (float)data.z);
                rewardItem.transform.eulerAngles = new Vector3((float)data.rx, (float)data.ry, (float)data.rz);
                rewardItem.GetComponent<PusherRewardItem>().initRewardItem(data.type,false);
            }
        } else
        {
            if (KettleSure.HeYield())
            {
                foreach (GameObject coin in rewardItemGroup.GetComponent<TombWrapper>().Crew)
                {
                    if (coin.activeSelf)
                    {
                        coin.GetComponent<PusherRewardItem>().initRewardItem(PusherRewardType.CoinGold,false);
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BigWin();
        // RewardPanelManager.Instance.ShowBigRewardPanel(10);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bigCoinDrop();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            dropFiveCashFromUp(25);
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            RevealCrabPegCharcoal.Instance.BillYouCrab();

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            dropFromUp(PusherRewardType.GemRed);
            dropFromUp(PusherRewardType.GemBlue);
            dropFromUp(PusherRewardType.GemDiamond);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPause)
            {
                pausePusher();
            }
            else
            {
                resumePusher();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            feverStart();
        }
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    SOHOShopManager.instance.AddTaskValue("777", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    SOHOShopManager.instance.AddTaskValue("golden", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    SOHOShopManager.instance.AddTaskValue("AD", 1);
        //}
    }


    

}
//public class SaveData
//{
//    public List<RewardItemSaveData> saveList;
//}
public class RewardItemSaveData
{
    public PusherRewardType type;
    public double num;
    public double x;
    public double y;
    public double z;
    public double rx;
    public double ry;
    public double rz;
}