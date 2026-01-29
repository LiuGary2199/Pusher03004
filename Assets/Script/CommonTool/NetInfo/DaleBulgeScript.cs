using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class DaleBulgeScript : MonoWeightily<DaleBulgeScript>
{
    public string version = "1.2";
    public string UtahTone= MudHourJaw.instance.UtahTone;
    //channel
#if UNITY_IOS
    private string Legally= "AppStore";
#elif UNITY_ANDROID
    private string Channel = "GooglePlay";
#else
    private string Channel = "GooglePlay";
#endif


    private void OnApplicationPause(bool pause)
    {
        DaleBulgeScript.YewVocation().JuneUtahSquirrel();
    }
    
    public Text Lade;

    protected override void Awake()
    {
        base.Awake();
        
        version = Application.version;
        StartCoroutine(nameof(autoCorrect));
    }
    IEnumerator autoCorrect()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            DaleBulgeScript.YewVocation().JuneUtahSquirrel();
        }
    }
    private void Start()
    {
        if (ToilHallWrapper.YewSow("event_day") != DateTime.Now.Day && ToilHallWrapper.YewCarpet("user_servers_id").Length != 0)
        {
            ToilHallWrapper.HubSow("event_day", DateTime.Now.Day);
        }
    }
    public void PoolWeWhigBulge(string event_id)
    {
        PoolBulge(event_id);
    }
    public void JuneUtahSquirrel(List<string> valueList = null)
    {
        if (ToilHallWrapper.YewIndigo(CScream.If_PermanenceNeonKind) == 0)
        {
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceNeonKind, ToilHallWrapper.YewIndigo(CScream.If_NeonKind));
        }
        if (ToilHallWrapper.YewIndigo(CScream.If_Such) == 0)
        {
            ToilHallWrapper.HubIndigo(CScream.If_PermanenceSuch, ToilHallWrapper.YewIndigo(CScream.If_PermanenceSuch));
        }
        if (valueList == null)
        {
            valueList = new List<string>() { 
                
                UtahHallWrapper.YewVocation().YewNeon().ToString(),
                UtahHallWrapper.YewVocation().YewSuch().ToString(),
                UtahHallWrapper.YewVocation().YewPermanenceNeonKind().ToString(),
                UtahHallWrapper.YewVocation().YewPermanenceSuch().ToString(),
                UtahHallWrapper.YewVocation().YewPermanenceEither().ToString(),
                ToilHallWrapper.YewSow("DropBallCount").ToString(),
          
            };
        }
        
        if (ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo) == null)
        {
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", UtahTone);
        wwwForm.AddField("userId", ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo));

        wwwForm.AddField("gameVersion", version);

        wwwForm.AddField("channel", Legally);

        for (int i = 0; i < valueList.Count; i++)
        {
            wwwForm.AddField("resource" + (i + 1), valueList[i]);
        }



        StartCoroutine(PoolDale(MudHourJaw.instance.LastSum + "/api/client/game_progress", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    public void PoolBulge(string event_id, string p1 = null, string p2 = null, string p3 = null)
    {
        if (Lade != null)
        {
            if (int.Parse(event_id) < 9100 && int.Parse(event_id) >= 9000)
            {
                if (p1 == null)
                {
                    p1 = "";
                }
                Lade.text += "\n" + DateTime.Now.ToString() + "id:" + event_id + "  p1:" + p1;
            }
        }
        if (ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo) == null)
        {
            MudHourJaw.instance.Grant();
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", UtahTone);
        wwwForm.AddField("userId", ToilHallWrapper.YewCarpet(CScream.If_GrapeSourceGo));
        //Debug.Log("userId:" + ToilHallWrapper.GetString(CScream.sv_LocalServerId));
        wwwForm.AddField("version", version);
        //Debug.Log("version:" + version);
        wwwForm.AddField("channel", Legally);
        //Debug.Log("channel:" + channal);
        wwwForm.AddField("operateId", event_id);
        Debug.Log("operateId:" + event_id);


        if (p1 != null)
        {
            wwwForm.AddField("params1", p1);
        }
        if (p2 != null)
        {
            wwwForm.AddField("params2", p2);
        }
        if (p3 != null)
        {
            wwwForm.AddField("params3", p3);
        }
        StartCoroutine(PoolDale(MudHourJaw.instance.LastSum + "/api/client/log", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    IEnumerator PoolDale(string _url, WWWForm wwwForm, Action<string> fail, Action<string> success)
    {
        //Debug.Log(SerializeDictionaryToJsonString(dic));
        UnityWebRequest request = UnityWebRequest.Post(_url, wwwForm);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            fail(request.error);
            SacRetreat();
        }
        else
        {
            success(request.downloadHandler.text);
            SacRetreat();
        }
    }
    private void SacRetreat()
    {
        StopCoroutine(nameof(PoolDale));
    }


}