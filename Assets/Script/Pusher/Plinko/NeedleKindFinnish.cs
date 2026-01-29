using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Lofelt.NiceVibrations;

public class NeedleKindFinnish : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("index")]    public int Shock;
[UnityEngine.Serialization.FormerlySerializedAs("count")]    public int Giant;
[UnityEngine.Serialization.FormerlySerializedAs("countImage")]    public SpriteRenderer GiantHoney;
    int dropPupil;
    /// <summary>
    /// ��ײ������Ҳ�ˢ�½�ҿ�����
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Ball"))
        {
            //OfferJaw.GetInstance().PlayEffect(OfferFist.SceneMusic.sound_drop_ball,0.1f);
            collision.gameObject.SetActive(false);
            if (Giant >= 1)
            {
                PestTiltKind(Giant);
                if (!PusherManager.Instance.isPushFever)
                {
                    refreshPupil();
                }
            }
        }
    }

    void refreshPupil()
    {
        Giant = HallMaracaWrapper.YewVocation().EraNeedleKindPupil(Shock);
        GiantHoney.sprite = Resources.Load<Sprite>(CScream.PegPupil + Giant);
    }

    public void PestTiltKind(int c)
    {
        dropPupil += c;
        if (dropPupil == c)
        {
            StartCoroutine(PestTiltKindIronFast());
        }
    }

    /// <summary>
    /// ��ʱ�ͷŶ�����
    /// </summary>
    /// <returns></returns>
    IEnumerator PestTiltKindIronFast()
    {
        while(dropPupil > 0)
        {
            dropPupil--;
            PestKind();
            yield return new WaitForSeconds(0.1f);
        }
    }
    /// <summary>
    /// ��ʼ�����λ�ò��ͷ�
    /// </summary>
    void PestKind()
    {
        if (PusherManager.Instance.isPause)
        {
            return;
        }
       
        if (!PusherManager.Instance.isPushFever)
        {
            GameObject coin = PusherManager.Instance.getRewardItem(PusherRewardType.CoinGold);
            coin.transform.position = transform.position + new Vector3(0, 0, -0.5f);
            coin.transform.eulerAngles = new Vector3(Random.Range(0, 10), EraRotateTanker(), Random.Range(0, 10));
            coin.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-30f,30f) * 0.8f, Random.Range(180f,270f) * 0.8f, Random.Range(-50f,-80f) * 0.8f));
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_creat_coin, 0.1f);
        }
        else
        {
            GameObject coin = PusherManager.Instance.getRewardItem(Random.Range(0,2) == 0 ? PusherRewardType.CoinGold : PusherRewardType.CoinCash);
            coin.transform.position = transform.position + new Vector3(0, 0, -0.5f);
            coin.transform.eulerAngles = new Vector3(EraRotateTanker(), EraRotateTanker(), EraRotateTanker());
            coin.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f,10f) * 0.8f, Random.Range(300f,450f) * 0.8f, Random.Range(-30f,-40f) * 0.8f));
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_creat_coin_fever, 0.1f);
        }
        LopMonoid();
    }
    /// <summary>
    /// �Ƿ������
    /// </summary>
    bool AidMonoid= true;
    /// <summary>
    /// ��ʼ��
    /// </summary>
    void LopMonoid()
    {
        if (AidMonoid)
        {
            AidMonoid = false;
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
            StartCoroutine(FastenAfloatIronFast());
        }
        
    }
    /// <summary>
    /// �𶯽�����ʱ
    /// </summary>
    /// <returns></returns>
    IEnumerator FastenAfloatIronFast()
    {
        yield return new WaitForSeconds(0.1f);
        AidMonoid = true;
    }
    /// <summary>
    /// ��ȡ����Ƕ�
    /// </summary>
    /// <returns></returns>
    float EraRotateTanker()
    {
        return Random.Range(0, 360f);
    }


    /// <summary>
    /// feverģʽ��ˢ�±���
    /// </summary>
    public void TrashAloneGenetic(int c)
    {
        Giant = c;
        GiantHoney.sprite = Resources.Load<Sprite>(CScream.PegPupil + Giant);
    }
    /// <summary>
    /// fever����ˢ��
    /// </summary>
    /// <param name="count"></param>
    public void TrashSowGenetic()
    {
        refreshPupil();
    }

    // Start is called before the first frame update
    void Start()
    {
        //��ʼ����ҿ�����
        refreshPupil();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
