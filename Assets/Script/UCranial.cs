using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCranial : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("materialId")]    // Scroll main texture based on time
    public int RegisterGo= 0;
[UnityEngine.Serialization.FormerlySerializedAs("scrollSpeedX")]    public float ManureCrimeX= 0.5f;
[UnityEngine.Serialization.FormerlySerializedAs("scrollSpeedY")]    public float ManureCrimeY= 0f;
    Renderer Such;

    void Start()
    {
        Such = GetComponent<Renderer>();
    }

    void Update()
    {
        //GetComponent<LineRenderer>().materials[0].
        

        float offsetX = Time.time/2 * -ManureCrimeX;
        float offsetY = Time.time * ManureCrimeY;

        Such.materials[RegisterGo].SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

        //rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }

}
