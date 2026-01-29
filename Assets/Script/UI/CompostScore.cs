using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using UnityEngine.SceneManagement;

public class CompostScore : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image UnwellHoney;
[UnityEngine.Serialization.FormerlySerializedAs("PassSliderImage")]    public Image PestEmployHoney;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text DirectorCent;
[UnityEngine.Serialization.FormerlySerializedAs("titleAnim")]    public SkeletonGraphic SpaceFair;
    AsyncOperation SleepFeel;
[UnityEngine.Serialization.FormerlySerializedAs("gamebg")]

    public Image Colony;
[UnityEngine.Serialization.FormerlySerializedAs("passbg")]    public Sprite Choice;
[UnityEngine.Serialization.FormerlySerializedAs("OldPass")]    public GameObject OldPest;
[UnityEngine.Serialization.FormerlySerializedAs("NewPass")]    public GameObject RubPest;
[UnityEngine.Serialization.FormerlySerializedAs("titleObj")]    public GameObject SpaceGel;
[UnityEngine.Serialization.FormerlySerializedAs("EnterBtn")]
    public Button MetalFew;
[UnityEngine.Serialization.FormerlySerializedAs("progressObj")]    public GameObject DirectorGel;



    // Start is called before the first frame update
    void Start()
    {
        DirectorGel.SetActive(true);
        MetalFew.onClick.RemoveAllListeners();
        MetalFew.onClick.AddListener(() =>
        {
            if (KettleSure.HeYield())
            {
                SleepFeel.allowSceneActivation = true;
            }
            else {
                Destroy(transform.gameObject);
                BeauWrapper.Instance.HostTire();
                CashOutManager.YewVocation().ReportEvent_LoadingTime();
            }
        });
        //if (PlayerPrefs.HasKey(CScream.sys_AppSH))
        //{
        //    gamebg.sprite = passbg;
        //    titleAnim.gameObject.SetActive(true);
        //    titleObj.SetActive(false);
        //    OldPass.gameObject.SetActive(false);
        //    NewPass.gameObject.SetActive(true);
        //}
        //else
        //{
        //    titleAnim.gameObject.SetActive(false);
        //    titleObj.SetActive(true);
        //    OldPass.gameObject.SetActive(true);
        //    NewPass.gameObject.SetActive(false);
        //}
        if (!PlayerPrefs.HasKey(CScream.Pig_Masthead))
        {
            ToilHallWrapper.HubCarpet(CScream.Pig_Masthead, I2.Loc.LocalizationManager.CurrentLanguage);
        }


        PestEmployHoney.fillAmount = 0;
        UnwellHoney.fillAmount = 0;
        DirectorCent.text = "0%";

        SpaceFair.AnimationState.SetAnimation(0, "chuxian", false);
        SpaceFair.AnimationState.AddAnimation(0, "daiji", true, 0f);
        CashOutManager.YewVocation().StartTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnwellHoney.fillAmount <= 0.8f || (MudHourJaw.instance.Study && CashOutManager.YewVocation().Ready))
        {
            PestEmployHoney.fillAmount += Time.deltaTime / 3f;
            UnwellHoney.fillAmount += Time.deltaTime / 3f;
            DirectorCent.text = (int)(UnwellHoney.fillAmount * 100) + "%";
            if (MudHourJaw.instance.Study && KettleSure.HeYield() && SleepFeel == null) //审核，模式 
            {
               // SleepFeel = SceneManager.LoadSceneAsync("AGame");
               // SleepFeel.allowSceneActivation = false;
            }
            if (UnwellHoney.fillAmount >= 1)
            {
                
                if (KettleSure.HeYield())
                {
                   // SleepFeel.allowSceneActivation = true;
                    BeauWrapper.Instance.HostTire();
                    CashOutManager.YewVocation().ReportEvent_LoadingTime();
                    Destroy(transform.gameObject);
                }
                else
                {
                    // DirectorGel.SetActive(false);
                    // MetalFew.gameObject.SetActive(true);
                    BeauWrapper.Instance.HostTire();
                    CashOutManager.YewVocation().ReportEvent_LoadingTime();
                    Destroy(transform.gameObject);
                }
            }
        }
    }
}
