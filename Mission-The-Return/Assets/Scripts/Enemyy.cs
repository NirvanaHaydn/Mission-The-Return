using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    public int life;
    Blinking[] blink;
    void Start()
    {
        blink = gameObject.gameObject.GetComponentsInChildren<Blinking>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            Destroy(other.gameObject);
            life--;
            Blink();
            if(life <= 0)
            {
                
                GameControllerSingleton.instance.AddScore(5);
                Destroy(gameObject);
            }
        }
    }
    void Blink()
    {
        foreach(Blinking b in blink)
        {
            b.Hit();

        }
    }
}
