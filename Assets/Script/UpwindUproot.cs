using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwindUproot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float Y = Screen.height * 0.006f + 55;
        //float ratio = 750f * 1f / 1334f / (Screen.width * 1f / Screen.height);
        gameObject.GetComponent<Camera>().fieldOfView = Y;


        //float targetHight = 1334f;
        //if (750f * Screen.height > 1334f * Screen.width)
        //{
        //    targetHight = 750f * Screen.height / Screen.width;
        //}
        //Camera.main.fieldOfView *= (targetHight / 1334f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
