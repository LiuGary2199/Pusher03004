using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class RevealLandslideWrapper : MonoBehaviour
{
    static public RevealLandslideWrapper Instance;
[UnityEngine.Serialization.FormerlySerializedAs("push")]    public GameObject Stem;
[UnityEngine.Serialization.FormerlySerializedAs("slotBox")]    public GameObject PestPeg;
[UnityEngine.Serialization.FormerlySerializedAs("skillWallGroup")]    public GameObject DraftLakeCreep;
[UnityEngine.Serialization.FormerlySerializedAs("ballCreater")]    public LifeFinnish LuceFinnish;
    Sequence StemFin;
    Sequence PestPegFin;
    float PromptFall= -2.0f;
    float addFall= -3f;
    float StemHerbFast= 1.5f;
    float StemSmoothly= 1f;
    float TrashJuryHerbFast= 0.3f;
    float TrashJurySmoothly= 0f;
    float StemDot= -4.7f;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Stem.transform.position = new Vector3(Stem.transform.position.x, Stem.transform.position.y, 0.5f);
        Peal_z = Stem.transform.position.z;
        PestPeg.transform.localPosition = new Vector3(-1, PestPeg.transform.localPosition.y, PestPeg.transform.localPosition.z);
    }

    /// <summary>
    /// �ư��ʼλ��
    /// </summary>
    float Peal_z;
    /// <summary>
    /// ��ʼ�Ʊ�
    /// </summary>
    public void StemAloneHerb(bool needRefresh = false)
    {
        StemFin.Kill();
        
        float moveZ = PromptFall;
        float time = StemHerbFast;
        float interval = StemSmoothly;
        if (WeOnYewFall)
        {
            moveZ = addFall;
        }
        bool needBlock = false;
        
        if (PusherManager.Instance.isPushFever)
        {
            time = TrashJuryHerbFast;
            interval = TrashJurySmoothly; 
        }
        if (WeJuryDot)
        {
            time = StemHerbFast;
            WeJuryDot = false;
            moveZ = StemDot;
            needBlock = true;
        }
        StemFin = DOTween.Sequence();
        if (needRefresh)
        {
            StemFin.Append(Stem.GetComponent<Rigidbody>().DOMoveZ(Peal_z + moveZ, time * ((Peal_z + moveZ - Stem.transform.position.z) / moveZ)).SetEase(Ease.Linear));
        }
        else
        {
            StemFin.AppendInterval(interval);
            StemFin.Append(Stem.GetComponent<Rigidbody>().DOMoveZ(Peal_z + moveZ, time).SetEase(Ease.Linear));
        }
        StemFin.AppendInterval(interval);
        StemFin.Append(Stem.GetComponent<Rigidbody>().DOMoveZ(Peal_z, time).SetEase(Ease.Linear));
        StemFin.AppendCallback(() =>
        {
            if (needBlock)
            {
                StemDotExpose();
            }
            StemAloneHerb();
        });
        StemFin.Play();

    }
    /// <summary>
    /// ��ͣ�Ʊ�
    /// </summary>
    public void StemDecayHerb()
    {
        StemFin.Pause();
        PestPegFin.Pause();
    }
    /// <summary>
    /// �ָ��Ʊ�
    /// </summary>
    public void StemInventHerb()
    {
        StemFin.Play();
        PestPegFin.Play();
    }


    /// <summary>
    /// �Ƿ����ӳ�״̬
    /// </summary>
    bool WeOnYewFall= false;
    /// <summary>
    /// ����ӳ��ĳ���ʱ��
    /// </summary>
    float GelFallFast= 0;
    /// <summary>
    /// �ӳ��ư忪ʼ(��ʼ��������ʱ/ˢ�¶���״̬)
    /// </summary>
    /// <param name="time"></param>
    public void StemYewFall(float time)
    {
        GelFallFast += time;
        HallMaracaWrapper.YewVocation().HeroCourtFallFast(!WeOnYewFall, (int)time);
        if (!WeOnYewFall)
        {
            WeOnYewFall = true;
            float alreadyPlay = StemFin.ElapsedPercentage();
            if (alreadyPlay < 0.5f)
            {
                StemAloneHerb(true);
            }
            StartCoroutine(nameof(GelFallSowIronFast));
        }
    }
    /// <summary>
    /// ��ʱ�رռӳ�
    /// </summary>
    /// <returns></returns>
    IEnumerator GelFallSowIronFast()
    {
        float t = 0;
        while (t < GelFallFast)
        {
            yield return new WaitForSeconds(1);
            t++;
        }
        GelFallFast = 0;
        WeOnYewFall = false;
    }


    /// <summary>
    /// �Ƿ��Ѿ�����ǽ
    /// </summary>
    bool WeOnLakeSo= false;
    /// <summary>
    /// ǽ����ʣ��ʱ��
    /// </summary>
    float HeedSoFast= 0;
    /// <summary>
    /// ����ǽ����
    /// </summary>
    /// <param name="time"></param>
    public void LopLakeSo(float time)
    {
        HeedSoFast += time;
        HallMaracaWrapper.YewVocation().HeroCourtLakeFast(!WeOnLakeSo, (int)time);
        if (!WeOnLakeSo)
        {
            DraftLakeCreep.transform.DOMoveY(0, 0.3f);
            StartCoroutine(nameof(HeedSoSowIronFast));
        }
    }
    /// <summary>
    /// ����ǽ������ʱ
    /// </summary>
    /// <returns></returns>
    IEnumerator HeedSoSowIronFast()
    {
        int t = 0;
        while (t < HeedSoFast)
        {
            yield return new WaitForSeconds(1);
            t++;
        }
        HeedSoFast = 0;
        WeOnLakeSo = false;
        LopLakePont();
    }
    /// <summary>
    /// ����ǽ����
    /// </summary>
    public void LopLakePont()
    {
        DraftLakeCreep.transform.DOMoveY(-0.8f, 0.3f);
    }


    /// <summary>
    /// �Ƿ���Ҫȫ������
    /// </summary>
    bool WeJuryDot= false;
    /// <summary>
    /// ȫ�����»ص�
    /// </summary>
    System.Action StemDotExpose;
    /// <summary>
    /// ȫ������
    /// </summary>
    public void StemDotHerb(System.Action block)
    {
        StemDotExpose = block;
        WeJuryDot = true;
        float alreadyPlay = StemFin.ElapsedPercentage();
        if (alreadyPlay < 0.5f)
        {
            StemAloneHerb(true);
        }
    }


    

    /// <summary>
    /// slot�п�ʼ�ƶ�
    /// </summary>
    public void AntAloneHerb()
    {
        float moveX = 2f;
        float x = PestPeg.transform.position.x;
        PestPegFin = DOTween.Sequence();
        PestPegFin.Append(PestPeg.GetComponent<Rigidbody>().DOMoveX(x + moveX, 2));
        PestPegFin.Append(PestPeg.GetComponent<Rigidbody>().DORotate(new Vector3(0, 0, 90), 0.5f));
        PestPegFin.Append(PestPeg.GetComponent<Rigidbody>().DORotate(new Vector3(0, 0, 0), 0.5f));
        PestPegFin.AppendInterval(0.5f);
        PestPegFin.Append(PestPeg.GetComponent<Rigidbody>().DOMoveX(x, 2));
        PestPegFin.Append(PestPeg.GetComponent<Rigidbody>().DORotate(new Vector3(0, 0, -90), 0.5f));
        PestPegFin.Append(PestPeg.GetComponent<Rigidbody>().DORotate(new Vector3(0, 0, 0), 0.5f));
        PestPegFin.AppendInterval(0.5f);
        PestPegFin.SetLoops(-1);
        PestPegFin.Play();
    }
    /// <summary>
    /// ��ͣslot��
    /// </summary>
    public void PestPegDecayHerb()
    {
        PestPegFin.Pause();
    }
    /// <summary>
    /// �ָ�slot��
    /// </summary>
    public void PestPegInventHerb()
    {
        PestPegFin.Restart();
    }

    /// <summary>
    /// slot�йر�
    /// </summary>
    public void PianoCrabPeg()
    {
        PestPeg.SetActive(false);
    }


    void Start()
    {
        //�趨�ư��ʼλ��
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
