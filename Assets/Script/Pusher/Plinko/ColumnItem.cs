using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnItem : MonoBehaviour
{
    public bool Light;
    public bool Lock;
    // Start is called before the first frame update
    void Start()
    {
        Light = false;
        Lock = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D obj)
    {
        OfferJaw.YewVocation().BillPurify(OfferFist.SceneMusic.sound_column_normal,0.1f);
        if (Light == false) 
        {
            PusherManager.Instance.AddBucketNum();
        }
        if (Lock == false) 
        {
            LandslideDelectable.BarnVery(gameObject);
            StartCoroutine(FeverAnimation(gameObject.GetComponent<SpriteRenderer>()));
        }
        Light = true;
    }
    IEnumerator FeverAnimation(SpriteRenderer Column)
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        Lock = true;
        Column.sprite = Resources.Load<Sprite>(CScream.Ail_10);
        yield return new WaitForSeconds(0.2f);
        Column.sprite = Resources.Load<Sprite>(CScream.Ail_8);
        Lock = false;
    }
}
