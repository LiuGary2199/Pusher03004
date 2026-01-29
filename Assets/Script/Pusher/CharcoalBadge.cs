using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoalBadge : MonoBehaviour
{
    System.Action TableEnough;
    bool WeBloom= true;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("��ײ");
        if (WeBloom)
        {
            WeBloom = false;
            TableEnough();
            Destroy(this);
        }
    }

    public void LopBadgeEnough(System.Action block)
    {
        TableEnough = block;
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
