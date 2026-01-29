using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LifeFinnish : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ShootPoint")]
    public GameObject ShootHairy;
[UnityEngine.Serialization.FormerlySerializedAs("ballPerfab")]    public GameObject LuceTablet;
    Sequence MammalFin;
    //void startRotate()
    //{
    //    rotateSeq = DOTween.Sequence();
    //    rotateSeq.Append(ShootPoint.transform.DORotate(new Vector3(0, 0, 45), 2f));
    //    rotateSeq.AppendInterval(0.5f);
    //    rotateSeq.Append(ShootPoint.transform.DORotate(new Vector3(0, 0, -45), 2f));
    //    rotateSeq.AppendInterval(0.5f);
    //    rotateSeq.SetLoops(-1);
    //    rotateSeq.Play();
    //}
    public void FetusLife()
    {
        float scale = 0.2f;
        GameObject ball = Instantiate(LuceTablet, transform);
        ball.transform.position = ShootHairy.transform.position;
        ball.transform.localScale = new Vector3(scale, scale, scale);
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -20));
    }
    // Start is called before the first frame update
    void Start()
    {
        //ShootPoint.transform.DORotate(new Vector3(0, 0, 45), 0f);
        //startRotate();
    }

   
}
