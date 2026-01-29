using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimizeDecay : MonoBehaviour
{
    Vector3 Computer;

    /// <summary>
    /// ��ͣ������
    /// </summary>
    public void WearyVictimize()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            Computer = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if (GetComponent<Rigidbody2D>() != null)
        {
            Computer = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    public void BudgetVictimize()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = Computer;
        }
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().velocity = Computer;
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
