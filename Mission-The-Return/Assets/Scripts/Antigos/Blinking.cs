using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public bool blinking;
    Material material;
    Color color;
    public Color blinkColor = Color.black;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
    }

    void Update()
    {
        if (blinking)
        {
            float t = Mathf.PingPong(Time.time * 5.0f, 1f);

            material.color = Color.Lerp(color, blinkColor, t);
        }
    }
    public void Hit()
    {
        blinking = true;
        Invoke("StopBlinking", 2.0f);
    }
    void StopBlinking()
    {
        blinking=false;
        material.color = color;
    }
}
