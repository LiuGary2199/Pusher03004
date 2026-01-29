using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class YewRevealCharcoal : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("fx_Poolgroup")]    public GameObject Ox_Shrinkage;
[UnityEngine.Serialization.FormerlySerializedAs("fx_Poolgroup_1")]    public GameObject Ox_Shrinkage_1;
[UnityEngine.Serialization.FormerlySerializedAs("text_Poolgroup")]    public GameObject Lade_Shrinkage;
    private void OnTriggerEnter(Collider other)
    {
        GameObject pusherRewardItem = other.transform.parent.gameObject;
        if (pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.GemBlue || pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.GemDiamond || pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.GemRed || pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.Golden)
        {
            Transform TargetTF = UIManager.YewVocation().BeauChurch.transform.Find("Normal/UtahScore/Window/GemsStoreBtn").transform;
            GameObject TieEven= Resources.Load<GameObject>(CScream.Tie_Even).gameObject;
            GameObject TieZoo= Resources.Load<GameObject>(CScream.Tie_Zoo).gameObject;
            GameObject TieHeroism= Resources.Load<GameObject>(CScream.Tie_Heroism).gameObject;
            GameObject Concur= Resources.Load<GameObject>(CScream.Tie_Concur).gameObject;
            GameObject fx_1 = Ox_Shrinkage_1.GetComponent<TombWrapper>().YewOutlet();
            fx_1.SetActive(true);
            fx_1.transform.position = new Vector3(other.gameObject.transform.position.x, -0.5f, -5.74f);
            switch (pusherRewardItem.GetComponent<PusherRewardItem>().rewardType) 
            {
                case PusherRewardType.GemBlue:
                    LandslideDelectable.DisplaySunlitSap(TargetTF.transform.position, TieEven, other.gameObject.transform.position, TargetTF,()=> { });
                    break;
                case PusherRewardType.GemDiamond:
                    LandslideDelectable.DisplaySunlitSap(TargetTF.transform.position, TieHeroism, other.gameObject.transform.position, TargetTF, () => { });
                    break;
                case PusherRewardType.GemRed:
                    LandslideDelectable.DisplaySunlitSap(TargetTF.transform.position, TieZoo, other.gameObject.transform.position, TargetTF, () => { });
                    break;
                case PusherRewardType.Golden:
                    LandslideDelectable.DisplaySunlitSap(TargetTF.transform.position, Concur, other.gameObject.transform.position, TargetTF, () => { });
                    break;

            }
        }
        if (pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.CoinCash || pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.CoinGold)
        {
            GameObject fx = Ox_Shrinkage.GetComponent<TombWrapper>().YewOutlet();
            GameObject Text = Lade_Shrinkage.GetComponent<TombWrapper>().YewOutlet();
            Text.SetActive(true);
            fx.SetActive(true);
            float V = (Screen.height * -0.587f) - 260;
            Text.transform.localScale = new Vector3(2f, 2f, 2f);
            Text.transform.localPosition = new Vector3(Text.transform.localPosition.x, Text.transform.localPosition.y - 2, V);
            Text.transform.position = new Vector3(other.gameObject.transform.position.x, -5f, Text.transform.position.z);
            Text.transform.DOMoveY(-4f + Random.Range(0, 1.5f), 0.7f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                Text.SetActive(false);
            });
            fx.transform.position = new Vector3(other.gameObject.transform.position.x, -0.5f, -5.74f);
            if (pusherRewardItem.GetComponent<PusherRewardItem>().rewardType == PusherRewardType.CoinCash)
            {
                Text.GetComponent<Text>().color = new Color(4 / 255f, 1, 0);
                Text.GetComponent<Text>().text = "+" + System.Math.Round(pusherRewardItem.GetComponent<PusherRewardItem>().rewardNum,2);
            }
            else
            {
                Text.GetComponent<Text>().color = new Color(237 / 255f, 1, 0); 
                Text.GetComponent<Text>().text = "+" + pusherRewardItem.GetComponent<PusherRewardItem>().rewardNum;
            }
            
            
        }

        Transform parent = pusherRewardItem.transform.parent;
        pusherRewardItem.SetActive(false);
        pusherRewardItem.transform.SetParent(PusherManager.Instance.rewardItemGroup);
        if (parent.childCount == 0)
        {
            Destroy(parent.gameObject);
        }
        PusherManager.Instance.getDropReward(pusherRewardItem.GetComponent<PusherRewardItem>().rewardType, pusherRewardItem.GetComponent<PusherRewardItem>().rewardNum);
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
