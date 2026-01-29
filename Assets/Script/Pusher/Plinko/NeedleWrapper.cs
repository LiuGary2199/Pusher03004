using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleWrapper : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("shootPoint")]    public GameObject FetusHairy;
[UnityEngine.Serialization.FormerlySerializedAs("ballPerfab")]    public GameObject LuceTablet;
[UnityEngine.Serialization.FormerlySerializedAs("ballPanel")]    public GameObject LuceScore;
[UnityEngine.Serialization.FormerlySerializedAs("plateWidth")]    public float TowerLight;
[UnityEngine.Serialization.FormerlySerializedAs("allWidth")]    public float OatLight;
[UnityEngine.Serialization.FormerlySerializedAs("allBoxList")]    public List<NeedleKindFinnish> OatPegGerm;
[UnityEngine.Serialization.FormerlySerializedAs("ballPool")]    public TombWrapper LuceTomb;
    bool RelaxOnly;
    static public NeedleWrapper Instance;
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="drop_x"></param>
    public void PestLife(float drop_x)
    {
        if (PusherManager.Instance.isPause)
        {
            return;
        }
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.MediumImpact);
        float scale = 0.45f;
        GameObject ball = LuceTomb.YewOutlet();
        ball.transform.position = new Vector3(drop_x, FetusHairy.transform.position.y, FetusHairy.transform.position.z);
        ball.transform.localScale = new Vector3(scale, scale, scale);
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -20));
    }

    public void CordKind(float drop_x)
    {
        if (PusherManager.Instance.isPause)
        {
            return;
        }
        GameObject coin = PusherManager.Instance.getRewardItem(PusherRewardType.CoinGold);
        coin.transform.position = new Vector3(drop_x, 8f, -1f);
        coin.transform.eulerAngles = new Vector3(EraRotateTanker(), EraRotateTanker(), EraRotateTanker());
        coin.GetComponent<Rigidbody>().AddForce(0f, -5f, 0f);
        if (!PusherManager.Instance.isPushFever)
        {
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_creat_coin, 0.1f);
        }
        else
        {
            OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_creat_coin_fever, 0.1f);
        }
    }
    /// <summary>
    /// ���������
    /// </summary>
    /// <returns></returns>
    IEnumerator RelaxAfloatIronFast()
    {
        yield return new WaitForSeconds(DisuseSure.LopRodentBylaw(MudHourJaw.instance.UtahHall.base_config.touch_cd));
        RelaxOnly = false;
    }

    /// <summary>
    /// ��ͣȫ��С��
    /// </summary>
    public void WearyDotLife()
    {
        for (int i = 0; i < LuceTomb.Crew.Count; i++)
        {
            LuceTomb.Crew[i].GetComponent<VictimizeDecay>().WearyVictimize();
        }
    }
    /// <summary>
    /// �ָ�ȫ��С��
    /// </summary>
    public void BudgetDotLife()
    {
        for (int i = 0; i < LuceTomb.Crew.Count; i++)
        {
            LuceTomb.Crew[i].GetComponent<VictimizeDecay>().BudgetVictimize();
        }
    }


    /// <summary>
    /// plinko�� ����fever
    /// </summary>
    public void TrashAlonePegGenetic(int c)
    {
        foreach (NeedleKindFinnish creater in OatPegGerm)
        {
            creater.TrashAloneGenetic(c);
        }
    }
    /// <summary>
    /// plinko�� ����fever
    /// </summary>
    public void TrashSowPegGenetic()
    {
        foreach (NeedleKindFinnish creater in OatPegGerm)
        {
            creater.TrashSowGenetic();
        }
    }
    /// <summary>
    /// fever ��ʼ�Զ�����
    /// </summary>
    public void TrashAloneSendCordLife()
    {
        StartCoroutine(nameof(TireCordLifeIronFast));
    }
    /// <summary>
    /// fever �����Զ�����
    /// </summary>
    public void TrashSowSendCordLife()
    {
        StopCoroutine(nameof(TireCordLifeIronFast));
    }
    /// <summary>
    /// fever �Զ������ʱ
    /// </summary>
    /// <returns></returns>
    IEnumerator TireCordLifeIronFast()
    {
        while (PusherManager.Instance.isPushFever)
        {
            if (KettleSure.HeYield())
            {
                CordKind(Random.Range(-TowerLight / 2, TowerLight / 2));
                CordKind(Random.Range(-TowerLight / 2, TowerLight / 2));
                CordKind(Random.Range(-TowerLight / 2, TowerLight / 2));
            }
            else
            {
                PestLife(Random.Range(-TowerLight / 2, TowerLight / 2));
            }
            yield return new WaitForSeconds(0.3f);
        }

    }

    /// <summary>
    /// һ��������������
    /// </summary>
    /// <param name="count"></param>
    public void SternVeilKind(int count)
    {
        foreach (NeedleKindFinnish creater in OatPegGerm)
        {
            creater.PestTiltKind(count);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LuceTomb.TireTombWrapper(LuceTablet, LuceTomb.transform, 50, "Ball");
        if (KettleSure.HeYield())
        {
            LuceScore.gameObject.SetActive(false);

        }
        else
        {
            LuceScore.gameObject.SetActive(true);
        }
    }
    float EraRotateTanker()
    {
        return Random.Range(0, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer)
            {
                int fingerId = Input.GetTouch(0).fingerId;
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(fingerId))
                {
                    Debug.Log("�����UI");
                    return;
                }
            }
            ////����ƽ̨
            else
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("�����UI");
                    return;
                }
            }
            if (!RelaxOnly)
            {
                if (KettleSure.HeYield())
                {
                    if (!HeaveLifeWrapper.Instance.CordKindForYield()) return;
                    float coin_x = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2) * (TowerLight / 2);
                    CordKind(coin_x);
                }
                else
                {
                    // �Ƿ���С��
                    if (!HeaveLifeWrapper.Instance.CordLife()) return;
                    RelaxOnly = true;
                    StartCoroutine(nameof(RelaxAfloatIronFast));
                    float drop_x = 0;
                    drop_x = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2) * (TowerLight / 2);
                    ToilHallWrapper.HubSow("DropBallCount", ToilHallWrapper.YewSow("DropBallCount") + 1);
                    PestLife(drop_x);
                }
            }

        }
    }
}
