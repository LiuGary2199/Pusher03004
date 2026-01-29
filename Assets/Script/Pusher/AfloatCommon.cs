using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfloatCommon : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("block")]
    public System.Action Table;
    private void OnTriggerEnter(Collider other)
    {
        Table();
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
