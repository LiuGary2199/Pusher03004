using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MidairRevealCharcoal : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("fx_Poolgroup")]    public GameObject Ox_Shrinkage;
[UnityEngine.Serialization.FormerlySerializedAs("text_Poolgroup")]    public GameObject Lade_Shrinkage;
    private void OnTriggerEnter(Collider other)
    {
        //GameObject fx = fx_Poolgroup.GetComponent<TombWrapper>().GetObject();
        //GameObject Text = text_Poolgroup.GetComponent<TombWrapper>().GetObject();
        //Text.SetActive(true);
        //fx.SetActive(true);
        //float V = (Screen.height * -0.587f) - 260;
        //Text.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
        //Text.transform.localPosition = new Vector3(Text.transform.localPosition.x, Text.transform.localPosition.y, V);
        //Text.transform.position = new Vector3(other.gameObject.transform.position.x, -0.2f, Text.transform.position.z);
        //Text.transform.DOMoveY(1.5f, 0.7f).SetEase(Ease.OutQuad).OnComplete(()=> 
        //{
        //    Text.SetActive(false);
        //});
        //fx.transform.position = new Vector3 (other.gameObject.transform.position.x, -0.5f, -5.74f);

        GameObject pusherRewardItem = other.transform.parent.gameObject;
        Transform parent = pusherRewardItem.transform.parent;
        pusherRewardItem.SetActive(false);
        pusherRewardItem.transform.SetParent(PusherManager.Instance.rewardItemGroup);
        if (parent.childCount == 0)
        {
            Destroy(parent.gameObject);
        }
        if (pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.LuckyCard || pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.ScratchCard || pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.RollCash)
        {
            PusherManager.Instance.getDropReward(pusherRewardItem.GetComponent<PusherRewardItem>().rewardType, pusherRewardItem.GetComponent<PusherRewardItem>().rewardNum);
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
