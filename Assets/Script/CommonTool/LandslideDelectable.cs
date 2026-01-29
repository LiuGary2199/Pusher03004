using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LandslideDelectable : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    /// <summary>
    /// 图标的出现动画
    /// </summary>
    /// <param name="IconImage"></param>
    /// <param name="IconMoveYOffset"></param>
    public static void BarnSo(GameObject IconImage, float IconMoveYStart, float IconMoveYFinal,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        IconImage.GetComponent<Image>().color = new Color(IconImage.GetComponent<Image>().color.r, IconImage.GetComponent<Image>().color.g, IconImage.GetComponent<Image>().color.b, 0);
        IconImage.transform.position = new Vector3(IconImage.transform.position.x, IconMoveYStart, IconImage.transform.position.z);
        /*-------------------------------------动画效果------------------------------------*/
        IconImage.transform.DOMoveY(IconMoveYFinal, 0.5f).SetEase(Ease.OutBack);
        IconImage.GetComponent<Image>().DOFade(1, 0.5f).OnComplete(() => 
        {
            finish();
        });
    }



    /// <summary>
    /// 弹窗出现效果
    /// </summary>
    /// <param name="PopBarUp"></param>
    public static void PaySink(GameObject PopBarUp,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        PopBarUp.GetComponent<CanvasGroup>().alpha = 0;
        PopBarUp.transform.localScale = new Vector3(0, 0, 0);
        /*-------------------------------------动画效果------------------------------------*/
        PopBarUp.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        PopBarUp.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            finish();
        });
    }


    /// <summary>
    /// 弹窗消失效果
    /// </summary>
    /// <param name="PopBarDisapper"></param>
    public static void PayWeak(GameObject PopBarDisapper,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        PopBarDisapper.GetComponent<CanvasGroup>().alpha = 1;
        PopBarDisapper.transform.localScale = new Vector3(1, 1, 1);
        /*-------------------------------------动画效果------------------------------------*/
        PopBarDisapper.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        PopBarDisapper.transform.DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() => 
        {
            finish();
        });
    }
    /// <summary>
    /// 数字变化动画
    /// </summary>
    /// <param name="startNum"></param>
    /// <param name="endNum"></param>
    /// <param name="text"></param>
    /// <param name="finish"></param>
    public static void BalticDisuse(int startNum, int endNum,float delay, Text text,System.Action finish)
    {
        DOTween.To(() => startNum, x => text.text = x.ToString(), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish();
        });
    }

    public static void BalticDisuse(double startNum, double endNum, float delay, Text text, System.Action finish)
    {
        BalticDisuse(startNum, endNum, delay, text, "", finish);
    }
    public static void BalticDisuse(double startNum, double endNum, float delay, Text text, string prefix, System.Action finish)
    {
        DOTween.To(() => startNum, x => text.text = prefix + DisuseSure.IndigoMeLap(x), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish();
        });
    }

    public static void FollySo(float startNum, float endNum,int nowLevel,int fullCount , float delay, Image image,Text text, System.Action finish)
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(delay);
        for (int i = 0; i < fullCount; i++)
        {
            
            seq.Append(DOTween.To(() => startNum, x => image.fillAmount = x, 1, 1f / fullCount));
            seq.AppendCallback(() =>
            {
                nowLevel++;
                text.text = nowLevel.ToString();
                image.fillAmount = 0;
                startNum = 0;
            });
        }
        if (endNum != 0)
        {
            seq.Append(DOTween.To(() => startNum, x => image.fillAmount = x, endNum, 0.6f));
        }
        seq.AppendCallback(() =>
        {
            finish();
        });
    }
    /// <summary>
    /// 进度条动画
    /// </summary>
    /// <param name="startValue"></param>
    /// <param name="endValue"></param>
    /// <param name="sliderImage"></param>
    /// <param name="finish"></param>
    public static void BalticEmployTheir(float startValue,float endValue,Image sliderImage, System.Action finish, float delay = 0)
    {
        DOTween.To(() => startValue, x => sliderImage.fillAmount = x, endValue, 0.5f).SetDelay(delay).OnComplete(() => {
            finish();
        });
    }


    /// <summary>
    /// 首页TopBar出现/Play按钮消失
    /// </summary>
    /// <param name="HomeTopBar"></param>
    /// <param name="MoveOffset"></param>
    /// <param name="finish"></param>
    public static void ForeSink(GameObject HomeTopBarShow, float MoveOffsetShow, System.Action finish) 
    {
        /*-------------------------------------初始化------------------------------------*/
        HomeTopBarShow.GetComponent<CanvasGroup>().alpha = 0;
        HomeTopBarShow.transform.position = new Vector3(HomeTopBarShow.transform.position.x, HomeTopBarShow.transform.position.y + MoveOffsetShow, HomeTopBarShow.transform.position.z);
        /*-------------------------------------动画效果------------------------------------*/
        HomeTopBarShow.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        HomeTopBarShow.transform.DOMoveY(HomeTopBarShow.transform.position.y - MoveOffsetShow, 0.5f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            finish();
        });
    }


    /// <summary>
    /// 首页Top消失/Play按钮出现
    /// </summary>
    /// <param name="HomeTopBar"></param>
    /// <param name="MoveOffset"></param>
    /// <param name="finish"></param>
    public static void ForeWeak(GameObject HomeTopBarHide, float MoveOffsetHide, System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        HomeTopBarHide.GetComponent<CanvasGroup>().alpha = 1;
        
        /*-------------------------------------动画效果------------------------------------*/
        HomeTopBarHide.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        HomeTopBarHide.transform.DOMoveY(HomeTopBarHide.transform.position.y + MoveOffsetHide, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            HomeTopBarHide.transform.position = new Vector3(HomeTopBarHide.transform.position.x, HomeTopBarHide.transform.position.y - MoveOffsetHide, HomeTopBarHide.transform.position.z);
            finish();
        });
    }



    /// <summary>
    /// 收金币效果
    /// </summary>
    /// <param name="GoldImage"></param>
    /// <param name="parent"></param>
    /// <param name="a"></param>
    /// <param name="GoldStart"></param>
    /// <param name="GoldFinal"></param>
    /// <param name="NextShow">播放下一个收取动画</param>
    /// <param name="finish">这个动画播完了</param>
    public static void NeonHerb(GameObject GoldImage,Transform parent, int a ,Transform GoldStart,Transform GoldFinal,System.Action finish) 
    {
        if (a == 0)
        {
            finish();
        }
            float endtime = 0;
            float starttime = Time.time;
            Debug.Log("starttime = " + starttime);
            float Delaytime = 0;
            int finishCount = 0;
        for (int i = 0; i < a; i++) 
        {
            /*-------------------------------------初始化------------------------------------*/
            Delaytime += UnityEngine.Random.Range(0.05f, 0.2f);
            if (i == 0) 
            {
                Delaytime = 0;
            }
            
            var s = DOTween.Sequence();
            GameObject GoldIcon = Instantiate(GoldImage, parent);
            GoldIcon.SetActive(true);
            GoldIcon.GetComponent<Transform>().position = GoldStart.position;
            GoldIcon.GetComponent<Image>().color = new Color(GoldIcon.GetComponent<Image>().color.r, GoldIcon.GetComponent<Image>().color.g, GoldIcon.GetComponent<Image>().color.b, 0);
            GoldIcon.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            float OffsetX = UnityEngine.Random.Range(-0.5f, 0.5f);
            float OffsetY = UnityEngine.Random.Range(-0.5f, 0.5f);
            /*-------------------------------------动画效果------------------------------------*/
            //Debug.Log(OffsetX);
            GoldIcon.GetComponent<Transform>().position = new Vector3(GoldIcon.GetComponent<Transform>().position.x + OffsetX, GoldIcon.GetComponent<Transform>().position.y + OffsetY, GoldIcon.GetComponent<Transform>().position.z);
            s.Append(GoldIcon.GetComponent<Image>().DOFade(1, 0.4f));
            s.Insert(0, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.8f, 0.8f, 1), 0.4f).SetEase(Ease.OutBack));
            s.Append(GoldIcon.GetComponent<Transform>().DOMove(GoldFinal.position, 0.8f).SetEase(Ease.InBack)).SetDelay(0.15f + Delaytime);
            s.Insert(0.55f + Delaytime, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.8f));
            s.AppendCallback(() =>
            {
                s.Kill();
                Destroy(GoldIcon);
                finishCount++;
                if (finishCount == a)
                {
                    endtime = Time.time;
                    Debug.Log("endtime = " + endtime);
                    finish();
                }
            });
            s.Play();
        }
        
    }

    /// <summary>
    /// 收金币
    /// </summary>
    /// <param name="GoldImage">金币图标</param>
    /// <param name="a">金币数量</param>
    /// <param name="StartTF">起始位置</param>
    /// <param name="EndTF">最终位置</param>
    /// <param name="finish">结束回调</param>
    public static void NeonHerbExpo(GameObject GoldImage, int a, Transform StartTF, Transform EndTF, System.Action finish)
    {
        //如果没有就算了
        if (a == 0)
        {
            finish();
        }
        //数量不超过15个
        else if (a > 15)
        {
            a = 15;
        }
        //每个金币的间隔
        float Delaytime = 0;
        for (int i = 0; i < a; i++)
        {
            int t = i;
            //每次延迟+1
            Delaytime += 0.06f;
            //复制一个图标
            GameObject GoldIcon = Instantiate(GoldImage, GoldImage.transform.parent.parent.parent);
            //初始化
            GoldIcon.transform.position = StartTF.position;
            GoldIcon.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            //金币弹出随机位置
            float OffsetX = UnityEngine.Random.Range(-0.8f, 0.8f);
            float OffsetY = UnityEngine.Random.Range(-0.8f, 0.8f);
            //创建动画队列
            var s = DOTween.Sequence();
            //金币出现
            s.Append(GoldIcon.transform.DOMove(new Vector3(GoldIcon.transform.position.x + OffsetX, GoldIcon.transform.position.y + OffsetY, GoldIcon.transform.position.z), 0.15f).SetDelay(Delaytime).OnComplete(() =>
            {
                //限制音效播放数量
                //if (Mathf.Sin(t) > 0)
                if (t % 5 == 0)
                {
                    OfferJaw.YewVocation().BillPurify(OfferFist.UIMusic.Sound_GoldCoin);
                }
            }));
            //金币移动到最终位置
            s.Append(GoldIcon.transform.DOMove(EndTF.position, 0.6f).SetDelay(0.2f));
            s.Join(GoldIcon.transform.DOScale(1.5f, 0.3f).SetEase(Ease.InBack));
            s.AppendCallback(() =>
            {
                //收尾
                s.Kill();
                Destroy(GoldIcon);
                if (t == a - 1)
                {
                    finish();
                }
            });
        }
    }

    /// <summary>
    /// 游戏内金币飞入存钱罐效果
    /// </summary>
    /// <param name="GameBankCashImage"></param>
    /// <param name="parent"></param>
    /// <param name="BankCashStart"></param>
    /// <param name="BankCashFinal"></param>
    /// <param name="i"></param>
    public static void SoulSuchHerb(GameObject GameBankCashImage,Transform parent,Transform BankCashStart,Transform BankCashFinal,int i,System.Action finish)
    {
        GameObject GameBankCash = Instantiate(GameBankCashImage, parent);
        GameBankCash.transform.position = BankCashStart.position;
        GameBankCash.GetComponent<Image>().color = new Color(GameBankCash.GetComponent<Image>().color.r, GameBankCash.GetComponent<Image>().color.g, GameBankCash.GetComponent<Image>().color.b, 1);
        GameBankCash.SetActive(true);
        GameBankCash.transform.localScale = new Vector3(1f, 1f, 0.7f);
        if (i <= 2)
        {
            GameBankCash.transform.DOMoveX(BankCashFinal.position.x, 0.7f).SetEase(Ease.InBack);
            GameBankCash.transform.DOMoveY(BankCashFinal.position.y,0.7f).OnComplete(()=>{
                Destroy(GameBankCash);
                finish();
                //OfferJaw.GetInstance().PlayEffect(OfferFist.SceneMusic.Sound_GameBankGold);
            });
        }
        else if( i==3 )
        {
            float offsetX = UnityEngine.Random.Range(0, 0.5f);
            GameBankCash.transform.DOMoveX(BankCashFinal.position.x, 0.7f).SetEase(Ease.InBack);
            GameBankCash.transform.DOMoveY(BankCashFinal.position.y, 0.7f).OnComplete(() => 
            {
                /*GameBankCash.transform.DOMoveX(BankCashFinal.position.x + offsetX, 0.5f).SetEase(Ease.OutBack);
                GameBankCash.transform.DOMoveY(BankCashFinal.position.y - 0.3f, 0.5f).OnComplete(() => 
                {
                });*/
                    GameBankCash.transform.DOJump(new Vector3(GameBankCash.transform.position.x + offsetX, GameBankCash.transform.position.y-0.2f, GameBankCash.transform.position.z), UnityEngine.Random.Range(0.2f, 0.3f), 2, 0.6f);
                //OfferJaw.GetInstance().PlayEffect(OfferFist.SceneMusic.Sound_BankCashFull);
                GameBankCash.GetComponent<Image>().DOFade(0,2f).OnComplete(()=> {
                    Destroy(GameBankCash);
                    finish();
                });
            });
        }
    }



    /// <summary>
    /// 宝箱开启
    /// </summary>
    /// <param name="StarBox"></param>
    /// <param name="Content"></param>
    /// <param name="StartPoint"></param>
    /// <param name="MidPoint"></param>
    /// <param name="finish"></param>
    public static void SoonPegHerb(GameObject StarBox,float BoxMoveOffset,GameObject Fx_StarBoxOpen, System.Action RewardShow) 
    {

        /*-------------------------------------动画效果------------------------------------*/
        StarBox.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        StarBox.transform.DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            StarBox.transform.DOScaleY(0.8f, 0.2f).SetDelay(0.4f).OnComplete(() => 
            {
                StarBox.transform.DOScaleY(1.2f, 0.2f).SetEase(Ease.OutBack);
                StarBox.transform.DOScaleX(0.7f, 0.2f);
                StarBox.transform.DOMoveY((StarBox.transform.position.y + BoxMoveOffset), 0.2f).OnComplete(() => 
                {
                    StarBox.GetComponent<Transform>().Find("BoxTop").GetComponent<Image>().sprite = Resources.Load<Sprite>("Effects/UI_RewardBoxTopOpen");
                    Fx_StarBoxOpen.SetActive(true);
                    StarBox.transform.DOScaleX(1, 0.2f).OnComplete(() => 
                    {
                        RewardShow();
                        StarBox.transform.DOMoveY((StarBox.transform.position.y - BoxMoveOffset), 0.3f);
                        StarBox.transform.DOScaleY(1, 0.45f).SetEase(Ease.OutBack);
                            /*StarBox.GetComponent<Transform>().Find("BoxTop").GetComponent<Image>().sprite = Resources.Load<Sprite>("Effects/UI_RewardBoxTopClose");*/
                    });
                });
            });
        });
    }

    /// <summary>
    /// 宝箱奖励出现
    /// </summary>
    /// <param name="CardList"></param>
    /// <param name="Count"></param>
    /// <param name="finish"></param>
    public static void SoonPegSunlitSink(List<GameObject> CardList, int Count, System.Action finish)
    {
        GameObject Reward = CardList[0];
        float CardW  = Reward.GetComponent<RectTransform>().sizeDelta.x * Reward.GetComponent<RectTransform>().localScale.x;
        float screenW = UIManager.YewVocation().BeauChurch.GetComponent<CanvasScaler>().referenceResolution.x;
        int finishCount = Count;
        if (Count == 3) 
        {
            float Space1 = 80f;
            float Space2 = ((UIManager.YewVocation().BeauChurch.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {
                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                if (i == 1)
                {
                    card.transform.DOLocalMoveY(300f, 0.45f);
                }
                else 
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                }
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        finishCount--;
                        GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                        Fx_RewardBG.SetActive(true);
                        if (finishCount == 0)
                        {
                            finish();
                        }
                    });
            }

        }//三个奖励
        if (Count == 4) 
        {
            float Space1 = 30f;
            float Space2 = ((UIManager.YewVocation().BeauChurch.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {

                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                if (i == 1 || i == 2)
                {
                    card.transform.DOLocalMoveY(300f, 0.45f);
                }
                else 
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                }
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    finishCount--;
                    GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                    Fx_RewardBG.SetActive(true);
                    if (finishCount == 0)
                    {
                        finish();
                    }
                });
            }
        }//四个奖励
        if (Count < 3) 
        {
            float Space1 = 100f;
            float Space2 = ((UIManager.YewVocation().BeauChurch.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {
                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                card.transform.DOLocalMoveY(250f, 0.45f);
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    finishCount--;
                    GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                    Fx_RewardBG.SetActive(true);
                    if (finishCount == 0)
                    {
                        finish();
                    }
                });
            }
        }//一个或两个奖励


    }

    /// <summary>
    /// 升级时图标转换
    /// </summary>
    /// <param name="UnLevelIcon">颜色比较暗的等级图标</param>
    /// <param name="LevelIcon">正常等级图标</param>
    /// <param name="finish"></param>
    public static void FollyAfloatICapSlime(GameObject UnLevelIcon, Sprite LevelIcon, Text text, System.Action finish)
    {
        UnLevelIcon.transform.localScale = new Vector3(1, 1, 1);
        UnLevelIcon.transform.DOScale(new Vector3(0, 0, 0), 0.3f).OnComplete(() =>
        {
            UnLevelIcon.GetComponent<Image>().sprite = LevelIcon;
            text.color = Color.white;
            GameObject Fx_level = Instantiate(Resources.Load<GameObject>("Animation/AniFx/Fx_SoulExplosionOrange"), UnLevelIcon.transform);
            Fx_level.SetActive(true);
            UnLevelIcon.transform.DOScale(new Vector3(1, 1, 1), 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                Destroy(Fx_level);
                finish();
            });
        });

    }

    /// <summary>
    /// 点击领取每日奖励
    /// </summary>
    /// <param name="box"> 箱子默认图 </param>
    /// <param name="RewardImage"> 奖励图片 </param>
    /// <param name="Fx_RewardBG"> 特效 </param>
    /// <param name="finish"></param>
    public static void AloftKrillSap(GameObject box,GameObject Fx_RewardBG,System.Action finish) 
    {
        box.transform.localScale = new Vector3(1, 1, 1);
        Fx_RewardBG.SetActive(false);
        box.transform.DOScale(0.7f, 0.3f).OnComplete(() => 
        {
            Fx_RewardBG.SetActive(true);
            box.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).OnComplete(() => 
            {
                finish();
            });
        });
    }


    /// <summary>
    /// 呼吸缩放效果
    /// </summary>
    /// <param name="BankBtn"></param>
    /// <param name="i"></param>
    public static void Captain(GameObject BankBtn,int i) 
    {
        float offset = -0.6f;
        DOTween.Kill("FlashMove");
        BankBtn.GetComponent<Image>().material = null;
        BankBtn.transform.localScale = new Vector3(1, 1, 1);
        if (i == 1)
        {
            BankBtn.GetComponent<Image>().material = Resources.Load<Material>("Effects/Mat_Flash");
            var BankAni = DOTween.Sequence();
            BankAni.Append(BankBtn.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 1.2f));
            BankAni.Append(BankBtn.transform.DOScale(new Vector3(1f, 1f, 1f), 1.2f));
            BankAni.Insert(0, DOTween.To(() => offset, x => BankBtn.GetComponent<Image>().material.SetFloat("_LightOffset", offset = x), 0.6f, 1f).SetDelay(1).OnComplete
                (() =>
                {
                    BankBtn.GetComponent<Image>().material.SetFloat("_LightOffset", -0.6f);
                }));
            BankAni.SetLoops(-1);
            BankAni.SetId<Tween>("FlashMove");
            BankAni.Play();
        }
    }

   

    /// <summary>
    /// Topbar Icon跳动动画
    /// </summary>
    /// <param name="IconImage">Icon图标</param>
    public static void BarnJump(GameObject IconImage)
    {
        IconImage.transform.DOScale(1.2f, 0.1f).OnComplete(() =>
        {
            IconImage.transform.DOScale(1f, 0.1f);

        });
    }

    public static void OVOHerb(GameObject GoldImage, Transform parent, int a, Transform GoldStart, Transform GoldFinal, System.Action NextShow, System.Action finish)
    {
        if (a == 0)
        {
            finish();
        }
        float endtime = 0;
        float starttime = Time.time;
        Debug.Log("starttime = " + starttime);
        float Delaytime = 0;
        int finishCount = 0;
        for (int i = 0; i < a; i++)
        {
            /*-------------------------------------初始化------------------------------------*/
            Delaytime += UnityEngine.Random.Range(0.05f, 0.2f);
            if (i == 0)
            {
                Delaytime = 0;
            }

            var s = DOTween.Sequence();
            GameObject GoldIcon = Instantiate(GoldImage, parent);
            GoldIcon.SetActive(true);
            GoldIcon.GetComponent<Transform>().position = GoldStart.position;
            GoldIcon.GetComponent<Image>().color = new Color(GoldIcon.GetComponent<Image>().color.r, GoldIcon.GetComponent<Image>().color.g, GoldIcon.GetComponent<Image>().color.b, 0);
            GoldIcon.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            float OffsetX = UnityEngine.Random.Range(-1f, 1f);
            float OffsetY = UnityEngine.Random.Range(-1f, 1f);
            /*-------------------------------------动画效果------------------------------------*/
            //Debug.Log(OffsetX);
            GoldIcon.GetComponent<Transform>().position = new Vector3(GoldIcon.GetComponent<Transform>().position.x + OffsetX, GoldIcon.GetComponent<Transform>().position.y + OffsetY, GoldIcon.GetComponent<Transform>().position.z);
            s.Append(GoldIcon.GetComponent<Image>().DOFade(1, 0.4f));
            s.Insert(0, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.8f, 0.8f, 1), 0.4f).SetEase(Ease.OutBack));
            s.Append(GoldIcon.GetComponent<Transform>().DOMove(GoldFinal.position, 0.8f).SetEase(Ease.InBack)).SetDelay(0.15f + Delaytime).OnComplete(() =>
            {
                NextShow();
            });
            s.Insert(0.55f + Delaytime, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.8f));
            /*s.Append(GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f));*/
            s.AppendCallback(() =>
            {
                s.Kill();
                Destroy(GoldIcon);
                finishCount++;
                if (finishCount == a)
                {
                    endtime = Time.time;
                    Debug.Log("endtime = " + endtime);
                    finish();
                }
            });
            s.Play();
        }

    }


    /// <summary>
    /// 横向滚动
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="addPosition"></param>
    /// <param name="Finish"></param>
    public static void IncidentalDevote(GameObject obj, float addPosition, System.Action Finish)
    {
        float positionX = obj.transform.localPosition.x;
        float endPostion = positionX + addPosition;
        obj.transform.DOLocalMoveX(endPostion, 2f).SetEase(Ease.InOutQuart).OnComplete(() => {
            Finish?.Invoke();
        });
    }

    public static void BarnVery(GameObject Item)
    {
        Item.transform.DOScale(0.52f, 0.08f).OnComplete(() => 
        {
            Item.transform.DOScale(0.7f, 0.08f).OnComplete(()=> 
            {
                Item.transform.DOScale(0.52f, 0.08f);
            }); 
        });
    }
    
    public static void DisplaySap(Vector3 target, GameObject Item, Vector3 Start, Transform parent,
        System.Action finish)
    {
        float Delaytime = 0;
        Vector3 MidPoint = new Vector3((target.x + Start.x) / 2, (target.y + Start.y) / 2, -180);
        for (int i = 0; i < 7; i++)
        {
            Delaytime += 0.1f;
            GameObject GoldItem = Instantiate(Item, parent);
            GoldItem.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(Start.x, Start.y, -200);
            var T = DOTween.Sequence();
            if (Mathf.Abs(Start.x - target.x) < 1)
            {
                Vector3 MidPoint_1 = new Vector3(Start.x + 1, (target.y + Start.y) / 4, -180);
                Vector3 MidPoint_2 = new Vector3(target.x - 1, (target.y + Start.y) * 3 / 4, -180);
                T.Join(GoldItem.transform.DOMoveX(MidPoint_1.x, 0.25f).SetEase(Ease.OutQuart));
                T.Join(GoldItem.transform.DOMoveY(MidPoint_1.y, 0.25f).OnComplete(() =>
                {
                    GoldItem.transform.DOMoveX(target.x, 0.75f).SetEase(Ease.InOutQuart);
                    GoldItem.transform.DOMoveY(target.y, 0.75f).OnComplete(() => { Destroy(GoldItem); });
                }));
            }
            else
            {
                T.Join(GoldItem.transform.DOMoveX(MidPoint.x, 0.5f).SetEase(Ease.InQuart));
                T.Join(GoldItem.transform.DOMoveY(MidPoint.y, 0.5f).OnComplete(() =>
                {
                    GoldItem.transform.DOMoveX(target.x, 0.5f).SetEase(Ease.OutQuart);
                    GoldItem.transform.DOMoveY(target.y, 0.5f).OnComplete(() => { Destroy(GoldItem); });
                }));
            }

            T.SetDelay(Delaytime);
            if (i == 6)
            {
                if (finish != null)
                {
                    finish();
                }
            }
        }
    }

    /// <summary>
    /// fever模式动画
    /// </summary>
    IEnumerable  TenthAmusement(List<GameObject> Lightlist) 
    {
        for (int i = 0; i < Lightlist.Count; i++) 
        {
            yield return new WaitForSeconds(i*0.1f);
            GameObject LightFX = Lightlist[i].gameObject;
            LightFX.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            LightFX.SetActive(false);

        }
    }


    public static void DisplaySunlitSap(Vector3 target, GameObject Item, Vector3 Start, Transform parent,
        System.Action finish)
    {
        GameObject GoldItem = Instantiate(Item, parent);
        
        GoldItem.GetComponent<Transform>().position = new Vector3(Start.x, Start.y-5, -10);
        var T = DOTween.Sequence();
        T.Join(GoldItem.transform.DOScale(2.5f, 1).OnComplete(()=> 
        {
            GoldItem.transform.DOScale(1f, 1);
        }));
        T.Join(GoldItem.transform.DOMoveX(target.x, 2f).SetEase(Ease.OutQuart));
        T.Join(GoldItem.transform.DOMoveY(target.y, 2f).OnComplete(() => { Destroy(GoldItem); finish(); }));
        
    }
}
